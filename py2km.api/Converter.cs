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
							  "ye", "yē", "yé", "yĕ", "yè", 
							  "yue", "yuē", "yué", "yuĕ", "yuè",
							  
							  "ka","kā","ká","kă","kà",
							  "ke","kē","ké","kĕ","kè",
							  "ko","kō","kó","kŏ","kò",
							  "ku","kū","kú","kŭ","kù",
							  "ki","kī","kí","kĭ","kì",

							  "xa","xā","xá","xă","xà",
							  "xe","xē","xé","xĕ","xè",
							  "xo","xō","xó","xŏ","xò",
							  "xu","xū","xú","xŭ","xù",
							  "xi","xī","xí","xĭ","xì",

							  "qa","qā","qá","qă","qà",
							  "qe","qē","qé","qĕ","qè",
							  "qo","qō","qó","qŏ","qò",
							  "qu","qū","qú","qŭ","qù",
							  "qi","qī","qí","qĭ","qì",

							  "ja","jā","já","jă","jà",
							  "je","jē","jé","jĕ","jè",
							  "jo","jō","jó","jŏ","jò",
							  "ju","jū","jú","jŭ","jù",
							  "ji","jī","jí","jĭ","jì",

							  "za","zā","zá","ză","zà",
							  "ze","zē","zé","zĕ","zè",
							  "zo","zō","zó","zŏ","zò",
							  "zu","zū","zú","zŭ","zù",
							  "zi","zī","zí","zĭ","zì",

							  "ca","cā","cá","că","cà",
							  "ce","cē","cé","cĕ","cè",
							  "co","cō","có","cŏ","cò",
							  "cu","cū","cú","cŭ","cù",
							  "ci","cī","cí","cĭ","cì",

							  "zha","zhā","zhá","zhă","zhà",
							  "zhe","zhē","zhé","zhĕ","zhè",
							  "zho","zhō","zhó","zhŏ","zhò",
							  "zhu","zhū","zhú","zhŭ","zhù",
							  "zhi","zhī","zhí","zhĭ","zhì",

							  "ta","tā","tá","tă","tà",
							  "te","tē","té","tĕ","tè",
							  "to","tō","tó","tŏ","tò",
							  "tu","tū","tú","tŭ","tù",
							  "ti","tī","tí","tĭ","tì",

							  "da","dā","dá","dă","dà",
							  "de","dē","dé","dĕ","dè",
							  "do","dō","dó","dŏ","dò",
							  "du","dū","dú","dŭ","dù",
							  "di","dī","dí","dĭ","dì",

							  "pa","pā","pá","pă","pà",
							  "pe","pē","pé","pĕ","pè",
							  "po","pō","pó","pŏ","pò",
							  "pu","pū","pú","pŭ","pù",
							  "pi","pī","pí","pĭ","pì",

							  "ba","bā","bá","bă","bà",
							  "be","bē","bé","bĕ","bè",
							  "bo","bō","bó","bŏ","bò",
							  "bu","bū","bú","bŭ","bù",
							  "bi","bī","bí","bĭ","bì",

							  "ga","gā","gá","gă","gà",
							  "ge","gē","gé","gĕ","gè",
							  "go","gō","gó","gŏ","gò",
							  "gu","gū","gú","gŭ","gù",
							  "gi","gī","gí","gĭ","gì",
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
							  "yë", "y¡", "y¢", "y£", "y¤", 
							  "yuë", "yu¡", "yu¢", "yu£", "yu¤",

							  "kha","khā","khá","khă","khà",
							  "khe","khē","khé","khĕ","khè",
							  "kho","khō","khó","khŏ","khò",
							  "khu","khū","khú","khŭ","khù",
							  "khi","khī","khí","khĭ","khì",

							  "sha","shā","shá","shă","shà",
							  "she","shē","shé","shĕ","shè",
							  "sho","shō","shó","shŏ","shò",
							  "shu","shū","shú","shŭ","shù",
							  "shi","shī","shí","shĭ","shì",

							  "cha","chā","chá","chă","chà",
							  "che","chē","ché","chĕ","chè",
							  "cho","chō","chó","chŏ","chò",
							  "chu","chū","chú","chŭ","chù",
							  "chi","chī","chí","chĭ","chì",

							  "ca","cā","cá","că","cà",
							  "ce","cē","cé","cĕ","cè",
							  "co","cō","có","cŏ","cò",
							  "cu","cū","cú","cŭ","cù",
							  "ci","cī","cí","cĭ","cì",

							  "ca","cā","cá","că","cà",
							  "ce","cē","cé","cĕ","cè",
							  "co","cō","có","cŏ","cò",
							  "cu","cū","cú","cŭ","cù",
							  "ci","cī","cí","cĭ","cì",

							  "cha","chā","chá","chă","chà",
							  "che","chē","ché","chĕ","chè",
							  "cho","chō","chó","chŏ","chò",
							  "chu","chū","chú","chŭ","chù",
							  "chi","chī","chí","chĭ","chì",

							  "ca","cā","cá","că","cà",
							  "ce","cē","cé","cĕ","cè",
							  "co","cō","có","cŏ","cò",
							  "cu","cū","cú","cŭ","cù",
							  "ci","cī","cí","cĭ","cì",

							  "tha","thā","thá","thă","thà",
							  "the","thē","thé","thĕ","thè",
							  "tho","thō","thó","thŏ","thò",
							  "thu","thū","thú","thŭ","thù",
							  "thi","thī","thí","thĭ","thì",

							  "ta","tā","tá","tă","tà",
							  "te","tē","té","tĕ","tè",
							  "to","tō","tó","tŏ","tò",
							  "tu","tū","tú","tŭ","tù",
							  "ti","tī","tí","tĭ","tì",

							  "pha","phā","phá","phă","phà",
							  "phe","phē","phé","phĕ","phè",
							  "pho","phō","phó","phŏ","phò",
							  "phu","phū","phú","phŭ","phù",
							  "phi","phī","phí","phĭ","phì",

							  "pa","pā","pá","pă","pà",
							  "pe","pē","pé","pĕ","pè",
							  "po","pō","pó","pŏ","pò",
							  "pu","pū","pú","pŭ","pù",
							  "pi","pī","pí","pĭ","pì",

							  "ka","kā","ká","kă","kà",
							  "ke","kē","ké","kĕ","kè",
							  "ko","kō","kó","kŏ","kò",
							  "ku","kū","kú","kŭ","kù",
							  "ki","kī","kí","kĭ","kì",
						  };

			input = "";

			for (int i = 0; i < Tx.Length; i++)
			{
				if (Tx[i].Contains("ian"))
					Tx[i] = Tx[i].Replace("ian", "iën");

				if (Tx[i].Contains("ju") || Tx[i].Contains("qu") || Tx[i].Contains("xu"))
					Tx[i] = Tx[i].Replace("u", "uiy");

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

			return Regex.Replace(input, "[0-9]", "");
		}
    }
}
