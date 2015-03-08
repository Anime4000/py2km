using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace py2km.api
{
	class CedictProcessor
	{
		// Make it outside, load once, to RAM
		public static Dictionary<String, CedictData> CEDICT = new System.Collections.Generic.Dictionary<string, CedictData>();
		public static void Load()
		{
			CedictData CedictContent = new CedictData()
			{
				Pinyin = null,
				English = null
			};

			CEDICT.Add("", CedictContent);
		}

		// Below to search and retrive
		public static string[] Search(string input)
		{
			string[] Data = new string[3]; // 0 = Chinese, 1 = Pinyin, 2 = English

			return Data;
		}
	}

	public class CedictData
	{
		public string Pinyin { get; set; }
		public string English { get; set; }
	}
}
