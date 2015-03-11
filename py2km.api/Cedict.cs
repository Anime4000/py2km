using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace py2km.api
{
	public class Cedict
	{
		// Make it outside, load once, to RAM
		static Dictionary<string, CedictData> CEDICT = new System.Collections.Generic.Dictionary<string, CedictData>();
		public static void Load()
		{
			foreach (var item in File.ReadAllLines("cedict_ts.u8"))
			{
				CedictData CedictContent = new CedictData()
				{
					Pinyin = null,
					English = null
				};

				if (item[0] == '#')
					continue;

				string tc = null;
				string sc = null;
				string py = null;
				string en = null;
				int i = 0;

				// Get Traditional Chinese
				while (item[i] != ' ')
				{
					tc += item[i++];
				}

				i++;

				// Get Simplified Chinese
				while (item[i] != ' ')
				{
					sc += item[i++];
				}

				i++;
				i++;

				// Get Pinyin (number)
				while (item[i] != ']')
				{
					py += item[i++];
				}

				i++;
				i++;
				i++;

				// Get English
				while (item.Length != i + 1)
				{
					en += item[i];
					i++;
				}

				// Add to dictionary
				CedictContent.Pinyin = py;
				CedictContent.English = en;

				if (!CEDICT.ContainsKey(tc))
					CEDICT.Add(tc, CedictContent);
				if (!CEDICT.ContainsKey(sc))
					CEDICT.Add(sc, CedictContent);
			}
		}

		// Below to search and retrive
		public static string Search(string input)
		{
			string Data = null;
			CedictData temp;

			if (CEDICT.TryGetValue(input, out temp))
			{
				Data = String.Format("{0}\n{1}\n{2}", input, temp.Pinyin, temp.English);
			}

			return Data;
		}

		// Below converting to Pinyin (number)
		public static string ToPinyin(string input)
		{
			string Tx = input;
			string Fi = null;

			int idx = 0; // Index
			int pos = Tx.Length; // Current position
			int len = Tx.Length; // Current length

			while (len != 0)
			{
				CedictData test;
				string temp = Tx.Substring(idx, len);
				if (CEDICT.TryGetValue(temp, out test))
				{
					Fi += test.Pinyin + " ";

					idx = pos; // Once found, move index to current position
					pos = Tx.Length; // then new position restart
					len = pos - idx; // then new length
				}
				else
				{
					len--; // Length of string
					pos--; // Go next character
					if (idx == pos)
					{
						Fi += Tx.Substring(pos, 1);
						idx++;
						pos = Tx.Length;
						len = pos - idx;
					}
				}
			}

			return Fi.ToLower();
		}
	}

	public class CedictData
	{
		public string Pinyin { get; set; }
		public string English { get; set; }
	}
}
