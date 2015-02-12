using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace py2km.api
{
    public class Converter
    {
		public static string PinyinToKwikMandarin(string input)
		{
			string[] Tx = input.ToLower().Split(' ');
			string[] Py = {
							  "fei", "fēi", "féi", "fĕi", "fèi",
							  "hei", "hēi", "héi", "hĕi", "hèi",
							  "lei", "lēi", "léi", "lĕi", "lèi",
							  "lie", "liē", "lié", "liĕ", "liè",
							  "lüe",
							  "mei", "mēi", "méi", "mĕi", "mèi",
							  "mie", "miē", "mié", "miĕ", "miè",
							  "nei", "nēi", "néi", "nĕi", "nèi",
							  "nüe",
							  "shei", "shēi", "shéi", "shĕi", "shèi",
							  "bei", "bēi", "béi", "bĕi", "bèi",
							  "bie", "biē", "bié", "biĕ", "biè",
							  "dei", "dēi", "déi", "dĕi", "dèi",
							  "die", "diē", "dié", "diĕ", "diè",
							  "gei", "gēi", "géi", "gĕi", "gèi",
							  "jie", "jiē", "jié", "jiĕ", "jiè",
							  "jue", "juē", "jué", "juĕ", "juè",
							  "pei", "pēi", "péi", "pĕi", "pèi",
							  "pie", "piē", "pié", "piĕ", "piè",
							  "qie", "qiē", "qié", "qiĕ", "qiè",
							  "que", "quē", "qué", "quĕ", "què",
							  "tie", "tiē", "tié", "tiĕ", "tiè",
							  "xie", "xiē", "xié", "xiĕ", "xiè",
							  "xue", "xuē", "xué", "xuĕ", "xuè",
							  "zei", "zēi", "zéi", "zĕi", "zèi",
							  "zhei", "zhēi", "zhéi", "zhĕi", "zhèi",
							  "we", "wē", "wé", "wĕ", "wè", 
							  "ye", "yē", "yé", "yĕ", "yè", "yue", "yuē", "yué", "yuĕ", "yuè",
							  "b", "p", "d", "t", "zh", "c", "z", "j", "q", "x", "g", "k", 
						  };
			string[] Km = {
							  "fëi", "f¡i", "f¢i", "f£i", "f¤i",
							  "hëi", "h¡i", "h¢i", "h£i", "h¤i",
							  "lëi", "l¡i", "l¢i", "l£i", "l¤i",
							  "lië", "li¡", "li¢", "li£", "li¤",
							  "luië",
							  "mëi", "m¡i", "m¢i", "m£i", "m¤i",
							  "mië", "mi¡", "mi¢", "mi£", "mi¤",
							  "nëi", "n¡i", "n¢i", "n£i", "n¤i",
							  "nuië",
							  "shëi", "sh¡i", "sh¢i", "sh£i", "sh¤i",
							  "pëi", "p¡i", "p¢i", "p£i", "p¤i",
							  "pië", "pi¡", "pi¢", "pi£", "pi¤",
							  "tëi", "t¡i", "t¢i", "t£i", "t¤i",
							  "tië", "ti¡", "ti¢", "ti£", "ti¤",
							  "këi", "k¡i", "k¢i", "k£i", "k¤i",
							  "cië", "ci¡", "ci¢", "ci£", "ci¤",
							  "cuë", "cu¡", "cu¢", "cu£", "cu¤",
							  "phëi", "ph¡i", "ph¢i", "ph£i", "ph¤i",
							  "phië", "phi¡", "phi¢", "phi£", "phi¤",
							  "chië", "chi¡", "chi¢", "chi£", "chi¤",
							  "chuë", "chu¡", "chu¢", "chu£", "chu¤",
							  "thië", "thi¡", "thi¢", "thi£", "thi¤",
							  "shië", "shi¡", "shi¢", "shi£", "shi¤",
							  "shuë", "shu¡", "shu¢", "shu£", "shu¤",
							  "cëi", "c¡i", "c¢i", "c£i", "c¤i",
							  "cëi", "c¡i", "c¢i", "c£i", "c¤i",
							  "wë", "w¡", "w¢", "w£", "w¤", 
							  "yë", "y¡", "y¢", "y£", "y¤", "yuë", "yu¡", "yu¢", "yu£", "yu¤",
							  "p", "ph", "t", "th", "c", "ch", "c", "c", "ch", "sh", "k", "kh",
						  };

			input = "";

			for (int i = 0; i < Tx.Length; i++)
			{
				for (int x = 0; x < Py.Length; x++)
				{
					if (Tx[i].Contains(Py[x]))
					{
						Tx[i] = Tx[i].Replace(Py[x], Km[x]);
						break;
					}
				}
			}

			for (int i = 0; i < Tx.Length; i++)
				input = input + Tx[i] + " ";

			return input.Remove(input.Length - 1);
		}

		public static string ToneToPinyin(string input)
		{
			string[] Tx = input.ToLower().Split(' ');

			input = "";

			for (int i = 0; i < Tx.Length; i++)
			{
				if (Tx[i].Contains('1'))
				{
					Tx[i] = MakeToPinyin(Tx[i], 1);
					continue;
				}
				else if (Tx[i].Contains('2'))
				{
					Tx[i] = MakeToPinyin(Tx[i], 2);
					continue;
				}
				else if (Tx[i].Contains('3'))
				{
					Tx[i] = MakeToPinyin(Tx[i], 3);
					continue;
				}
				else if (Tx[i].Contains('4'))
				{
					Tx[i] = MakeToPinyin(Tx[i], 4);
					continue;
				}
				else
				{
					Tx[i] = Tx[i]; // LOL
					continue;
				}
			}

			for (int i = 0; i < Tx.Length; i++)
				input = input + Tx[i] + " ";

			return input.Remove(input.Length - 1);
		}

		private static string MakeToPinyin(string input, int tone)
		{
			switch (tone)
			{
				case 1:
					if (input.Contains('a'))
						input = input.Replace('a', 'ā');
					else if (input.Contains('e'))
						input = input.Replace('e', 'ē');
					else if (input.Contains('o'))
						input = input.Replace('o', 'ō');
					else if (input.Contains('u'))
						input = input.Replace('u', 'ū');
					else if (input.Contains('i'))
						input = input.Replace('i', 'ī');
					break;
				case 2:
					if (input.Contains('a'))
						input = input.Replace('a', 'á');
					else if (input.Contains('e'))
						input = input.Replace('e', 'é');
					else if (input.Contains('o'))
						input = input.Replace('o', 'ó');
					else if (input.Contains('u'))
						input = input.Replace('u', 'ú');
					else if (input.Contains('i'))
						input = input.Replace('i', 'í');
					break;
				case 3:
					if (input.Contains('a'))
						input = input.Replace('a', 'ă');
					else if (input.Contains('e'))
						input = input.Replace('e', 'ĕ');
					else if (input.Contains('o'))
						input = input.Replace('o', 'ŏ');
					else if (input.Contains('u'))
						input = input.Replace('u', 'ŭ');
					else if (input.Contains('i'))
						input = input.Replace('i', 'ĭ');
					break;
				case 4:
					if (input.Contains('a'))
						input = input.Replace('a', 'à');
					else if (input.Contains('e'))
						input = input.Replace('e', 'è');
					else if (input.Contains('o'))
						input = input.Replace('o', 'ò');
					else if (input.Contains('u'))
						input = input.Replace('u', 'ù');
					else if (input.Contains('i'))
						input = input.Replace('i', 'ì');
					break;
			}

			return Regex.Replace(input, "[0-9]", ""); ;
		}
    }
}
