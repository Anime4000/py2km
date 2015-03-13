using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace py2km
{
	class Globals
	{
		public static string Version
		{
			get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
		}
	}

	class OS
	{
		private static int p = (int)Environment.OSVersion.Platform;
		private static bool _IsWindows = false;
		private static bool _IsLinux = false;
		// Extra note:
		// Windows 7 and 8 return 2
		// Ubuntu 14.04.1 return 4
		/// <summary>
		/// Return true if this program running on Windows OS
		/// </summary>
		public static bool IsWindows
		{
			get
			{
				if (p == 2)
					_IsWindows = true;
				return _IsWindows;
			}
		}
		/// <summary>
		/// Return true if this program running on Linux/Unix-like OS
		/// </summary>
		public static bool IsLinux
		{
			get
			{
				if ((p == 4) || (p == 6) || (p == 128))
					_IsLinux = true;
				return _IsLinux;
			}
		}
		/// <summary>
		/// Return general OS name
		/// </summary>
		public static string Name
		{
			get
			{
				if ((p == 4) || (p == 6) || (p == 128))
					return "Linux";
				return "Windows";
			}
		}
	}
}
