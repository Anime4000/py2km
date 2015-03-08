using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

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
	}

	public class CedictData
	{
		public string Pinyin { get; set; }
		public string English { get; set; }
	}
}
