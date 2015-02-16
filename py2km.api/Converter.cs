using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
							  "lian", "liān", "lián", "liăn", "liàn",
							  "lie", "liē", "lié", "liĕ", "liè",
							  "lüe", "lüē", "lüé", "lüĕ", "lüè",
							  "mei", "mēi", "méi", "mĕi", "mèi",
							  "mian", "miān", "mián", "miăn", "miàn", 
							  "mie", "miē", "mié", "miĕ", "miè",
							  "nei", "nēi", "néi", "nĕi", "nèi",
							  "nian", "niān", "nián", "niăn", "niàn",
							  "nüe", "nüē", "nüé", "nüĕ", "nüè",
							  "ri","rī","rí","rĭ","rì",
							  "si","sī","sí","sĭ","sì",
							  "shei", "shēi", "shéi", "shĕi", "shèi",
							  "shi","shī","shí","shĭ","shì",
							  "wei", "wēi", "wéi", "wĕi", "wèi",
							  "ye", "yē", "yé", "yĕ", "yè",
							  "yu", "yū", "yú", "yŭ", "yù",
							  "yuan", "yuān", "yuán", "yuăn", "yuàn",
							  "yue", "yuē", "yué", "yuĕ", "yuè",
							  "yun", "yūn", "yún", "yŭn", "yùn",
							  "ba", "bā", "bá", "bă", "bà",
							  "bai", "bāi", "bái", "băi", "bài",
							  "ban", "bān", "bán", "băn", "bàn",
							  "bang", "bāng", "báng", "băng", "bàng",
							  "bao", "bāo", "báo", "băo", "bào",
							  "bei", "bēi", "béi", "bĕi", "bèi",
							  "ben", "bēn", "bén", "bĕn", "bèn",
							  "beng", "bēng", "béng", "bĕng", "bèng",
							  "bi","bī","bí","bĭ","bì",
							  "bian","bīan","bían","bĭan","bìan",
							  "biao", "biāo", "biáo", "biăo", "biào",
							  "bie", "biē", "bié", "biĕ", "biè",
							  "bin","bīn","bín","bĭn","bìn",
							  "bing","bīng","bíng","bĭng","bìng",
							  "bo", "bō", "bó", "bŏ", "bò",
							  "bu", "bū", "bú", "bŭ", "bù",
							  "ca", "cā", "cá", "că", "cà",
							  "cai", "cāi", "cái", "căi", "cài",
							  "can", "cān", "cán", "căn", "càn",
							  "cang", "cāng", "cáng", "căng", "càng",
							  "cao", "cāo", "cáo", "căo", "cào",
							  "ce", "cē", "cé", "cĕ", "cè",
							  "cen", "cēn", "cén", "cĕn", "cèn",
							  "ceng", "cēng", "céng", "cĕng", "cèng",
							  "ci","cī","cí","cĭ","cì",
							  "cong", "cōng", "cóng", "cŏng", "còng",
							  "cou", "cōu", "cóu", "cŏu", "còu",
							  "cu", "cū", "cú", "cŭ", "cù",
							  "cuo", "cuō", "cuó", "cuŏ", "cuò",
							  "cun", "cūn", "cún", "cŭn", "cùn",
							  "chi","chī","chí","chĭ","chì",
							  "da", "dā", "dá", "dă", "dà",
							  "dai", "dāi", "dái", "dăi", "dài",
							  "dan", "dān", "dán", "dăn", "dàn",
							  "dang", "dāng", "dáng", "dăng", "dàng",
							  "dao", "dāo", "dáo", "dăo", "dào",
							  "de", "dē", "dé", "dĕ", "dè",
							  "dei", "dēi", "déi", "dĕi", "dèi",
							  "deng", "dēng", "déng", "dĕng", "dèng",
							  "di","dī","dí","dĭ","dì",
							  "dian","diān","dián","diăn","diàn",
							  "diao", "diāo", "diáo", "diăo", "diào",
							  "die", "diē", "dié", "diĕ", "diè",
							  "ding","dīng","díng","dĭng","dìng",
							  "diu", "diū", "diú", "diŭ", "diù",
							  "dong", "dōng", "dóng", "dŏng", "dòng",
							  "dou", "dōu", "dóu", "dŏu", "dòu",
							  "du", "dū", "dú", "dŭ", "dù",
							  "duan", "duān", "duán", "duăn", "duàn",
							  "dui","duī","duí","duĭ","duì",
							  "duo", "duō", "duó", "duŏ", "duò",
							  "dun", "dūn", "dún", "dŭn", "dùn",
							  "ga", "gā", "gá", "gă", "gà",
							  "gan", "gān", "gán", "găn", "gàn",
							  "gang", "gāng", "gáng", "găng", "gàng",
							  "gao", "gāo", "gáo", "găo", "gào",
							  "ge", "gē", "gé", "gĕ", "gè",
							  "gei", "gēi", "géi", "gĕi", "gèi",
							  "gen", "gēn", "gén", "gĕn", "gèn",
							  "geng", "gēng", "géng", "gĕng", "gèng",
							  "gong", "gōng", "góng", "gŏng", "gòng",
							  "gou", "gōu", "góu", "gŏu", "gòu",
							  "gu", "gū", "gú", "gŭ", "gù",
							  "gua", "guā", "guá", "guă", "guà",
							  "guai","guaī","guaí","guaĭ","guaì",
							  "guan", "guān", "guán", "guăn", "guàn",
							  "guang", "guāng", "guáng", "guăng", "guàng",
							  "gui","guī","guí","guĭ","guì",
							  "guo", "guō", "guó", "guŏ", "guò",
							  "gun", "gūn", "gún", "gŭn", "gùn",
							  "ji","jī","jí","jĭ","jì",
							  "jia", "jiā", "jiá", "jiă", "jià",
							  "jian", "jiān", "jián", "jiăn", "jiàn",
							  "jiang", "jiāng", "jiáng", "jiăng", "jiàng",
							  "jiao", "jiāo", "jiáo", "jiăo", "jiào",
							  "jie", "jiē", "jié", "jiĕ", "jiè",
							  "jin","jīn","jín","jĭn","jìn",
							  "jing","jīng","jíng","jĭng","jìng",
							  "jiu", "jiū", "jiú", "jiŭ", "jiù",
							  "ju", "jū", "jú", "jŭ", "jù",
							  "juan", "juān", "juán", "juăn", "juàn",
							  "jue", "juē", "jué", "juĕ", "juè",
							  "jun", "jūn", "jún", "jŭn", "jùn",
							  "ka", "kā", "ká", "kă", "kà",
							  "kai", "kāi", "kái", "kăi", "kài",
							  "kan", "kān", "kán", "kăn", "kàn",
							  "kang", "kāng", "káng", "kăng", "kàng",
							  "kao", "kāo", "káo", "kăo", "kào",
							  "ke", "kē", "ké", "kĕ", "kè",
							  "ken", "kēn", "kén", "kĕn", "kèn",
							  "keng", "kēng", "kéng", "kĕng", "kèng",
							  "kong", "kōng", "kóng", "kŏng", "kòng",
							  "kou", "kōu", "kóu", "kŏu", "kòu",
							  "ku", "kū", "kú", "kŭ", "kù",
							  "kua", "kuā", "kuá", "kuă", "kuà",
							  "kuai", "kuāi", "kuái", "kuăi", "kuài",
							  "kuan", "kuān", "kuán", "kuăn", "kuàn",
							  "kuang", "kuāng", "kuáng", "kuăng", "kuàng",
							  "kui","kuī","kuí","kuĭ","kuì",
							  "kuo", "kuō", "kuó", "kuŏ", "kuò",
							  "pa", "pā", "pá", "pă", "pà",
							  "pai", "pāi", "pái", "păi", "pài",
							  "pan", "pān", "pán", "păn", "pàn",
							  "pang", "pāng", "páng", "păng", "pàng",
							  "pao", "pāo", "páo", "păo", "pào",
							  "pei", "pēi", "péi", "pĕi", "pèi",
							  "pen", "pēn", "pén", "pĕn", "pèn",
							  "peng", "pēng", "péng", "pĕng", "pèng",
							  "pi","pī","pí","pĭ","pì",
							  "pian", "piān", "pián", "piăn", "piàn",
							  "piao", "piāo", "piáo", "piăo", "piào",
							  "pie", "piē", "pié", "piĕ", "piè",
							  "pin","pīn","pín","pĭn","pìn",
							  "ping","pīng","píng","pĭng","pìng",
							  "po", "pō", "pó", "pŏ", "pò",
							  "pou", "pōu", "póu", "pŏu", "pòu",
							  "pu", "pū", "pú", "pŭ", "pù",
							  "qi","qī","qí","qĭ","qì",
							  "qia", "qiā", "qiá", "qiă", "qià",
							  "qian", "qiān", "qián", "qiăn", "qiàn",
							  "qiang", "qiāng", "qiáng", "qiăng", "qiàng",
							  "qiao", "qiāo", "qiáo", "qiăo", "qiào",
							  "qie", "qiē", "qié", "qiĕ", "qiè",
							  "qin","qīn","qín","qĭn","qìn",
							  "qing","qīng","qíng","qĭng","qìng",
							  "qiong", "qiōng", "qióng", "qiŏng", "qiòng",
							  "qiu", "qiū", "qiú", "qiŭ", "qiù",
							  "qu", "qū", "qú", "qŭ", "qù",
							  "quan", "quān", "quán", "quăn", "quàn",
							  "que", "quē", "qué", "quĕ", "què",
							  "qun", "qūn", "qún", "qŭn", "qùn",
							  "ta", "tā", "tá", "tă", "tà",
							  "tai", "tāi", "tái", "tăi", "tài",
							  "tan", "tān", "tán", "tăn", "tàn",
							  "tang", "tāng", "táng", "tăng", "tàng",
							  "tao", "tāo", "táo", "tăo", "tào",
							  "te", "tē", "té", "tĕ", "tè",
							  "teng", "tēng", "téng", "tĕng", "tèng",
							  "ti","tī","tí","tĭ","tì",
							  "tian","tiān","tián","tiăn","tiàn",
							  "tiao","tiāo","tiáo","tiăo","tiào",
							  "tie", "tiē", "tié", "tiĕ", "tiè",
							  "ting","tīng","tíng","tĭng","tìng",
							  "tong", "tōng", "tóng", "tŏng", "tòng",
							  "tou", "tōu", "tóu", "tŏu", "tòu",
							  "tu", "tū", "tú", "tŭ", "tù",
							  "tuan", "tuān", "tuán", "tuăn", "tuàn",
							  "tui","tuī","tuí","tuĭ","tuì",
							  "tuo", "tuō", "tuó", "tuŏ", "tuò",
							  "tun", "tūn", "tún", "tŭn", "tùn",
							  "xi","xī","xí","xĭ","xì",
							  "xia","xiā","xiá","xiă","xià",
							  "xian","xiān","xián","xiăn","xiàn",
							  "xiang","xiāng","xiáng","xiăng","xiàng",
							  "xiao","xiāo","xiáo","xiăo","xiào",
							  "xie", "xiē", "xié", "xiĕ", "xiè",
							  "xin","xīn","xín","xĭn","xìn",
							  "xing","xīng","xíng","xĭng","xìng",
							  "xiong", "xiōng", "xióng", "xiŏng", "xiòng",
							  "xiu", "xiū", "xiú", "xiŭ", "xiù",
							  "xu", "xū", "xú", "xŭ", "xù",
							  "xuan", "xuān", "xuán", "xuăn", "xuàn",
							  "xue", "xuē", "xué", "xuĕ", "xuè",
							  "xun", "xūn", "xún", "xŭn", "xùn",
							  "za", "zā", "zá", "ză", "zà",
							  "zai", "zāi", "zái", "zăi", "zài",
							  "zan", "zān", "zán", "zăn", "zàn",
							  "zang", "zāng", "záng", "zăng", "zàng",
							  "zao", "zāo", "záo", "zăo", "zào",
							  "ze", "zē", "zé", "zĕ", "zè",
							  "zei", "zēi", "zéi", "zĕi", "zèi",
							  "zen", "zēn", "zén", "zĕn", "zèn",
							  "zeng", "zēng", "zéng", "zĕng", "zèng",
							  "zi","zī","zí","zĭ","zì",
							  "zong", "zōng", "zóng", "zŏng", "zòng",
							  "zou", "zōu", "zóu", "zŏu", "zòu",
							  "zu", "zū", "zú", "zŭ", "zù",
							  "zuan", "zuān", "zuán", "zuăn", "zuàn",
							  "zui","zuī","zuí","zuĭ","zuì",
							  "zuo", "zuō", "zuó", "zuŏ", "zuò",
							  "zun", "zūn", "zún", "zŭn", "zùn",
							  "zha", "zhā", "zhá", "zhă", "zhà",
							  "zhai", "zhāi", "zhái", "zhăi", "zhài",
							  "zhan", "zhān", "zhán", "zhăn", "zhàn",
							  "zhang", "zhāng", "zháng", "zhăng", "zhàng",
							  "zhao", "zhāo", "zháo", "zhăo", "zhào",
							  "zhe", "zhē", "zhé", "zhĕ", "zhè",
							  "zhei", "zhēi", "zhéi", "zhĕi", "zhèi",
							  "zhen", "zhēn", "zhén", "zhĕn", "zhèn",
							  "zheng", "zhēng", "zhéng", "zhĕng", "zhèng",
							  "zhi","zhī","zhí","zhĭ","zhì",
							  "zhong", "zhōng", "zhóng", "zhŏng", "zhòng",
							  "zhou", "zhōu", "zhóu", "zhŏu", "zhòu",
							  "zhu", "zhū", "zhú", "zhŭ", "zhù",
							  "zhua", "zhuā", "zhuá", "zhuă", "zhuà",
							  "zhuai", "zhuāi", "zhuái", "zhuăi", "zhuài",
							  "zhuan", "zhuān", "zhuán", "zhuăn", "zhuàn",
							  "zhuang", "zhuāng", "zhuáng", "zhuăng", "zhuàng",
							  "zhui","zhuī","zhuí","zhuĭ","zhuì",
							  "zhuo", "zhuō", "zhuó", "zhuŏ", "zhuò",
							  "zhun", "zhūn", "zhún", "zhŭn", "zhùn",
						  };
			string[] Km = {
							  "fëi", "f¡i", "f¢i", "f£i", "f¤i",
							  "hëi", "h¡i", "h¢i", "h£i", "h¤i",
							  "lëi", "l¡i", "l¢i", "l£i", "l¤i",
							  "liën", "li¡n", "li¢n", "li£n", "li¤n",
							  "lië", "li¡", "li¢", "li£", "li¤",
							  "luië", "lui¡", "lui¢", "lui£", "lui¤",
							  "mëi", "m¡i", "m¢i", "m£i", "m¤i",
							  "miën", "mi¡n", "mi¢n", "mi£n", "mi¤n",
							  "mië", "mi¡", "mi¢", "mi£", "mi¤",
							  "nëi", "n¡i", "n¢i", "n£i", "n¤i",
							  "niën", "ni¡n", "ni¢n", "ni£n", "ni¤n",
							  "nuië", "nui¡", "nui¢", "nui£", "nui¤",
							  "re", "rē", "ré", "rĕ", "rè",
							  "se", "sē", "sé", "sĕ", "sè",
							  "shëi", "sh¡i", "sh¢i", "sh£i", "sh¤i",
							  "she", "shē", "shé", "shĕ", "shè",
							  "wëi", "w¡i", "w¢i", "w£i", "w¤i",
							  "yë", "y¡", "y¢", "y£", "y¤",
							  "yuiy", "yūiy", "yúiy", "yŭiy", "yùiy",
							  "yuën", "yu¡n", "yu¢n", "yu£n", "yu¤n",
							  "yuë", "yu¡", "yu¢", "yu£", "yu¤",
							  "yuin", "yūin", "yúin", "yŭin", "yùin",
							  "pa", "pā", "pá", "pă", "pà",
							  "pai", "pāi", "pái", "păi", "pài",
							  "pan", "pān", "pán", "păn", "pàn",
							  "pang", "pāng", "páng", "păng", "pàng",
							  "pao", "pāo", "páo", "păo", "pào",
							  "pëi", "p¡i", "p¢i", "p£i", "p¤i",
							  "pen", "pēn", "pén", "pĕn", "pèn",
							  "peng", "pēng", "péng", "pĕng", "pèng",
							  "pi","pī","pí","pĭ","pì",
							  "piën", "pi¡n", "pi¢n", "pi£n", "pi¤n",
							  "piao", "piāo", "piáo", "piăo", "piào",
							  "pië", "pi¡", "pi¢", "pi£", "pi¤",
							  "pin","pīn","pín","pĭn","pìn",
							  "ping","pīng","píng","pĭng","pìng",
							  "po", "pō", "pó", "pŏ", "pò",
							  "pu", "pū", "pú", "pŭ", "pù",
							  "cha", "chā", "chá", "chă", "chà",
							  "chai", "chāi", "chái", "chăi", "chài",
							  "chan", "chān", "chán", "chăn", "chàn",
							  "chang", "chāng", "cháng", "chăng", "chàng",
							  "chao", "chāo", "cháo", "chăo", "chào",
							  "che", "chē", "ché", "chĕ", "chè",
							  "chen", "chēn", "chén", "chĕn", "chèn",
							  "cheng", "chēng", "chéng", "chĕng", "chèng",
							  "che", "chē", "ché", "chĕ", "chè",
							  "chong", "chōng", "chóng", "chŏng", "chòng",
							  "chou", "chōu", "chóu", "chŏu", "chòu",
							  "chu", "chū", "chú", "chŭ", "chù",
							  "chuo", "chuō", "chuó", "chuŏ", "chuò",
							  "chun", "chūn", "chún", "chŭn", "chùn",
							  "che", "chē", "ché", "chĕ", "chè",
							  "ta", "tā", "tá", "tă", "tà",
							  "tai", "tāi", "tái", "tăi", "tài",
							  "tan", "tān", "tán", "tăn", "tàn",
							  "tang", "tāng", "táng", "tăng", "tàng",
							  "tao", "tāo", "táo", "tăo", "tào",
							  "te", "tē", "té", "tĕ", "tè",
							  "tei", "tēi", "téi", "tĕi", "tèi",
							  "teng", "tēng", "téng", "tĕng", "tèng",
							  "ti","tī","tí","tĭ","tì",
							  "tian","tīan","tían","tĭan","tìan",
							  "tiao", "tiāo", "tiáo", "tiăo", "tiào",
							  "tie", "tiē", "tié", "tiĕ", "tiè",
							  "ting","tīng","tíng","tĭng","tìng",
							  "tiu", "tiū", "tiú", "tiŭ", "tiù",
							  "tong", "tōng", "tóng", "tŏng", "tòng",
							  "tou", "tōu", "tóu", "tŏu", "tòu",
							  "tu", "tū", "tú", "tŭ", "tù",
							  "tuan", "tuān", "tuán", "tuăn", "tuàn",
							  "tui","tuī","tuí","tuĭ","tuì",
							  "tuo", "tuō", "tuó", "tuŏ", "tuò",
							  "tun", "tūn", "tún", "tŭn", "tùn",
							  "ka", "kā", "ká", "kă", "kà",
							  "kan", "kān", "kán", "kăn", "kàn",
							  "kang", "kāng", "káng", "kăng", "kàng",
							  "kao", "kāo", "káo", "kăo", "kào",
							  "ke", "kē", "ké", "kĕ", "kè",
							  "këi", "k¡i", "k¢i", "k£i", "k¤i",
							  "ken", "kēn", "kén", "kĕn", "kèn",
							  "keng", "kēng", "kéng", "kĕng", "kèng",
							  "kong", "kōng", "kóng", "kŏng", "kòng",
							  "kou", "kōu", "kóu", "kŏu", "kòu",
							  "ku", "kū", "kú", "kŭ", "kù",
							  "kua", "kuā", "kuá", "kuă", "kuà",
							  "kuai","kuaī","kuaí","kuaĭ","kuaì",
							  "kuan", "kuān", "kuán", "kuăn", "kuàn",
							  "kuang", "kuāng", "kuáng", "kuăng", "kuàng",
							  "kui","kuī","kuí","kuĭ","kuì",
							  "kuo", "kuō", "kuó", "kuŏ", "kuò",
							  "kun", "kūn", "kún", "kŭn", "kùn",
							  "ci","cī","cí","cĭ","cì",
							  "cia", "ciā", "ciá", "ciă", "cià",
							  "cian", "ciān", "cián", "ciăn", "ciàn",
							  "ciang", "ciāng", "ciáng", "ciăng", "ciàng",
							  "ciao", "ciāo", "ciáo", "ciăo", "ciào",
							  "cië", "ci¡", "ci¢", "ci£", "ci¤",
							  "cin","cīn","cín","cĭn","cìn",
							  "cing","cīng","cíng","cĭng","cìng",
							  "ciu", "ciū", "ciú", "ciŭ", "ciù",
							  "cuiy", "cūiy", "cúiy", "cŭiy", "cùiy",
							  "cuën", "cu¡n", "cu¢n", "cu£n", "cu¤n",
							  "cuë", "cu¡", "cu¢", "cu£", "cu¤",
							  "cuin", "cūin", "cúin", "cŭin", "cùin",
							  "kha", "khā", "khá", "khă", "khà",
							  "khai", "khāi", "khái", "khăi", "khài",
							  "khan", "khān", "khán", "khăn", "khàn",
							  "khang", "khāng", "kháng", "khăng", "khàng",
							  "khao", "khāo", "kháo", "khăo", "khào",
							  "khe", "khē", "khé", "khĕ", "khè",
							  "khen", "khēn", "khén", "khĕn", "khèn",
							  "kheng", "khēng", "khéng", "khĕng", "khèng",
							  "khong", "khōng", "khóng", "khŏng", "khòng",
							  "khou", "khōu", "khóu", "khŏu", "khòu",
							  "khu", "khū", "khú", "khŭ", "khù",
							  "khua", "khuā", "khuá", "khuă", "khuà",
							  "khuai", "khuāi", "khuái", "khuăi", "khuài",
							  "khuan", "khuān", "khuán", "khuăn", "khuàn",
							  "khuang", "khuāng", "khuáng", "khuăng", "khuàng",
							  "khui","khuī","khuí","khuĭ","khuì",
							  "khuo", "khuō", "khuó", "khuŏ", "khuò",
							  "pha", "phā", "phá", "phă", "phà",
							  "phai", "phāi", "phái", "phăi", "phài",
							  "phan", "phān", "phán", "phăn", "phàn",
							  "phang", "phāng", "pháng", "phăng", "phàng",
							  "phao", "phāo", "pháo", "phăo", "phào",
							  "phëi", "ph¡i", "ph¢i", "ph£i", "ph¤i",
							  "phen", "phēn", "phén", "phĕn", "phèn",
							  "pheng", "phēng", "phéng", "phĕng", "phèng",
							  "phi","phī","phí","phĭ","phì",
							  "phian", "phiān", "phián", "phiăn", "phiàn",
							  "phiao", "phiāo", "phiáo", "phiăo", "phiào",
							  "phië", "phi¡", "phi¢", "phi£", "phi¤",
							  "phin","phīn","phín","phĭn","phìn",
							  "phing","phīng","phíng","phĭng","phìng",
							  "pho", "phō", "phó", "phŏ", "phò",
							  "phou", "phōu", "phóu", "phŏu", "phòu",
							  "phu", "phū", "phú", "phŭ", "phù",
							  "chi","chī","chí","chĭ","chì",
							  "chia", "chiā", "chiá", "chiă", "chià",
							  "chian", "chiān", "chián", "chiăn", "chiàn",
							  "chiang", "chiāng", "chiáng", "chiăng", "chiàng",
							  "chiao", "chiāo", "chiáo", "chiăo", "chiào",
							  "chië", "chi¡", "chi¢", "chi£", "chi¤",
							  "chin","chīn","chín","chĭn","chìn",
							  "ching","chīng","chíng","chĭng","chìng",
							  "chiong", "chiōng", "chióng", "chiŏng", "chiòng",
							  "chiu", "chiū", "chiú", "chiŭ", "chiù",
							  "chu", "chū", "chú", "chŭ", "chù",
							  "chuan", "chuān", "chuán", "chuăn", "chuàn",
							  "chuë", "chu¡", "chu¢", "chu£", "chu¤",
							  "chun", "chūn", "chún", "chŭn", "chùn",
							  "tha", "thā", "thá", "thă", "thà",
							  "thai", "thāi", "thái", "thăi", "thài",
							  "than", "thān", "thán", "thăn", "thàn",
							  "thang", "thāng", "tháng", "thăng", "thàng",
							  "thao", "thāo", "tháo", "thăo", "thào",
							  "the", "thē", "thé", "thĕ", "thè",
							  "theng", "thēng", "théng", "thĕng", "thèng",
							  "thi","thī","thí","thĭ","thì",
							  "thian","thiān","thián","thiăn","thiàn",
							  "thiao","thiāo","thiáo","thiăo","thiào",
							  "thië", "thi¡", "thi¢", "thi£", "thi¤",
							  "thing","thīng","thíng","thĭng","thìng",
							  "thong", "thōng", "thóng", "thŏng", "thòng",
							  "thou", "thōu", "thóu", "thŏu", "thòu",
							  "thu", "thū", "thú", "thŭ", "thù",
							  "thuan", "thuān", "thuán", "thuăn", "thuàn",
							  "thui","thuī","thuí","thuĭ","thuì",
							  "thuo", "thuō", "thuó", "thuŏ", "thuò",
							  "thun", "thūn", "thún", "thŭn", "thùn",
							  "shi","shī","shí","shĭ","shì",
							  "shia","shiā","shiá","shiă","shià",
							  "shian","shiān","shián","shiăn","shiàn",
							  "shiang","shiāng","shiáng","shiăng","shiàng",
							  "shiao","shiāo","shiáo","shiăo","shiào",
							  "shië", "shi¡", "shi¢", "shi£", "shi¤",
							  "shin","shīn","shín","shĭn","shìn",
							  "shing","shīng","shíng","shĭng","shìng",
							  "shiong", "shiōng", "shióng", "shiŏng", "shiòng",
							  "shiu", "shiū", "shiú", "shiŭ", "shiù",
							  "shu", "shū", "shú", "shŭ", "shù",
							  "shuan", "shuān", "shuán", "shuăn", "shuàn",
							  "shuë", "shu¡", "shu¢", "shu£", "shu¤",
							  "shun", "shūn", "shún", "shŭn", "shùn",
							  "ca", "cā", "cá", "că", "cà",
							  "cai", "cāi", "cái", "căi", "cài",
							  "can", "cān", "cán", "căn", "càn",
							  "cang", "cāng", "cáng", "căng", "càng",
							  "cao", "cāo", "cáo", "căo", "cào",
							  "ce", "cē", "cé", "cĕ", "cè",
							  "cëi", "c¡i", "c¢i", "c£i", "c¤i",
							  "cen", "cēn", "cén", "cĕn", "cèn",
							  "ceng", "cēng", "céng", "cĕng", "cèng",
							  "ci","cī","cí","cĭ","cì",
							  "cong", "cōng", "cóng", "cŏng", "còng",
							  "cou", "cōu", "cóu", "cŏu", "còu",
							  "cu", "cū", "cú", "cŭ", "cù",
							  "cuan", "cuān", "cuán", "cuăn", "cuàn",
							  "cui","cuī","cuí","cuĭ","cuì",
							  "cuo", "cuō", "cuó", "cuŏ", "cuò",
							  "cun", "cūn", "cún", "cŭn", "cùn",
							  "ca", "cā", "cá", "că", "cà",
							  "cai", "cāi", "cái", "căi", "cài",
							  "can", "cān", "cán", "căn", "càn",
							  "cang", "cāng", "cáng", "căng", "càng",
							  "cao", "cāo", "cáo", "căo", "cào",
							  "ce", "cē", "cé", "cĕ", "cè",
							  "cëi", "c¡i", "c¢i", "c£i", "c¤i",
							  "cen", "cēn", "cén", "cĕn", "cèn",
							  "ceng", "cēng", "céng", "cĕng", "cèng",
							  "ci","cī","cí","cĭ","cì",
							  "cong", "cōng", "cóng", "cŏng", "còng",
							  "cou", "cōu", "cóu", "cŏu", "còu",
							  "cu", "cū", "cú", "cŭ", "cù",
							  "cua", "cuā", "cuá", "cuă", "cuà",
							  "cuai", "cuāi", "cuái", "cuăi", "cuài",
							  "cuan", "cuān", "cuán", "cuăn", "cuàn",
							  "cuang", "cuāng", "cuáng", "cuăng", "cuàng",
							  "cui","cuī","cuí","cuĭ","cuì",
							  "cuo", "cuō", "cuó", "cuŏ", "cuò",
							  "cun", "cūn", "cún", "cŭn", "cùn",
						  };

			input = "";

			for (int i = 0; i < Tx.Length; i++)
			{
				for (int x = 0; x < Py.Length; x++)
				{
					if (Tx[i].Contains(Py[x]))
					{
						foreach (string item in File.ReadAllLines("Excluded.lst"))
						{
							if (item.Contains(';'))
							{
								continue;
							}

							if (String.Equals(item, Tx[i], StringComparison.CurrentCultureIgnoreCase))
							{
								i++;
								break;
							}
						}
						if (Tx[i].Length > Py[x].Length)
						{
							Tx[i] = Tx[i].Replace(Py[x], Km[x]);
							continue;
						}
						else if (Tx[i].Length == Py[x].Length)
						{
							Tx[i] = Tx[i].Replace(Py[x], Km[x]);
							break;
						}
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
					if (input.Contains("ui"))
						input = input.Replace('i', 'ī');
					else if (input.Contains('a'))
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
					if (input.Contains("ui"))
						input = input.Replace('i', 'í');
					else if (input.Contains('a'))
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
					if (input.Contains("ui"))
						input = input.Replace('i', 'ĭ');
					else if (input.Contains('a'))
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
					if (input.Contains("ui"))
						input = input.Replace('i', 'ì');
					else if (input.Contains('a'))
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
