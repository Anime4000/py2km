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
		static Dictionary<string, string> dict = new Dictionary<string, string>();
		static Dictionary<string, string> excl = new Dictionary<string, string>();

		public static void Load()
		{
			dict.Add("fei", "fëi");
			dict.Add("fēi", "f¡i");
			dict.Add("féi", "f¢i");
			dict.Add("fěi", "f£i");
			dict.Add("fèi", "f¤i");
			dict.Add("hei", "hëi");
			dict.Add("hēi", "h¡i");
			dict.Add("héi", "h¢i");
			dict.Add("hěi", "h£i");
			dict.Add("hèi", "h¤i");
			dict.Add("lei", "lëi");
			dict.Add("lēi", "l¡i");
			dict.Add("léi", "l¢i");
			dict.Add("lěi", "l£i");
			dict.Add("lèi", "l¤i");
			dict.Add("lian", "liën");
			dict.Add("liān", "li¡n");
			dict.Add("lián", "li¢n");
			dict.Add("liǎn", "li£n");
			dict.Add("liàn", "li¤n");
			dict.Add("lie", "lië");
			dict.Add("liē", "li¡");
			dict.Add("lié", "li¢");
			dict.Add("liě", "li£");
			dict.Add("liè", "li¤");
			dict.Add("lüe", "luië");
			dict.Add("lüē", "lui¡");
			dict.Add("lüé", "lui¢");
			dict.Add("lüě", "lui£");
			dict.Add("lüè", "lui¤");
			dict.Add("lü", "luiy");
			dict.Add("lǖ", "luīy");
			dict.Add("lǘ", "luíy");
			dict.Add("lǚ", "luǐy");
			dict.Add("lǜ", "luìy");
			dict.Add("mei", "mëi");
			dict.Add("mēi", "m¡i");
			dict.Add("méi", "m¢i");
			dict.Add("měi", "m£i");
			dict.Add("mèi", "m¤i");
			dict.Add("mian", "miën");
			dict.Add("miān", "mi¡n");
			dict.Add("mián", "mi¢n");
			dict.Add("miǎn", "mi£n");
			dict.Add("miàn", "mi¤n");
			dict.Add("mie", "mië");
			dict.Add("miē", "mi¡");
			dict.Add("mié", "mi¢");
			dict.Add("miě", "mi£");
			dict.Add("miè", "mi¤");
			dict.Add("nei", "nëi");
			dict.Add("nēi", "n¡i");
			dict.Add("néi", "n¢i");
			dict.Add("něi", "n£i");
			dict.Add("nèi", "n¤i");
			dict.Add("nian", "niën");
			dict.Add("niān", "ni¡n");
			dict.Add("nián", "ni¢n");
			dict.Add("niǎn", "ni£n");
			dict.Add("niàn", "ni¤n");
			dict.Add("nü", "nuiy");
			dict.Add("nǖ", "nuīy");
			dict.Add("nǘ", "nuíy");
			dict.Add("nǚ", "nuǐy");
			dict.Add("nǜ", "nuìy");
			dict.Add("nüe", "nuië");
			dict.Add("nüē", "nui¡");
			dict.Add("nüé", "nui¢");
			dict.Add("nüě", "nui£");
			dict.Add("nüè", "nui¤");
			dict.Add("ri", "re");
			dict.Add("rī", "rē");
			dict.Add("rí", "ré");
			dict.Add("rǐ", "rě");
			dict.Add("rì", "rè");
			dict.Add("si", "se");
			dict.Add("sī", "sē");
			dict.Add("sí", "sé");
			dict.Add("sǐ", "sě");
			dict.Add("sì", "sè");
			dict.Add("shei", "shëi");
			dict.Add("shēi", "sh¡i");
			dict.Add("shéi", "sh¢i");
			dict.Add("shěi", "sh£i");
			dict.Add("shèi", "sh¤i");
			dict.Add("shi", "she");
			dict.Add("shī", "shē");
			dict.Add("shí", "shé");
			dict.Add("shǐ", "shě");
			dict.Add("shì", "shè");
			dict.Add("wei", "wëi");
			dict.Add("wēi", "w¡i");
			dict.Add("wéi", "w¢i");
			dict.Add("wěi", "w£i");
			dict.Add("wèi", "w¤i");
			dict.Add("ye", "yë");
			dict.Add("yē", "y¡");
			dict.Add("yé", "y¢");
			dict.Add("yě", "y£");
			dict.Add("yè", "y¤");
			dict.Add("yan", "yën");
			dict.Add("yān", "y¡n");
			dict.Add("yán", "y¢n");
			dict.Add("yǎn", "y£n");
			dict.Add("yàn", "y¤n");
			dict.Add("yu", "yuiy");
			dict.Add("yū", "yuīy");
			dict.Add("yú", "yuíy");
			dict.Add("yǔ", "yuǐy");
			dict.Add("yù", "yuìy");
			dict.Add("yuan", "yuën");
			dict.Add("yuān", "yu¡n");
			dict.Add("yuán", "yu¢n");
			dict.Add("yuǎn", "yu£n");
			dict.Add("yuàn", "yu¤n");
			dict.Add("yue", "yuë");
			dict.Add("yuē", "yu¡");
			dict.Add("yué", "yu¢");
			dict.Add("yuě", "yu£");
			dict.Add("yuè", "yu¤");
			dict.Add("yun", "yuin");
			dict.Add("yūn", "yuīn");
			dict.Add("yún", "yuín");
			dict.Add("yǔn", "yuǐn");
			dict.Add("yùn", "yuìn");
			dict.Add("ba", "pa");
			dict.Add("bā", "pā");
			dict.Add("bá", "pá");
			dict.Add("bǎ", "pǎ");
			dict.Add("bà", "pà");
			dict.Add("bai", "pai");
			dict.Add("bāi", "pāi");
			dict.Add("bái", "pái");
			dict.Add("bǎi", "pǎi");
			dict.Add("bài", "pài");
			dict.Add("ban", "pan");
			dict.Add("bān", "pān");
			dict.Add("bán", "pán");
			dict.Add("bǎn", "pǎn");
			dict.Add("bàn", "pàn");
			dict.Add("bang", "pang");
			dict.Add("bāng", "pāng");
			dict.Add("báng", "páng");
			dict.Add("bǎng", "pǎng");
			dict.Add("bàng", "pàng");
			dict.Add("bao", "pao");
			dict.Add("bāo", "pāo");
			dict.Add("báo", "páo");
			dict.Add("bǎo", "pǎo");
			dict.Add("bào", "pào");
			dict.Add("bei", "pëi");
			dict.Add("bēi", "p¡i");
			dict.Add("béi", "p¢i");
			dict.Add("běi", "p£i");
			dict.Add("bèi", "p¤i");
			dict.Add("ben", "pen");
			dict.Add("bēn", "pēn");
			dict.Add("bén", "pén");
			dict.Add("běn", "pěn");
			dict.Add("bèn", "pèn");
			dict.Add("beng", "peng");
			dict.Add("bēng", "pēng");
			dict.Add("béng", "péng");
			dict.Add("běng", "pěng");
			dict.Add("bèng", "pèng");
			dict.Add("bi", "pi");
			dict.Add("bī", "pī");
			dict.Add("bí", "pí");
			dict.Add("bǐ", "pǐ");
			dict.Add("bì", "pì");
			dict.Add("bian", "piën");
			dict.Add("biān", "pi¡n");
			dict.Add("bián", "pi¢n");
			dict.Add("biǎn", "pi£n");
			dict.Add("biàn", "pi¤n");
			dict.Add("biao", "piao");
			dict.Add("biāo", "piāo");
			dict.Add("biáo", "piáo");
			dict.Add("biǎo", "piǎo");
			dict.Add("biào", "piào");
			dict.Add("bie", "pië");
			dict.Add("biē", "pi¡");
			dict.Add("bié", "pi¢");
			dict.Add("biě", "pi£");
			dict.Add("biè", "pi¤");
			dict.Add("bin", "pin");
			dict.Add("bīn", "pīn");
			dict.Add("bín", "pín");
			dict.Add("bǐn", "pǐn");
			dict.Add("bìn", "pìn");
			dict.Add("bing", "ping");
			dict.Add("bīng", "pīng");
			dict.Add("bíng", "píng");
			dict.Add("bǐng", "pǐng");
			dict.Add("bìng", "pìng");
			dict.Add("bo", "po");
			dict.Add("bō", "pō");
			dict.Add("bó", "pó");
			dict.Add("bǒ", "pǒ");
			dict.Add("bò", "pò");
			dict.Add("bu", "pu");
			dict.Add("bū", "pū");
			dict.Add("bú", "pú");
			dict.Add("bǔ", "pǔ");
			dict.Add("bù", "pù");
			dict.Add("ca", "cha");
			dict.Add("cā", "chā");
			dict.Add("cá", "chá");
			dict.Add("cǎ", "chǎ");
			dict.Add("cà", "chà");
			dict.Add("cai", "chai");
			dict.Add("cāi", "chāi");
			dict.Add("cái", "chái");
			dict.Add("cǎi", "chǎi");
			dict.Add("cài", "chài");
			dict.Add("can", "chan");
			dict.Add("cān", "chān");
			dict.Add("cán", "chán");
			dict.Add("cǎn", "chǎn");
			dict.Add("càn", "chàn");
			dict.Add("cang", "chang");
			dict.Add("cāng", "chāng");
			dict.Add("cáng", "cháng");
			dict.Add("cǎng", "chǎng");
			dict.Add("càng", "chàng");
			dict.Add("cao", "chao");
			dict.Add("cāo", "chāo");
			dict.Add("cáo", "cháo");
			dict.Add("cǎo", "chǎo");
			dict.Add("cào", "chào");
			dict.Add("ce", "che");
			dict.Add("cē", "chē");
			dict.Add("cé", "ché");
			dict.Add("cě", "chě");
			dict.Add("cè", "chè");
			dict.Add("cen", "chen");
			dict.Add("cēn", "chēn");
			dict.Add("cén", "chén");
			dict.Add("cěn", "chěn");
			dict.Add("cèn", "chèn");
			dict.Add("ceng", "cheng");
			dict.Add("cēng", "chēng");
			dict.Add("céng", "chéng");
			dict.Add("cěng", "chěng");
			dict.Add("cèng", "chèng");
			dict.Add("ci", "che");
			dict.Add("cī", "chē");
			dict.Add("cí", "ché");
			dict.Add("cǐ", "chě");
			dict.Add("cì", "chè");
			dict.Add("cong", "chong");
			dict.Add("cōng", "chōng");
			dict.Add("cóng", "chóng");
			dict.Add("cǒng", "chǒng");
			dict.Add("còng", "chòng");
			dict.Add("cou", "chou");
			dict.Add("cōu", "chōu");
			dict.Add("cóu", "chóu");
			dict.Add("cǒu", "chǒu");
			dict.Add("còu", "chòu");
			dict.Add("cu", "chu");
			dict.Add("cū", "chū");
			dict.Add("cú", "chú");
			dict.Add("cǔ", "chǔ");
			dict.Add("cù", "chù");
			dict.Add("cuo", "chuo");
			dict.Add("cuō", "chuō");
			dict.Add("cuó", "chuó");
			dict.Add("cuǒ", "chuǒ");
			dict.Add("cuò", "chuò");
			dict.Add("cun", "chun");
			dict.Add("cūn", "chūn");
			dict.Add("cún", "chún");
			dict.Add("cǔn", "chǔn");
			dict.Add("cùn", "chùn");
			dict.Add("chā", "çhā"); // START
			dict.Add("chá", "çhá");
			dict.Add("chǎ", "çhǎ");
			dict.Add("chà", "çhà");
			dict.Add("cha", "çha");
			dict.Add("chāi", "çhāi");
			dict.Add("chái", "çhái");
			dict.Add("chǎi", "çhǎi");
			dict.Add("chài", "çhài");
			dict.Add("chai", "çhai");
			dict.Add("chān", "çhān");
			dict.Add("chán", "çhán");
			dict.Add("chǎn", "çhǎn");
			dict.Add("chàn", "çhàn");
			dict.Add("chan", "çhan");
			dict.Add("chāng", "çhāng");
			dict.Add("cháng", "çháng");
			dict.Add("chǎng", "çhǎng");
			dict.Add("chàng", "çhàng");
			dict.Add("chang", "çhang");
			dict.Add("chāo", "çhāo");
			dict.Add("cháo", "çháo");
			dict.Add("chǎo", "çhǎo");
			dict.Add("chào", "çhào");
			dict.Add("chao", "çhao");
			dict.Add("chē", "çhē");
			dict.Add("ché", "çhé");
			dict.Add("chě", "çhě");
			dict.Add("chè", "çhè");
			dict.Add("che", "çhe");
			dict.Add("chēn", "çhēn");
			dict.Add("chén", "çhén");
			dict.Add("chěn", "çhěn");
			dict.Add("chèn", "çhèn");
			dict.Add("chen", "çhen");
			dict.Add("chēng", "çhēng");
			dict.Add("chéng", "çhéng");
			dict.Add("chěng", "çhěng");
			dict.Add("chèng", "çhèng");
			dict.Add("cheng", "çheng");
			dict.Add("chi", "çhe");
			dict.Add("chī", "çhē");
			dict.Add("chí", "çhé");
			dict.Add("chǐ", "çhě");
			dict.Add("chì", "çhè");
			dict.Add("chōng", "çhōng");
			dict.Add("chóng", "çhóng");
			dict.Add("chǒng", "çhǒng");
			dict.Add("chòng", "çhòng");
			dict.Add("chong", "çhong");
			dict.Add("chōu", "çhōu");
			dict.Add("chóu", "çhóu");
			dict.Add("chǒu", "çhǒu");
			dict.Add("chòu", "çhòu");
			dict.Add("chou", "çhou");
			dict.Add("chū", "çhū");
			dict.Add("chú", "çhú");
			dict.Add("chǔ", "çhǔ");
			dict.Add("chù", "çhù");
			dict.Add("chu", "çhu");
			dict.Add("chuān", "çhuān");
			dict.Add("chuán", "çhuán");
			dict.Add("chuǎn", "çhuǎn");
			dict.Add("chuàn", "çhuàn");
			dict.Add("chuan", "çhuan");
			dict.Add("chuāng", "çhuāng");
			dict.Add("chuáng", "çhuáng");
			dict.Add("chuǎng", "çhuǎng");
			dict.Add("chuàng", "çhuàng");
			dict.Add("chuang", "çhuang");
			dict.Add("chuī", "çhuī");
			dict.Add("chuí", "çhuí");
			dict.Add("chuǐ", "çhuǐ");
			dict.Add("chuì", "çhuì");
			dict.Add("chui", "çhui"); // END
			dict.Add("da", "ta");
			dict.Add("dā", "tā");
			dict.Add("dá", "tá");
			dict.Add("dǎ", "tǎ");
			dict.Add("dà", "tà");
			dict.Add("dai", "tai");
			dict.Add("dāi", "tāi");
			dict.Add("dái", "tái");
			dict.Add("dǎi", "tǎi");
			dict.Add("dài", "tài");
			dict.Add("dan", "tan");
			dict.Add("dān", "tān");
			dict.Add("dán", "tán");
			dict.Add("dǎn", "tǎn");
			dict.Add("dàn", "tàn");
			dict.Add("dang", "tang");
			dict.Add("dāng", "tāng");
			dict.Add("dáng", "táng");
			dict.Add("dǎng", "tǎng");
			dict.Add("dàng", "tàng");
			dict.Add("dao", "tao");
			dict.Add("dāo", "tāo");
			dict.Add("dáo", "táo");
			dict.Add("dǎo", "tǎo");
			dict.Add("dào", "tào");
			dict.Add("de", "te");
			dict.Add("dē", "tē");
			dict.Add("dé", "té");
			dict.Add("dě", "tě");
			dict.Add("dè", "tè");
			dict.Add("dei", "tëi");
			dict.Add("dēi", "t¡i");
			dict.Add("déi", "t¢i");
			dict.Add("děi", "t£i");
			dict.Add("dèi", "t¤i");
			dict.Add("deng", "teng");
			dict.Add("dēng", "tēng");
			dict.Add("déng", "téng");
			dict.Add("děng", "těng");
			dict.Add("dèng", "tèng");
			dict.Add("di", "ti");
			dict.Add("dī", "tī");
			dict.Add("dí", "tí");
			dict.Add("dǐ", "tǐ");
			dict.Add("dì", "tì");
			dict.Add("dian", "tiën");
			dict.Add("diān", "tī¡n");
			dict.Add("dián", "tí¢n");
			dict.Add("diǎn", "tǐ£n");
			dict.Add("diàn", "tì¤n");
			dict.Add("diao", "tiao");
			dict.Add("diāo", "tiāo");
			dict.Add("diáo", "tiáo");
			dict.Add("diǎo", "tiǎo");
			dict.Add("diào", "tiào");
			dict.Add("die", "tië");
			dict.Add("diē", "ti¡");
			dict.Add("dié", "ti¢");
			dict.Add("diě", "ti£");
			dict.Add("diè", "ti¤");
			dict.Add("ding", "ting");
			dict.Add("dīng", "tīng");
			dict.Add("díng", "tíng");
			dict.Add("dǐng", "tǐng");
			dict.Add("dìng", "tìng");
			dict.Add("diu", "tiu");
			dict.Add("diū", "tiū");
			dict.Add("diú", "tiú");
			dict.Add("diǔ", "tiǔ");
			dict.Add("diù", "tiù");
			dict.Add("dong", "tong");
			dict.Add("dōng", "tōng");
			dict.Add("dóng", "tóng");
			dict.Add("dǒng", "tǒng");
			dict.Add("dòng", "tòng");
			dict.Add("dou", "tou");
			dict.Add("dōu", "tōu");
			dict.Add("dóu", "tóu");
			dict.Add("dǒu", "tǒu");
			dict.Add("dòu", "tòu");
			dict.Add("du", "tu");
			dict.Add("dū", "tū");
			dict.Add("dú", "tú");
			dict.Add("dǔ", "tǔ");
			dict.Add("dù", "tù");
			dict.Add("duan", "tuan");
			dict.Add("duān", "tuān");
			dict.Add("duán", "tuán");
			dict.Add("duǎn", "tuǎn");
			dict.Add("duàn", "tuàn");
			dict.Add("dui", "tui");
			dict.Add("duī", "tuī");
			dict.Add("duí", "tuí");
			dict.Add("duǐ", "tuǐ");
			dict.Add("duì", "tuì");
			dict.Add("duo", "tuo");
			dict.Add("duō", "tuō");
			dict.Add("duó", "tuó");
			dict.Add("duǒ", "tuǒ");
			dict.Add("duò", "tuò");
			dict.Add("dun", "tun");
			dict.Add("dūn", "tūn");
			dict.Add("dún", "tún");
			dict.Add("dǔn", "tǔn");
			dict.Add("dùn", "tùn");
			dict.Add("ga", "ka");
			dict.Add("gā", "kā");
			dict.Add("gá", "ká");
			dict.Add("gǎ", "kǎ");
			dict.Add("gà", "kà");
			dict.Add("gan", "kan");
			dict.Add("gān", "kān");
			dict.Add("gán", "kán");
			dict.Add("gǎn", "kǎn");
			dict.Add("gàn", "kàn");
			dict.Add("gang", "kang");
			dict.Add("gāng", "kāng");
			dict.Add("gáng", "káng");
			dict.Add("gǎng", "kǎng");
			dict.Add("gàng", "kàng");
			dict.Add("gao", "kao");
			dict.Add("gāo", "kāo");
			dict.Add("gáo", "káo");
			dict.Add("gǎo", "kǎo");
			dict.Add("gào", "kào");
			dict.Add("ge", "ke");
			dict.Add("gē", "kē");
			dict.Add("gé", "ké");
			dict.Add("gě", "kě");
			dict.Add("gè", "kè");
			dict.Add("gei", "këi");
			dict.Add("gēi", "k¡i");
			dict.Add("géi", "k¢i");
			dict.Add("gěi", "k£i");
			dict.Add("gèi", "k¤i");
			dict.Add("gen", "ken");
			dict.Add("gēn", "kēn");
			dict.Add("gén", "kén");
			dict.Add("gěn", "kěn");
			dict.Add("gèn", "kèn");
			dict.Add("geng", "keng");
			dict.Add("gēng", "kēng");
			dict.Add("géng", "kéng");
			dict.Add("gěng", "kěng");
			dict.Add("gèng", "kèng");
			dict.Add("gong", "kong");
			dict.Add("gōng", "kōng");
			dict.Add("góng", "kóng");
			dict.Add("gǒng", "kǒng");
			dict.Add("gòng", "kòng");
			dict.Add("gou", "kou");
			dict.Add("gōu", "kōu");
			dict.Add("góu", "kóu");
			dict.Add("gǒu", "kǒu");
			dict.Add("gòu", "kòu");
			dict.Add("gu", "ku");
			dict.Add("gū", "kū");
			dict.Add("gú", "kú");
			dict.Add("gǔ", "kǔ");
			dict.Add("gù", "kù");
			dict.Add("gua", "kua");
			dict.Add("guā", "kuā");
			dict.Add("guá", "kuá");
			dict.Add("guǎ", "kuǎ");
			dict.Add("guà", "kuà");
			dict.Add("guai", "kuai");
			dict.Add("guaī", "kuaī");
			dict.Add("guaí", "kuaí");
			dict.Add("guaǐ", "kuaǐ");
			dict.Add("guaì", "kuaì");
			dict.Add("guan", "kuan");
			dict.Add("guān", "kuān");
			dict.Add("guán", "kuán");
			dict.Add("guǎn", "kuǎn");
			dict.Add("guàn", "kuàn");
			dict.Add("guang", "kuang");
			dict.Add("guāng", "kuāng");
			dict.Add("guáng", "kuáng");
			dict.Add("guǎng", "kuǎng");
			dict.Add("guàng", "kuàng");
			dict.Add("gui", "kui");
			dict.Add("guī", "kuī");
			dict.Add("guí", "kuí");
			dict.Add("guǐ", "kuǐ");
			dict.Add("guì", "kuì");
			dict.Add("guo", "kuo");
			dict.Add("guō", "kuō");
			dict.Add("guó", "kuó");
			dict.Add("guǒ", "kuǒ");
			dict.Add("guò", "kuò");
			dict.Add("gun", "kun");
			dict.Add("gūn", "kūn");
			dict.Add("gún", "kún");
			dict.Add("gǔn", "kǔn");
			dict.Add("gùn", "kùn");
			dict.Add("ji", "ci");
			dict.Add("jī", "cī");
			dict.Add("jí", "cí");
			dict.Add("jǐ", "cǐ");
			dict.Add("jì", "cì");
			dict.Add("jia", "cia");
			dict.Add("jiā", "ciā");
			dict.Add("jiá", "ciá");
			dict.Add("jiǎ", "ciǎ");
			dict.Add("jià", "cià");
			dict.Add("jian", "ciën");
			dict.Add("jiān", "ci¡n");
			dict.Add("jián", "ci¢n");
			dict.Add("jiǎn", "ci£n");
			dict.Add("jiàn", "ci¤n");
			dict.Add("jiang", "ciang");
			dict.Add("jiāng", "ciāng");
			dict.Add("jiáng", "ciáng");
			dict.Add("jiǎng", "ciǎng");
			dict.Add("jiàng", "ciàng");
			dict.Add("jiao", "ciao");
			dict.Add("jiāo", "ciāo");
			dict.Add("jiáo", "ciáo");
			dict.Add("jiǎo", "ciǎo");
			dict.Add("jiào", "ciào");
			dict.Add("jie", "cië");
			dict.Add("jiē", "ci¡");
			dict.Add("jié", "ci¢");
			dict.Add("jiě", "ci£");
			dict.Add("jiè", "ci¤");
			dict.Add("jin", "cin");
			dict.Add("jīn", "cīn");
			dict.Add("jín", "cín");
			dict.Add("jǐn", "cǐn");
			dict.Add("jìn", "cìn");
			dict.Add("jing", "cing");
			dict.Add("jīng", "cīng");
			dict.Add("jíng", "cíng");
			dict.Add("jǐng", "cǐng");
			dict.Add("jìng", "cìng");
			dict.Add("jiu", "ciu");
			dict.Add("jiū", "ciū");
			dict.Add("jiú", "ciú");
			dict.Add("jiǔ", "ciǔ");
			dict.Add("jiù", "ciù");
			dict.Add("ju", "cuiy");
			dict.Add("jū", "cuīy");
			dict.Add("jú", "cuíy");
			dict.Add("jǔ", "cuǐy");
			dict.Add("jù", "cuìy");
			dict.Add("juan", "cuën");
			dict.Add("juān", "cu¡n");
			dict.Add("juán", "cu¢n");
			dict.Add("juǎn", "cu£n");
			dict.Add("juàn", "cu¤n");
			dict.Add("jue", "cuë");
			dict.Add("juē", "cu¡");
			dict.Add("jué", "cu¢");
			dict.Add("juě", "cu£");
			dict.Add("juè", "cu¤");
			dict.Add("jun", "cuin");
			dict.Add("jūn", "cūin");
			dict.Add("jún", "cúin");
			dict.Add("jǔn", "cǔin");
			dict.Add("jùn", "cùin");
			dict.Add("ka", "kha");
			dict.Add("kā", "khā");
			dict.Add("ká", "khá");
			dict.Add("kǎ", "khǎ");
			dict.Add("kà", "khà");
			dict.Add("kai", "khai");
			dict.Add("kāi", "khāi");
			dict.Add("kái", "khái");
			dict.Add("kǎi", "khǎi");
			dict.Add("kài", "khài");
			dict.Add("kan", "khan");
			dict.Add("kān", "khān");
			dict.Add("kán", "khán");
			dict.Add("kǎn", "khǎn");
			dict.Add("kàn", "khàn");
			dict.Add("kang", "khang");
			dict.Add("kāng", "khāng");
			dict.Add("káng", "kháng");
			dict.Add("kǎng", "khǎng");
			dict.Add("kàng", "khàng");
			dict.Add("kao", "khao");
			dict.Add("kāo", "khāo");
			dict.Add("káo", "kháo");
			dict.Add("kǎo", "khǎo");
			dict.Add("kào", "khào");
			dict.Add("ke", "khe");
			dict.Add("kē", "khē");
			dict.Add("ké", "khé");
			dict.Add("kě", "khě");
			dict.Add("kè", "khè");
			dict.Add("ken", "khen");
			dict.Add("kēn", "khēn");
			dict.Add("kén", "khén");
			dict.Add("kěn", "khěn");
			dict.Add("kèn", "khèn");
			dict.Add("keng", "kheng");
			dict.Add("kēng", "khēng");
			dict.Add("kéng", "khéng");
			dict.Add("kěng", "khěng");
			dict.Add("kèng", "khèng");
			dict.Add("kong", "khong");
			dict.Add("kōng", "khōng");
			dict.Add("kóng", "khóng");
			dict.Add("kǒng", "khǒng");
			dict.Add("kòng", "khòng");
			dict.Add("kou", "khou");
			dict.Add("kōu", "khōu");
			dict.Add("kóu", "khóu");
			dict.Add("kǒu", "khǒu");
			dict.Add("kòu", "khòu");
			dict.Add("ku", "khu");
			dict.Add("kū", "khū");
			dict.Add("kú", "khú");
			dict.Add("kǔ", "khǔ");
			dict.Add("kù", "khù");
			dict.Add("kua", "khua");
			dict.Add("kuā", "khuā");
			dict.Add("kuá", "khuá");
			dict.Add("kuǎ", "khuǎ");
			dict.Add("kuà", "khuà");
			dict.Add("kuai", "khuai");
			dict.Add("kuāi", "khuāi");
			dict.Add("kuái", "khuái");
			dict.Add("kuǎi", "khuǎi");
			dict.Add("kuài", "khuài");
			dict.Add("kuan", "khuan");
			dict.Add("kuān", "khuān");
			dict.Add("kuán", "khuán");
			dict.Add("kuǎn", "khuǎn");
			dict.Add("kuàn", "khuàn");
			dict.Add("kuang", "khuang");
			dict.Add("kuāng", "khuāng");
			dict.Add("kuáng", "khuáng");
			dict.Add("kuǎng", "khuǎng");
			dict.Add("kuàng", "khuàng");
			dict.Add("kui", "khui");
			dict.Add("kuī", "khuī");
			dict.Add("kuí", "khuí");
			dict.Add("kuǐ", "khuǐ");
			dict.Add("kuì", "khuì");
			dict.Add("kuo", "khuo");
			dict.Add("kuō", "khuō");
			dict.Add("kuó", "khuó");
			dict.Add("kuǒ", "khuǒ");
			dict.Add("kuò", "khuò");
			dict.Add("pa", "pha");
			dict.Add("pā", "phā");
			dict.Add("pá", "phá");
			dict.Add("pǎ", "phǎ");
			dict.Add("pà", "phà");
			dict.Add("pai", "phai");
			dict.Add("pāi", "phāi");
			dict.Add("pái", "phái");
			dict.Add("pǎi", "phǎi");
			dict.Add("pài", "phài");
			dict.Add("pan", "phan");
			dict.Add("pān", "phān");
			dict.Add("pán", "phán");
			dict.Add("pǎn", "phǎn");
			dict.Add("pàn", "phàn");
			dict.Add("pang", "phang");
			dict.Add("pāng", "phāng");
			dict.Add("páng", "pháng");
			dict.Add("pǎng", "phǎng");
			dict.Add("pàng", "phàng");
			dict.Add("pao", "phao");
			dict.Add("pāo", "phāo");
			dict.Add("páo", "pháo");
			dict.Add("pǎo", "phǎo");
			dict.Add("pào", "phào");
			dict.Add("pei", "phëi");
			dict.Add("pēi", "ph¡i");
			dict.Add("péi", "ph¢i");
			dict.Add("pěi", "ph£i");
			dict.Add("pèi", "ph¤i");
			dict.Add("pen", "phen");
			dict.Add("pēn", "phēn");
			dict.Add("pén", "phén");
			dict.Add("pěn", "phěn");
			dict.Add("pèn", "phèn");
			dict.Add("peng", "pheng");
			dict.Add("pēng", "phēng");
			dict.Add("péng", "phéng");
			dict.Add("pěng", "phěng");
			dict.Add("pèng", "phèng");
			dict.Add("pi", "phi");
			dict.Add("pī", "phī");
			dict.Add("pí", "phí");
			dict.Add("pǐ", "phǐ");
			dict.Add("pì", "phì");
			dict.Add("pian", "phiën");
			dict.Add("piān", "phi¡n");
			dict.Add("pián", "phi¢n");
			dict.Add("piǎn", "phi£n");
			dict.Add("piàn", "phi¤n");
			dict.Add("piao", "phiao");
			dict.Add("piāo", "phiāo");
			dict.Add("piáo", "phiáo");
			dict.Add("piǎo", "phiǎo");
			dict.Add("piào", "phiào");
			dict.Add("pie", "phië");
			dict.Add("piē", "phi¡");
			dict.Add("pié", "phi¢");
			dict.Add("piě", "phi£");
			dict.Add("piè", "phi¤");
			dict.Add("pin", "phin");
			dict.Add("pīn", "phīn");
			dict.Add("pín", "phín");
			dict.Add("pǐn", "phǐn");
			dict.Add("pìn", "phìn");
			dict.Add("ping", "phing");
			dict.Add("pīng", "phīng");
			dict.Add("píng", "phíng");
			dict.Add("pǐng", "phǐng");
			dict.Add("pìng", "phìng");
			dict.Add("po", "pho");
			dict.Add("pō", "phō");
			dict.Add("pó", "phó");
			dict.Add("pǒ", "phǒ");
			dict.Add("pò", "phò");
			dict.Add("pou", "phou");
			dict.Add("pōu", "phōu");
			dict.Add("póu", "phóu");
			dict.Add("pǒu", "phǒu");
			dict.Add("pòu", "phòu");
			dict.Add("pu", "phu");
			dict.Add("pū", "phū");
			dict.Add("pú", "phú");
			dict.Add("pǔ", "phǔ");
			dict.Add("pù", "phù");
			dict.Add("qi", "chi");
			dict.Add("qī", "chī");
			dict.Add("qí", "chí");
			dict.Add("qǐ", "chǐ");
			dict.Add("qì", "chì");
			dict.Add("qia", "chia");
			dict.Add("qiā", "chiā");
			dict.Add("qiá", "chiá");
			dict.Add("qiǎ", "chiǎ");
			dict.Add("qià", "chià");
			dict.Add("qian", "chiën");
			dict.Add("qiān", "chi¡n");
			dict.Add("qián", "chi¢n");
			dict.Add("qiǎn", "chi£n");
			dict.Add("qiàn", "chi¤n");
			dict.Add("qiang", "chiang");
			dict.Add("qiāng", "chiāng");
			dict.Add("qiáng", "chiáng");
			dict.Add("qiǎng", "chiǎng");
			dict.Add("qiàng", "chiàng");
			dict.Add("qiao", "chiao");
			dict.Add("qiāo", "chiāo");
			dict.Add("qiáo", "chiáo");
			dict.Add("qiǎo", "chiǎo");
			dict.Add("qiào", "chiào");
			dict.Add("qie", "chië");
			dict.Add("qiē", "chi¡");
			dict.Add("qié", "chi¢");
			dict.Add("qiě", "chi£");
			dict.Add("qiè", "chi¤");
			dict.Add("qin", "chin");
			dict.Add("qīn", "chīn");
			dict.Add("qín", "chín");
			dict.Add("qǐn", "chǐn");
			dict.Add("qìn", "chìn");
			dict.Add("qing", "ching");
			dict.Add("qīng", "chīng");
			dict.Add("qíng", "chíng");
			dict.Add("qǐng", "chǐng");
			dict.Add("qìng", "chìng");
			dict.Add("qiong", "chiong");
			dict.Add("qiōng", "chiōng");
			dict.Add("qióng", "chióng");
			dict.Add("qiǒng", "chiǒng");
			dict.Add("qiòng", "chiòng");
			dict.Add("qiu", "chiu");
			dict.Add("qiū", "chiū");
			dict.Add("qiú", "chiú");
			dict.Add("qiǔ", "chiǔ");
			dict.Add("qiù", "chiù");
			dict.Add("qu", "chuiy");
			dict.Add("qū", "chuīy");
			dict.Add("qú", "chuíy");
			dict.Add("qǔ", "chuǐy");
			dict.Add("qù", "chuìy");
			dict.Add("quan", "chuën");
			dict.Add("quān", "chu¡n");
			dict.Add("quán", "chu¢n");
			dict.Add("quǎn", "chu£n");
			dict.Add("quàn", "chu¤n");
			dict.Add("que", "chuë");
			dict.Add("quē", "chu¡");
			dict.Add("qué", "chu¢");
			dict.Add("quě", "chu£");
			dict.Add("què", "chu¤");
			dict.Add("qun", "chuin");
			dict.Add("qūn", "chuīn");
			dict.Add("qún", "chuín");
			dict.Add("qǔn", "chuǐn");
			dict.Add("qùn", "chuìn");
			dict.Add("ta", "tha");
			dict.Add("tā", "thā");
			dict.Add("tá", "thá");
			dict.Add("tǎ", "thǎ");
			dict.Add("tà", "thà");
			dict.Add("tai", "thai");
			dict.Add("tāi", "thāi");
			dict.Add("tái", "thái");
			dict.Add("tǎi", "thǎi");
			dict.Add("tài", "thài");
			dict.Add("tan", "than");
			dict.Add("tān", "thān");
			dict.Add("tán", "thán");
			dict.Add("tǎn", "thǎn");
			dict.Add("tàn", "thàn");
			dict.Add("tang", "thang");
			dict.Add("tāng", "thāng");
			dict.Add("táng", "tháng");
			dict.Add("tǎng", "thǎng");
			dict.Add("tàng", "thàng");
			dict.Add("tao", "thao");
			dict.Add("tāo", "thāo");
			dict.Add("táo", "tháo");
			dict.Add("tǎo", "thǎo");
			dict.Add("tào", "thào");
			dict.Add("te", "the");
			dict.Add("tē", "thē");
			dict.Add("té", "thé");
			dict.Add("tě", "thě");
			dict.Add("tè", "thè");
			dict.Add("teng", "theng");
			dict.Add("tēng", "thēng");
			dict.Add("téng", "théng");
			dict.Add("těng", "thěng");
			dict.Add("tèng", "thèng");
			dict.Add("ti", "thi");
			dict.Add("tī", "thī");
			dict.Add("tí", "thí");
			dict.Add("tǐ", "thǐ");
			dict.Add("tì", "thì");
			dict.Add("tian", "thiën");
			dict.Add("tiān", "thi¡n");
			dict.Add("tián", "thi¢n");
			dict.Add("tiǎn", "thi£n");
			dict.Add("tiàn", "thi¤n");
			dict.Add("tiao", "thiao");
			dict.Add("tiāo", "thiāo");
			dict.Add("tiáo", "thiáo");
			dict.Add("tiǎo", "thiǎo");
			dict.Add("tiào", "thiào");
			dict.Add("tie", "thië");
			dict.Add("tiē", "thi¡");
			dict.Add("tié", "thi¢");
			dict.Add("tiě", "thi£");
			dict.Add("tiè", "thi¤");
			dict.Add("ting", "thing");
			dict.Add("tīng", "thīng");
			dict.Add("tíng", "thíng");
			dict.Add("tǐng", "thǐng");
			dict.Add("tìng", "thìng");
			dict.Add("tong", "thong");
			dict.Add("tōng", "thōng");
			dict.Add("tóng", "thóng");
			dict.Add("tǒng", "thǒng");
			dict.Add("tòng", "thòng");
			dict.Add("tou", "thou");
			dict.Add("tōu", "thōu");
			dict.Add("tóu", "thóu");
			dict.Add("tǒu", "thǒu");
			dict.Add("tòu", "thòu");
			dict.Add("tu", "thu");
			dict.Add("tū", "thū");
			dict.Add("tú", "thú");
			dict.Add("tǔ", "thǔ");
			dict.Add("tù", "thù");
			dict.Add("tuan", "thuan");
			dict.Add("tuān", "thuān");
			dict.Add("tuán", "thuán");
			dict.Add("tuǎn", "thuǎn");
			dict.Add("tuàn", "thuàn");
			dict.Add("tui", "thui");
			dict.Add("tuī", "thuī");
			dict.Add("tuí", "thuí");
			dict.Add("tuǐ", "thuǐ");
			dict.Add("tuì", "thuì");
			dict.Add("tuo", "thuo");
			dict.Add("tuō", "thuō");
			dict.Add("tuó", "thuó");
			dict.Add("tuǒ", "thuǒ");
			dict.Add("tuò", "thuò");
			dict.Add("tun", "thun");
			dict.Add("tūn", "thūn");
			dict.Add("tún", "thún");
			dict.Add("tǔn", "thǔn");
			dict.Add("tùn", "thùn");
			dict.Add("xi", "shi");
			dict.Add("xī", "shī");
			dict.Add("xí", "shí");
			dict.Add("xǐ", "shǐ");
			dict.Add("xì", "shì");
			dict.Add("xia", "shia");
			dict.Add("xiā", "shiā");
			dict.Add("xiá", "shiá");
			dict.Add("xiǎ", "shiǎ");
			dict.Add("xià", "shià");
			dict.Add("xian", "shiën");
			dict.Add("xiān", "shi¡n");
			dict.Add("xián", "shi¢n");
			dict.Add("xiǎn", "shi£n");
			dict.Add("xiàn", "shi¤n");
			dict.Add("xiang", "shiang");
			dict.Add("xiāng", "shiāng");
			dict.Add("xiáng", "shiáng");
			dict.Add("xiǎng", "shiǎng");
			dict.Add("xiàng", "shiàng");
			dict.Add("xiao", "shiao");
			dict.Add("xiāo", "shiāo");
			dict.Add("xiáo", "shiáo");
			dict.Add("xiǎo", "shiǎo");
			dict.Add("xiào", "shiào");
			dict.Add("xie", "shië");
			dict.Add("xiē", "shi¡");
			dict.Add("xié", "shi¢");
			dict.Add("xiě", "shi£");
			dict.Add("xiè", "shi¤");
			dict.Add("xin", "shin");
			dict.Add("xīn", "shīn");
			dict.Add("xín", "shín");
			dict.Add("xǐn", "shǐn");
			dict.Add("xìn", "shìn");
			dict.Add("xing", "shing");
			dict.Add("xīng", "shīng");
			dict.Add("xíng", "shíng");
			dict.Add("xǐng", "shǐng");
			dict.Add("xìng", "shìng");
			dict.Add("xiong", "shiong");
			dict.Add("xiōng", "shiōng");
			dict.Add("xióng", "shióng");
			dict.Add("xiǒng", "shiǒng");
			dict.Add("xiòng", "shiòng");
			dict.Add("xiu", "shiu");
			dict.Add("xiū", "shiū");
			dict.Add("xiú", "shiú");
			dict.Add("xiǔ", "shiǔ");
			dict.Add("xiù", "shiù");
			dict.Add("xu", "shuiy");
			dict.Add("xū", "shuīy");
			dict.Add("xú", "shuíy");
			dict.Add("xǔ", "shuǐy");
			dict.Add("xù", "shuìy");
			dict.Add("xuan", "shuën");
			dict.Add("xuān", "shu¡n");
			dict.Add("xuán", "shu¢n");
			dict.Add("xuǎn", "shu£n");
			dict.Add("xuàn", "shu¤n");
			dict.Add("xue", "shuë");
			dict.Add("xuē", "shu¡");
			dict.Add("xué", "shu¢");
			dict.Add("xuě", "shu£");
			dict.Add("xuè", "shu¤");
			dict.Add("xun", "shuin");
			dict.Add("xūn", "shuīn");
			dict.Add("xún", "shuín");
			dict.Add("xǔn", "shuǐn");
			dict.Add("xùn", "shuìn");
			dict.Add("za", "ca");
			dict.Add("zā", "cā");
			dict.Add("zá", "cá");
			dict.Add("zǎ", "cǎ");
			dict.Add("zà", "cà");
			dict.Add("zai", "cai");
			dict.Add("zāi", "cāi");
			dict.Add("zái", "cái");
			dict.Add("zǎi", "cǎi");
			dict.Add("zài", "cài");
			dict.Add("zan", "can");
			dict.Add("zān", "cān");
			dict.Add("zán", "cán");
			dict.Add("zǎn", "cǎn");
			dict.Add("zàn", "càn");
			dict.Add("zang", "cang");
			dict.Add("zāng", "cāng");
			dict.Add("záng", "cáng");
			dict.Add("zǎng", "cǎng");
			dict.Add("zàng", "càng");
			dict.Add("zao", "cao");
			dict.Add("zāo", "cāo");
			dict.Add("záo", "cáo");
			dict.Add("zǎo", "cǎo");
			dict.Add("zào", "cào");
			dict.Add("ze", "ce");
			dict.Add("zē", "cē");
			dict.Add("zé", "cé");
			dict.Add("zě", "cě");
			dict.Add("zè", "cè");
			dict.Add("zei", "cëi");
			dict.Add("zēi", "c¡i");
			dict.Add("zéi", "c¢i");
			dict.Add("zěi", "c£i");
			dict.Add("zèi", "c¤i");
			dict.Add("zen", "cen");
			dict.Add("zēn", "cēn");
			dict.Add("zén", "cén");
			dict.Add("zěn", "cěn");
			dict.Add("zèn", "cèn");
			dict.Add("zeng", "ceng");
			dict.Add("zēng", "cēng");
			dict.Add("zéng", "céng");
			dict.Add("zěng", "cěng");
			dict.Add("zèng", "cèng");
			dict.Add("zi", "ce");
			dict.Add("zī", "cē");
			dict.Add("zí", "cé");
			dict.Add("zǐ", "cě");
			dict.Add("zì", "cè");
			dict.Add("zong", "cong");
			dict.Add("zōng", "cōng");
			dict.Add("zóng", "cóng");
			dict.Add("zǒng", "cǒng");
			dict.Add("zòng", "còng");
			dict.Add("zou", "cou");
			dict.Add("zōu", "cōu");
			dict.Add("zóu", "cóu");
			dict.Add("zǒu", "cǒu");
			dict.Add("zòu", "còu");
			dict.Add("zu", "cu");
			dict.Add("zū", "cū");
			dict.Add("zú", "cú");
			dict.Add("zǔ", "cǔ");
			dict.Add("zù", "cù");
			dict.Add("zuan", "cuan");
			dict.Add("zuān", "cuān");
			dict.Add("zuán", "cuán");
			dict.Add("zuǎn", "cuǎn");
			dict.Add("zuàn", "cuàn");
			dict.Add("zui", "cui");
			dict.Add("zuī", "cuī");
			dict.Add("zuí", "cuí");
			dict.Add("zuǐ", "cuǐ");
			dict.Add("zuì", "cuì");
			dict.Add("zuo", "cuo");
			dict.Add("zuō", "cuō");
			dict.Add("zuó", "cuó");
			dict.Add("zuǒ", "cuǒ");
			dict.Add("zuò", "cuò");
			dict.Add("zun", "cun");
			dict.Add("zūn", "cūn");
			dict.Add("zún", "cún");
			dict.Add("zǔn", "cǔn");
			dict.Add("zùn", "cùn");
			dict.Add("zha", "ça"); // START
			dict.Add("zhā", "çā");
			dict.Add("zhá", "çá");
			dict.Add("zhǎ", "çǎ");
			dict.Add("zhà", "çà");
			dict.Add("zhai", "çai");
			dict.Add("zhāi", "çāi");
			dict.Add("zhái", "çái");
			dict.Add("zhǎi", "çǎi");
			dict.Add("zhài", "çài");
			dict.Add("zhan", "çan");
			dict.Add("zhān", "çān");
			dict.Add("zhán", "çán");
			dict.Add("zhǎn", "çǎn");
			dict.Add("zhàn", "çàn");
			dict.Add("zhang", "çang");
			dict.Add("zhāng", "çāng");
			dict.Add("zháng", "çáng");
			dict.Add("zhǎng", "çǎng");
			dict.Add("zhàng", "çàng");
			dict.Add("zhao", "çao");
			dict.Add("zhāo", "çāo");
			dict.Add("zháo", "çáo");
			dict.Add("zhǎo", "çǎo");
			dict.Add("zhào", "çào");
			dict.Add("zhe", "çe");
			dict.Add("zhē", "çē");
			dict.Add("zhé", "çé");
			dict.Add("zhě", "çě");
			dict.Add("zhè", "çè");
			dict.Add("zhei", "çëi");
			dict.Add("zhēi", "ç¡i");
			dict.Add("zhéi", "ç¢i");
			dict.Add("zhěi", "ç£i");
			dict.Add("zhèi", "ç¤i");
			dict.Add("zhen", "çen");
			dict.Add("zhēn", "çēn");
			dict.Add("zhén", "çén");
			dict.Add("zhěn", "çěn");
			dict.Add("zhèn", "çèn");
			dict.Add("zheng", "çeng");
			dict.Add("zhēng", "çēng");
			dict.Add("zhéng", "çéng");
			dict.Add("zhěng", "çěng");
			dict.Add("zhèng", "çèng");
			dict.Add("zhi", "çe");
			dict.Add("zhī", "çē");
			dict.Add("zhí", "çé");
			dict.Add("zhǐ", "çě");
			dict.Add("zhì", "çè");
			dict.Add("zhong", "çong");
			dict.Add("zhōng", "çōng");
			dict.Add("zhóng", "çóng");
			dict.Add("zhǒng", "çǒng");
			dict.Add("zhòng", "çòng");
			dict.Add("zhou", "çou");
			dict.Add("zhōu", "çōu");
			dict.Add("zhóu", "çóu");
			dict.Add("zhǒu", "çǒu");
			dict.Add("zhòu", "çòu");
			dict.Add("zhu", "çu");
			dict.Add("zhū", "çū");
			dict.Add("zhú", "çú");
			dict.Add("zhǔ", "çǔ");
			dict.Add("zhù", "çù");
			dict.Add("zhua", "çua");
			dict.Add("zhuā", "çuā");
			dict.Add("zhuá", "çuá");
			dict.Add("zhuǎ", "çuǎ");
			dict.Add("zhuà", "çuà");
			dict.Add("zhuai", "çuai");
			dict.Add("zhuāi", "çuāi");
			dict.Add("zhuái", "çuái");
			dict.Add("zhuǎi", "çuǎi");
			dict.Add("zhuài", "çuài");
			dict.Add("zhuan", "çuan");
			dict.Add("zhuān", "çuān");
			dict.Add("zhuán", "çuán");
			dict.Add("zhuǎn", "çuǎn");
			dict.Add("zhuàn", "çuàn");
			dict.Add("zhuang", "çuang");
			dict.Add("zhuāng", "çuāng");
			dict.Add("zhuáng", "çuáng");
			dict.Add("zhuǎng", "çuǎng");
			dict.Add("zhuàng", "çuàng");
			dict.Add("zhui", "çui");
			dict.Add("zhuī", "çuī");
			dict.Add("zhuí", "çuí");
			dict.Add("zhuǐ", "çuǐ");
			dict.Add("zhuì", "çuì");
			dict.Add("zhuo", "çuo");
			dict.Add("zhuō", "çuō");
			dict.Add("zhuó", "çuó");
			dict.Add("zhuǒ", "çuǒ");
			dict.Add("zhuò", "çuò");
			dict.Add("zhun", "çun");
			dict.Add("zhūn", "çūn");
			dict.Add("zhún", "çún");
			dict.Add("zhǔn", "çǔn");
			dict.Add("zhùn", "çùn"); // END

			// Permanent Exemption, a pinyin that similar, example: 'yang' where 'yan' is detected
			dict.Add("yang", "yang");
			dict.Add("yāng", "yāng");
			dict.Add("yáng", "yáng");
			dict.Add("yǎng", "yǎng");
			dict.Add("yàng", "yàng");

			dict.Add("tangao", "tankao");
			dict.Add("tāngāo", "tānkāo");
			dict.Add("tángáo", "tánkáo");
			dict.Add("tǎngǎo", "tǎnkǎo");
			dict.Add("tàngào", "tànkào");

			dict.Add("liang", "liang");
			dict.Add("liāng", "liāng");
			dict.Add("liáng", "liáng");
			dict.Add("liǎng", "liǎng");
			dict.Add("liàng", "liàng");

			foreach (var item in File.ReadAllLines("Excluded.lst"))
			{
				string t = item.ToLower();

				if (t.Contains(';'))
					continue;

				if (!excl.ContainsKey(t))
					excl.Add(t, t);
			}
		}

		public static string PinyinToKwikMandarin(string input)
		{
			string Tx = input;
			string Fi = null;

			int idx = 0;
			int pos = Tx.Length;
			int len = Tx.Length;
			while (len != 0)
			{
				string test;
				string temp = Tx.Substring(idx, len);
				if (dict.TryGetValue(temp.ToLower(), out test) || excl.TryGetValue(temp.ToLower(), out test))
				{
					if (char.IsUpper(temp[0]))
						Fi += char.ToUpper(test[0]) + test.Substring(1, test.Length - 1);
					else
						Fi += test;

					idx = pos;
					pos = Tx.Length;
					len = pos - idx;
				}
				else
				{
					len--;
					pos--;
					if (idx == pos)
					{
						Fi += Tx.Substring(pos, 1);
						idx++;
						pos = Tx.Length;
						len = pos - idx;
					}
				}
			}
			return Fi;
		}

		public static string GetDictionary(string input)
		{
			return Cedict.ToDict(input);
		}

		public static string GetExample()
		{
			return Properties.Resources.ChineseExample;
		}

		public static string HanziToPinyin(string input)
		{
			// Remove unicode notes
			input = input.Replace('。', '.');
			input = input.Replace('，', ',');
			input = input.Replace('；', ';');
			input = input.Replace('（', '(');
			input = input.Replace('）', ')');
			input = input.Replace('《', '[');
			input = input.Replace('》', ']');
			input = input.Replace('「', '[');
			input = input.Replace('」', ']');
			input = input.Replace('、', ',');
			input = input.Replace('：', ':');
			input = input.Replace('？', '?');

			return ToneToPinyin2(Cedict.ToPinyin(input));
		}

		public static string RulesOfPinyin(string input)
		{
			char[] Tx = input.ToCharArray();

			int pos = 0;
			int mrk = 0;
			int max = Tx.Length - 1;
			while (pos <= max)
			{
				if (new[] { ' ', '\r', '\n' }.Contains(Tx[pos]))
				{
					pos++;
					continue;
				}

				if (char.ToLower(Tx[pos]) == 'b' && char.ToLower(Tx[++pos]) == 'ù')
				{
					mrk = pos++;
					if (pos <= max)
						break;

					while (char.ToLower(Tx[mrk]) == 'ù')
					{
						char temp = char.ToLower(Tx[pos]);
						if (new[] { 'à', 'è', 'ì', 'ò', 'ù' }.Contains(temp))
						{
							Tx[mrk] = 'ú';
						}
						else
						{
							pos++;
						}
					}
				}

				if (char.ToLower(Tx[pos]) == 'y' && char.ToLower(Tx[++pos]) == 'ī')
				{
					mrk = pos++;
					while (char.ToLower(Tx[mrk]) == 'ī')
					{
						char temp = char.ToLower(Tx[pos]);
						if (new[] { 'à', 'è', 'ì', 'ò', 'ù' }.Contains(temp))
						{
							Tx[mrk] = 'í';
						}
						else if (new[] { 'ā', 'ē', 'ī', 'ō', 'ū', 'á', 'é', 'í', 'ó', 'ú', 'ǎ', 'ě', 'ǐ', 'ǒ', 'ǔ' }.Contains(temp))
						{
							Tx[mrk] = 'ì';
						}
						else
						{
							pos++;
						}
					}
				}

				if (max < pos + 1)
					break;

				if (new[] { 'h', 'n' }.Contains(char.ToLower(Tx[pos])) && new[] { 'ǎ', 'ě', 'ǐ', 'ǒ', 'ǔ' }.Contains(char.ToLower(Tx[++pos])))
				{
					mrk = pos++;
					while (new[] { 'ǎ', 'ě', 'ǐ', 'ǒ', 'ǔ' }.Contains(char.ToLower(Tx[mrk])))
					{
						if (pos >= max)
							break;

						char temp = char.ToLower(Tx[pos]);
						if (new[] { 'ǎ', 'ě', 'ǐ', 'ǒ', 'ǔ' }.Contains(temp))
						{
							switch (char.ToLower(Tx[mrk]))
							{
								case 'ǎ':
									Tx[mrk] = 'á';
									break;
								case 'ě':
									Tx[mrk] = 'é';
									break;
								case 'ǐ':
									Tx[mrk] = 'í';
									break;
								case 'ǒ':
									Tx[mrk] = 'ó';
									break;
								case 'ǔ':
									Tx[mrk] = 'ú';
									break;
								default:
									break;
							}
						}
						else
						{
							pos++;
						}
					}
				}
				pos++;
			}
			return new string(Tx);
		}

        public static string ToneToPinyin2(string input)
        {
            char[] Tx = input.ToLower().ToCharArray();

            int mrk = 0;
            int max = Tx.Length;

            for (int i = 0; i < max; i++)
            {
                if (new[] { 'a', 'e', 'i', 'o', 'u', 'v', '1', '2', '3', '4', '5' }.Contains(Tx[i]))
                {
                    if (new[] { 'a', 'e', 'i', 'o', 'u', 'v' }.Contains(Tx[i]))
                        mrk = i;

                    if (i + 1 < max)
                        if ('i' == Tx[i] && 'u' == char.ToLower(Tx[i + 1]))
                            mrk = i + 1;
                        else if ('u' == Tx[i] && 'i' == char.ToLower(Tx[i + 1]))
                            mrk = i + 1;

                    int n;
                    var s = Tx[i].ToString();
                    if (int.TryParse(s, out n))
                    {
                        switch (n)
                        {
                            case 1:
                                if (Tx[mrk] == 'a')
                                    Tx[mrk] = 'ā';
                                else if (Tx[mrk] == 'e')
                                    Tx[mrk] = 'ē';
                                else if (Tx[mrk] == 'i')
                                    Tx[mrk] = 'ī';
                                else if (Tx[mrk] == 'o')
                                    Tx[mrk] = 'ō';
                                else if (Tx[mrk] == 'u')
                                    Tx[mrk] = 'ū';
                                else if (Tx[mrk] == 'v')
                                    Tx[mrk] = 'ǖ';

                                Tx[i] = ' ';
                                break;
                            case 2:
                                if (Tx[mrk] == 'a')
                                    Tx[mrk] = 'á';
                                else if (Tx[mrk] == 'e')
                                    Tx[mrk] = 'é';
                                else if (Tx[mrk] == 'i')
                                    Tx[mrk] = 'í';
                                else if (Tx[mrk] == 'o')
                                    Tx[mrk] = 'ó';
                                else if (Tx[mrk] == 'u')
                                    Tx[mrk] = 'ú';
                                else if (Tx[mrk] == 'v')
                                    Tx[mrk] = 'ǘ';

                                Tx[i] = ' ';
                                break;
                            case 3:
                                if (Tx[mrk] == 'a')
                                    Tx[mrk] = 'ǎ';
                                else if (Tx[mrk] == 'e')
                                    Tx[mrk] = 'ě';
                                else if (Tx[mrk] == 'i')
                                    Tx[mrk] = 'ǐ';
                                else if (Tx[mrk] == 'o')
                                    Tx[mrk] = 'ǒ';
                                else if (Tx[mrk] == 'u')
                                    Tx[mrk] = 'ǔ';
                                else if (Tx[mrk] == 'v')
                                    Tx[mrk] = 'ǚ';

                                Tx[i] = ' ';
                                break;
                            case 4:
                                if (Tx[mrk] == 'a')
                                    Tx[mrk] = 'à';
                                else if (Tx[mrk] == 'e')
                                    Tx[mrk] = 'è';
                                else if (Tx[mrk] == 'i')
                                    Tx[mrk] = 'ì';
                                else if (Tx[mrk] == 'o')
                                    Tx[mrk] = 'ò';
                                else if (Tx[mrk] == 'u')
                                    Tx[mrk] = 'ù';
                                else if (Tx[mrk] == 'v')
                                    Tx[mrk] = 'ǜ';

                                Tx[i] = ' ';
                                break;
                            case 5:
                                if (Tx[mrk] == 'v')
                                    Tx[mrk] = 'ü';

                                Tx[i] = ' ';
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return new string(Tx);
        }

		public static string ToneToPinyin(string input)
		{
			char[] Tx = input.ToCharArray();

			int pos = 0;
			int mrk = 0;
			int max = Tx.Length;

			while (pos != max)
			{
				if (new[] { ' ', '\n', '\r' }.Contains(Tx[pos]))
				{
					pos++;
					continue;
				}

				if (mrk == 0)
				{
					if ('i' == char.ToLower(Tx[pos]))
					{
						if ('u' == char.ToLower(Tx[pos + 1]))
						{
							mrk = pos++ + 1; // mark u (ahead)
							continue;
						}
					}
					else if ('u' == char.ToLower(Tx[pos]))
					{
						if ('i' == char.ToLower(Tx[pos + 1]))
						{
							mrk = pos++ + 1; // mark i (ahead)
							continue;
						}
					}
					else if ('a' == char.ToLower(Tx[pos]))
					{
						mrk = pos++;
						continue;
					}
					else if ('e' == char.ToLower(Tx[pos]))
					{
						mrk = pos++;
						continue;
					}
					else if ('o' == char.ToLower(Tx[pos]))
					{
						mrk = pos++;
						continue;
					}
					else if ('u' == char.ToLower(Tx[pos]))
					{
						mrk = pos++;
						continue;
					}
					else if ('i' == char.ToLower(Tx[pos]))
					{
						mrk = pos++;
						continue;
					}
                    else if ('v' == char.ToLower(Tx[pos]))
                    {
                        mrk = pos++;
                        continue;
                    }
				}

				while (new[] { '1', '2', '3', '4' }.Contains(Tx[pos]))
				{
					if (max <= 1)
						break;

					if (max > pos + 1)
						if (new[] { '5', '6', '7', '8', '9', '0' }.Contains(Tx[pos + 1]))
							break;

					if (max < pos - 1)
						if (new[] { '5', '6', '7', '8', '9', '0' }.Contains(Tx[pos - 1]))
							break;

					if ('a' == Tx[mrk])
						switch (Tx[pos])
						{
							case '1':
								Tx[mrk] = 'ā';
								break;
							case '2':
								Tx[mrk] = 'á';
								break;
							case '3':
								Tx[mrk] = 'ǎ';
								break;
							case '4':
								Tx[mrk] = 'à';
								break;
							default:
								break;
						}
					else if ('e' == Tx[mrk])
						switch (Tx[pos])
						{
							case '1':
								Tx[mrk] = 'ē';
								break;
							case '2':
								Tx[mrk] = 'é';
								break;
							case '3':
								Tx[mrk] = 'ě';
								break;
							case '4':
								Tx[mrk] = 'è';
								break;
							default:
								break;
						}
					else if ('u' == Tx[mrk])
						switch (Tx[pos])
						{
							case '1':
								Tx[mrk] = 'ū';
								break;
							case '2':
								Tx[mrk] = 'ú';
								break;
							case '3':
								Tx[mrk] = 'ǔ';
								break;
							case '4':
								Tx[mrk] = 'ù';
								break;
							default:
								break;
						}
					else if ('i' == Tx[mrk])
						switch (Tx[pos])
						{
							case '1':
								Tx[mrk] = 'ī';
								break;
							case '2':
								Tx[mrk] = 'í';
								break;
							case '3':
								Tx[mrk] = 'ǐ';
								break;
							case '4':
								Tx[mrk] = 'ì';
								break;
							default:
								break;
						}
					else if ('o' == Tx[mrk])
						switch (Tx[pos])
						{
							case '1':
								Tx[mrk] = 'ō';
								break;
							case '2':
								Tx[mrk] = 'ó';
								break;
							case '3':
								Tx[mrk] = 'ǒ';
								break;
							case '4':
								Tx[mrk] = 'ò';
								break;
							default:
								break;
						}
                    else if ('v' == Tx[mrk])
                        switch (Tx[pos])
                        {
                            case '1':
                                Tx[mrk] = 'ǖ';
                                break;
                            case '2':
                                Tx[mrk] = 'ǘ';
                                break;
                            case '3':
                                Tx[mrk] = 'ǚ';
                                break;
                            case '4':
                                Tx[mrk] = 'ǜ';
                                break;
                            default:
                                Tx[mrk] = 'ü';
                                break;
                        }
					mrk = 0; // reset when found
					Tx[pos] = '\0'; // remove pinyin tone number
					break;
				}
				pos++;
			}
			return new string(Tx).Replace("\0", string.Empty);
		}
    }
}