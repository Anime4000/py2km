using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace py2km.api
{
	public class Html
	{
		public static string Builder(string input)
		{
			string A = Properties.Resources.HtmlContentOpen;
			string B = Properties.Resources.HtmlContentClose;
			return A + input + B;
		}

		public static string Loading()
		{
			return Properties.Resources.HtmlContentLoading;
		}

		public static string TempFile()
		{
			string path = Path.Combine(Path.GetTempPath(), "py2km");

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			return Path.Combine(path, "paan.html");
		}
	}
}
