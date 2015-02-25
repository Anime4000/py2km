﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace py2km.api
{
    public class Converter
    {
		public static string PinyinToKwikMandarin(string input, bool userule)
		{
			var dict = new Dictionary<string, string>
			{
				{"fei", "fëi"},
				{"fēi", "f¡i"},
				{"féi", "f¢i"},
				{"fěi", "f£i"},
				{"fèi", "f¤i"},
				{"hei", "hëi"},
				{"hēi", "h¡i"},
				{"héi", "h¢i"},
				{"hěi", "h£i"},
				{"hèi", "h¤i"},
				{"lei", "lëi"},
				{"lēi", "l¡i"},
				{"léi", "l¢i"},
				{"lěi", "l£i"},
				{"lèi", "l¤i"},
				{"lian", "liën"},
				{"liān", "li¡n"},
				{"lián", "li¢n"},
				{"liǎn", "li£n"},
				{"liàn", "li¤n"},
				{"lie", "lië"},
				{"liē", "li¡"},
				{"lié", "li¢"},
				{"liě", "li£"},
				{"liè", "li¤"},
				{"lüe", "luië"},
				{"lüē", "lui¡"},
				{"lüé", "lui¢"},
				{"lüě", "lui£"},
				{"lüè", "lui¤"},
				{"lü", "luiy"},
				{"lǖ", "luīy"},
				{"lǘ", "luíy"},
				{"lǚ", "luǐy"},
				{"lǜ", "luìy"},
				{"mei", "mëi"},
				{"mēi", "m¡i"},
				{"méi", "m¢i"},
				{"měi", "m£i"},
				{"mèi", "m¤i"},
				{"mian", "miën"},
				{"miān", "mi¡n"},
				{"mián", "mi¢n"},
				{"miǎn", "mi£n"},
				{"miàn", "mi¤n"},
				{"mie", "mië"},
				{"miē", "mi¡"},
				{"mié", "mi¢"},
				{"miě", "mi£"},
				{"miè", "mi¤"},
				{"nei", "nëi"},
				{"nēi", "n¡i"},
				{"néi", "n¢i"},
				{"něi", "n£i"},
				{"nèi", "n¤i"},
				{"nian", "niën"},
				{"niān", "ni¡n"},
				{"nián", "ni¢n"},
				{"niǎn", "ni£n"},
				{"niàn", "ni¤n"},
				{"nü", "nuiy"},
				{"nǖ", "nuīy"},
				{"nǘ", "nuíy"},
				{"nǚ", "nuǐy"},
				{"nǜ", "nuìy"},
				{"nüe", "nuië"},
				{"nüē", "nui¡"},
				{"nüé", "nui¢"},
				{"nüě", "nui£"},
				{"nüè", "nui¤"},
				{"ri", "re"},
				{"rī", "rē"},
				{"rí", "ré"},
				{"rǐ", "rě"},
				{"rì", "rè"},
				{"si", "se"},
				{"sī", "sē"},
				{"sí", "sé"},
				{"sǐ", "sě"},
				{"sì", "sè"},
				{"shei", "shëi"},
				{"shēi", "sh¡i"},
				{"shéi", "sh¢i"},
				{"shěi", "sh£i"},
				{"shèi", "sh¤i"},
				{"shi", "she"},
				{"shī", "shē"},
				{"shí", "shé"},
				{"shǐ", "shě"},
				{"shì", "shè"},
				{"wei", "wëi"},
				{"wēi", "w¡i"},
				{"wéi", "w¢i"},
				{"wěi", "w£i"},
				{"wèi", "w¤i"},
				{"ye", "yë"},
				{"yē", "y¡"},
				{"yé", "y¢"},
				{"yě", "y£"},
				{"yè", "y¤"},
				{"yan", "yën"},
				{"yān", "y¡n"},
				{"yán", "y¢n"},
				{"yǎn", "y£n"},
				{"yàn", "y¤n"},
				{"yu", "yuiy"},
				{"yū", "yuīy"},
				{"yú", "yuíy"},
				{"yǔ", "yuǐy"},
				{"yù", "yuìy"},
				{"yuan", "yuën"},
				{"yuān", "yu¡n"},
				{"yuán", "yu¢n"},
				{"yuǎn", "yu£n"},
				{"yuàn", "yu¤n"},
				{"yue", "yuë"},
				{"yuē", "yu¡"},
				{"yué", "yu¢"},
				{"yuě", "yu£"},
				{"yuè", "yu¤"},
				{"yun", "yuin"},
				{"yūn", "yuīn"},
				{"yún", "yuín"},
				{"yǔn", "yuǐn"},
				{"yùn", "yuìn"},
				{"ba", "pa"},
				{"bā", "pā"},
				{"bá", "pá"},
				{"bǎ", "pǎ"},
				{"bà", "pà"},
				{"bai", "pai"},
				{"bāi", "pāi"},
				{"bái", "pái"},
				{"bǎi", "pǎi"},
				{"bài", "pài"},
				{"ban", "pan"},
				{"bān", "pān"},
				{"bán", "pán"},
				{"bǎn", "pǎn"},
				{"bàn", "pàn"},
				{"bang", "pang"},
				{"bāng", "pāng"},
				{"báng", "páng"},
				{"bǎng", "pǎng"},
				{"bàng", "pàng"},
				{"bao", "pao"},
				{"bāo", "pāo"},
				{"báo", "páo"},
				{"bǎo", "pǎo"},
				{"bào", "pào"},
				{"bei", "pëi"},
				{"bēi", "p¡i"},
				{"béi", "p¢i"},
				{"běi", "p£i"},
				{"bèi", "p¤i"},
				{"ben", "pen"},
				{"bēn", "pēn"},
				{"bén", "pén"},
				{"běn", "pěn"},
				{"bèn", "pèn"},
				{"beng", "peng"},
				{"bēng", "pēng"},
				{"béng", "péng"},
				{"běng", "pěng"},
				{"bèng", "pèng"},
				{"bi", "pi"},
				{"bī", "pī"},
				{"bí", "pí"},
				{"bǐ", "pǐ"},
				{"bì", "pì"},
				{"bian", "piën"},
				{"biān", "pi¡n"},
				{"bián", "pi¢n"},
				{"biǎn", "pi£n"},
				{"biàn", "pi¤n"},
				{"biao", "piao"},
				{"biāo", "piāo"},
				{"biáo", "piáo"},
				{"biǎo", "piǎo"},
				{"biào", "piào"},
				{"bie", "pië"},
				{"biē", "pi¡"},
				{"bié", "pi¢"},
				{"biě", "pi£"},
				{"biè", "pi¤"},
				{"bin", "pin"},
				{"bīn", "pīn"},
				{"bín", "pín"},
				{"bǐn", "pǐn"},
				{"bìn", "pìn"},
				{"bing", "ping"},
				{"bīng", "pīng"},
				{"bíng", "píng"},
				{"bǐng", "pǐng"},
				{"bìng", "pìng"},
				{"bo", "po"},
				{"bō", "pō"},
				{"bó", "pó"},
				{"bǒ", "pǒ"},
				{"bò", "pò"},
				{"bu", "pu"},
				{"bū", "pū"},
				{"bú", "pú"},
				{"bǔ", "pǔ"},
				{"bù", "pù"},
				{"ca", "cha"},
				{"cā", "chā"},
				{"cá", "chá"},
				{"cǎ", "chǎ"},
				{"cà", "chà"},
				{"cai", "chai"},
				{"cāi", "chāi"},
				{"cái", "chái"},
				{"cǎi", "chǎi"},
				{"cài", "chài"},
				{"can", "chan"},
				{"cān", "chān"},
				{"cán", "chán"},
				{"cǎn", "chǎn"},
				{"càn", "chàn"},
				{"cang", "chang"},
				{"cāng", "chāng"},
				{"cáng", "cháng"},
				{"cǎng", "chǎng"},
				{"càng", "chàng"},
				{"cao", "chao"},
				{"cāo", "chāo"},
				{"cáo", "cháo"},
				{"cǎo", "chǎo"},
				{"cào", "chào"},
				{"ce", "che"},
				{"cē", "chē"},
				{"cé", "ché"},
				{"cě", "chě"},
				{"cè", "chè"},
				{"cen", "chen"},
				{"cēn", "chēn"},
				{"cén", "chén"},
				{"cěn", "chěn"},
				{"cèn", "chèn"},
				{"ceng", "cheng"},
				{"cēng", "chēng"},
				{"céng", "chéng"},
				{"cěng", "chěng"},
				{"cèng", "chèng"},
				{"ci", "che"},
				{"cī", "chē"},
				{"cí", "ché"},
				{"cǐ", "chě"},
				{"cì", "chè"},
				{"cong", "chong"},
				{"cōng", "chōng"},
				{"cóng", "chóng"},
				{"cǒng", "chǒng"},
				{"còng", "chòng"},
				{"cou", "chou"},
				{"cōu", "chōu"},
				{"cóu", "chóu"},
				{"cǒu", "chǒu"},
				{"còu", "chòu"},
				{"cu", "chu"},
				{"cū", "chū"},
				{"cú", "chú"},
				{"cǔ", "chǔ"},
				{"cù", "chù"},
				{"cuo", "chuo"},
				{"cuō", "chuō"},
				{"cuó", "chuó"},
				{"cuǒ", "chuǒ"},
				{"cuò", "chuò"},
				{"cun", "chun"},
				{"cūn", "chūn"},
				{"cún", "chún"},
				{"cǔn", "chǔn"},
				{"cùn", "chùn"},
				{"chā", "çhā"}, // START
				{"chá", "çhá"},
				{"chǎ", "çhǎ"},
				{"chà", "çhà"},
				{"cha", "çha"},
				{"chāi", "çhāi"},
				{"chái", "çhái"},
				{"chǎi", "çhǎi"},
				{"chài", "çhài"},
				{"chai", "çhai"},
				{"chān", "çhān"},
				{"chán", "çhán"},
				{"chǎn", "çhǎn"},
				{"chàn", "çhàn"},
				{"chan", "çhan"},
				{"chāng", "çhāng"},
				{"cháng", "çháng"},
				{"chǎng", "çhǎng"},
				{"chàng", "çhàng"},
				{"chang", "çhang"},
				{"chāo", "çhāo"},
				{"cháo", "çháo"},
				{"chǎo", "çhǎo"},
				{"chào", "çhào"},
				{"chao", "çhao"},
				{"chē", "çhē"},
				{"ché", "çhé"},
				{"chě", "çhě"},
				{"chè", "çhè"},
				{"che", "çhe"},
				{"chēn", "çhēn"},
				{"chén", "çhén"},
				{"chěn", "çhěn"},
				{"chèn", "çhèn"},
				{"chen", "çhen"},
				{"chēng", "çhēng"},
				{"chéng", "çhéng"},
				{"chěng", "çhěng"},
				{"chèng", "çhèng"},
				{"cheng", "çheng"},
				{"chi", "çhe"},
				{"chī", "çhē"},
				{"chí", "çhé"},
				{"chǐ", "çhě"},
				{"chì", "çhè"},
				{"chōng", "çhōng"},
				{"chóng", "çhóng"},
				{"chǒng", "çhǒng"},
				{"chòng", "çhòng"},
				{"chong", "çhong"},
				{"chōu", "çhōu"},
				{"chóu", "çhóu"},
				{"chǒu", "çhǒu"},
				{"chòu", "çhòu"},
				{"chou", "çhou"},
				{"chū", "çhū"},
				{"chú", "çhú"},
				{"chǔ", "çhǔ"},
				{"chù", "çhù"},
				{"chu", "çhu"},
				{"chuān", "çhuān"},
				{"chuán", "çhuán"},
				{"chuǎn", "çhuǎn"},
				{"chuàn", "çhuàn"},
				{"chuan", "çhuan"},
				{"chuāng", "çhuāng"},
				{"chuáng", "çhuáng"},
				{"chuǎng", "çhuǎng"},
				{"chuàng", "çhuàng"},
				{"chuang", "çhuang"},
				{"chuī", "çhuī"},
				{"chuí", "çhuí"},
				{"chuǐ", "çhuǐ"},
				{"chuì", "çhuì"},
				{"chui", "çhui"}, // END
				{"da", "ta"},
				{"dā", "tā"},
				{"dá", "tá"},
				{"dǎ", "tǎ"},
				{"dà", "tà"},
				{"dai", "tai"},
				{"dāi", "tāi"},
				{"dái", "tái"},
				{"dǎi", "tǎi"},
				{"dài", "tài"},
				{"dan", "tan"},
				{"dān", "tān"},
				{"dán", "tán"},
				{"dǎn", "tǎn"},
				{"dàn", "tàn"},
				{"dang", "tang"},
				{"dāng", "tāng"},
				{"dáng", "táng"},
				{"dǎng", "tǎng"},
				{"dàng", "tàng"},
				{"dao", "tao"},
				{"dāo", "tāo"},
				{"dáo", "táo"},
				{"dǎo", "tǎo"},
				{"dào", "tào"},
				{"de", "te"},
				{"dē", "tē"},
				{"dé", "té"},
				{"dě", "tě"},
				{"dè", "tè"},
				{"dei", "tëi"},
				{"dēi", "t¡i"},
				{"déi", "t¢i"},
				{"děi", "t£i"},
				{"dèi", "t¤i"},
				{"deng", "teng"},
				{"dēng", "tēng"},
				{"déng", "téng"},
				{"děng", "těng"},
				{"dèng", "tèng"},
				{"di", "ti"},
				{"dī", "tī"},
				{"dí", "tí"},
				{"dǐ", "tǐ"},
				{"dì", "tì"},
				{"dian", "tiën"},
				{"diān", "tī¡n"},
				{"dián", "tí¢n"},
				{"diǎn", "tǐ£n"},
				{"diàn", "tì¤n"},
				{"diao", "tiao"},
				{"diāo", "tiāo"},
				{"diáo", "tiáo"},
				{"diǎo", "tiǎo"},
				{"diào", "tiào"},
				{"die", "tië"},
				{"diē", "ti¡"},
				{"dié", "ti¢"},
				{"diě", "ti£"},
				{"diè", "ti¤"},
				{"ding", "ting"},
				{"dīng", "tīng"},
				{"díng", "tíng"},
				{"dǐng", "tǐng"},
				{"dìng", "tìng"},
				{"diu", "tiu"},
				{"diū", "tiū"},
				{"diú", "tiú"},
				{"diǔ", "tiǔ"},
				{"diù", "tiù"},
				{"dong", "tong"},
				{"dōng", "tōng"},
				{"dóng", "tóng"},
				{"dǒng", "tǒng"},
				{"dòng", "tòng"},
				{"dou", "tou"},
				{"dōu", "tōu"},
				{"dóu", "tóu"},
				{"dǒu", "tǒu"},
				{"dòu", "tòu"},
				{"du", "tu"},
				{"dū", "tū"},
				{"dú", "tú"},
				{"dǔ", "tǔ"},
				{"dù", "tù"},
				{"duan", "tuan"},
				{"duān", "tuān"},
				{"duán", "tuán"},
				{"duǎn", "tuǎn"},
				{"duàn", "tuàn"},
				{"dui", "tui"},
				{"duī", "tuī"},
				{"duí", "tuí"},
				{"duǐ", "tuǐ"},
				{"duì", "tuì"},
				{"duo", "tuo"},
				{"duō", "tuō"},
				{"duó", "tuó"},
				{"duǒ", "tuǒ"},
				{"duò", "tuò"},
				{"dun", "tun"},
				{"dūn", "tūn"},
				{"dún", "tún"},
				{"dǔn", "tǔn"},
				{"dùn", "tùn"},
				{"ga", "ka"},
				{"gā", "kā"},
				{"gá", "ká"},
				{"gǎ", "kǎ"},
				{"gà", "kà"},
				{"gan", "kan"},
				{"gān", "kān"},
				{"gán", "kán"},
				{"gǎn", "kǎn"},
				{"gàn", "kàn"},
				{"gang", "kang"},
				{"gāng", "kāng"},
				{"gáng", "káng"},
				{"gǎng", "kǎng"},
				{"gàng", "kàng"},
				{"gao", "kao"},
				{"gāo", "kāo"},
				{"gáo", "káo"},
				{"gǎo", "kǎo"},
				{"gào", "kào"},
				{"ge", "ke"},
				{"gē", "kē"},
				{"gé", "ké"},
				{"gě", "kě"},
				{"gè", "kè"},
				{"gei", "këi"},
				{"gēi", "k¡i"},
				{"géi", "k¢i"},
				{"gěi", "k£i"},
				{"gèi", "k¤i"},
				{"gen", "ken"},
				{"gēn", "kēn"},
				{"gén", "kén"},
				{"gěn", "kěn"},
				{"gèn", "kèn"},
				{"geng", "keng"},
				{"gēng", "kēng"},
				{"géng", "kéng"},
				{"gěng", "kěng"},
				{"gèng", "kèng"},
				{"gong", "kong"},
				{"gōng", "kōng"},
				{"góng", "kóng"},
				{"gǒng", "kǒng"},
				{"gòng", "kòng"},
				{"gou", "kou"},
				{"gōu", "kōu"},
				{"góu", "kóu"},
				{"gǒu", "kǒu"},
				{"gòu", "kòu"},
				{"gu", "ku"},
				{"gū", "kū"},
				{"gú", "kú"},
				{"gǔ", "kǔ"},
				{"gù", "kù"},
				{"gua", "kua"},
				{"guā", "kuā"},
				{"guá", "kuá"},
				{"guǎ", "kuǎ"},
				{"guà", "kuà"},
				{"guai", "kuai"},
				{"guaī", "kuaī"},
				{"guaí", "kuaí"},
				{"guaǐ", "kuaǐ"},
				{"guaì", "kuaì"},
				{"guan", "kuan"},
				{"guān", "kuān"},
				{"guán", "kuán"},
				{"guǎn", "kuǎn"},
				{"guàn", "kuàn"},
				{"guang", "kuang"},
				{"guāng", "kuāng"},
				{"guáng", "kuáng"},
				{"guǎng", "kuǎng"},
				{"guàng", "kuàng"},
				{"gui", "kui"},
				{"guī", "kuī"},
				{"guí", "kuí"},
				{"guǐ", "kuǐ"},
				{"guì", "kuì"},
				{"guo", "kuo"},
				{"guō", "kuō"},
				{"guó", "kuó"},
				{"guǒ", "kuǒ"},
				{"guò", "kuò"},
				{"gun", "kun"},
				{"gūn", "kūn"},
				{"gún", "kún"},
				{"gǔn", "kǔn"},
				{"gùn", "kùn"},
				{"ji", "ci"},
				{"jī", "cī"},
				{"jí", "cí"},
				{"jǐ", "cǐ"},
				{"jì", "cì"},
				{"jia", "cia"},
				{"jiā", "ciā"},
				{"jiá", "ciá"},
				{"jiǎ", "ciǎ"},
				{"jià", "cià"},
				{"jian", "ciën"},
				{"jiān", "ci¡n"},
				{"jián", "ci¢n"},
				{"jiǎn", "ci£n"},
				{"jiàn", "ci¤n"},
				{"jiang", "ciang"},
				{"jiāng", "ciāng"},
				{"jiáng", "ciáng"},
				{"jiǎng", "ciǎng"},
				{"jiàng", "ciàng"},
				{"jiao", "ciao"},
				{"jiāo", "ciāo"},
				{"jiáo", "ciáo"},
				{"jiǎo", "ciǎo"},
				{"jiào", "ciào"},
				{"jie", "cië"},
				{"jiē", "ci¡"},
				{"jié", "ci¢"},
				{"jiě", "ci£"},
				{"jiè", "ci¤"},
				{"jin", "cin"},
				{"jīn", "cīn"},
				{"jín", "cín"},
				{"jǐn", "cǐn"},
				{"jìn", "cìn"},
				{"jing", "cing"},
				{"jīng", "cīng"},
				{"jíng", "cíng"},
				{"jǐng", "cǐng"},
				{"jìng", "cìng"},
				{"jiu", "ciu"},
				{"jiū", "ciū"},
				{"jiú", "ciú"},
				{"jiǔ", "ciǔ"},
				{"jiù", "ciù"},
				{"ju", "cuiy"},
				{"jū", "cuīy"},
				{"jú", "cuíy"},
				{"jǔ", "cuǐy"},
				{"jù", "cuìy"},
				{"juan", "cuën"},
				{"juān", "cu¡n"},
				{"juán", "cu¢n"},
				{"juǎn", "cu£n"},
				{"juàn", "cu¤n"},
				{"jue", "cuë"},
				{"juē", "cu¡"},
				{"jué", "cu¢"},
				{"juě", "cu£"},
				{"juè", "cu¤"},
				{"jun", "cuin"},
				{"jūn", "cūin"},
				{"jún", "cúin"},
				{"jǔn", "cǔin"},
				{"jùn", "cùin"},
				{"ka", "kha"},
				{"kā", "khā"},
				{"ká", "khá"},
				{"kǎ", "khǎ"},
				{"kà", "khà"},
				{"kai", "khai"},
				{"kāi", "khāi"},
				{"kái", "khái"},
				{"kǎi", "khǎi"},
				{"kài", "khài"},
				{"kan", "khan"},
				{"kān", "khān"},
				{"kán", "khán"},
				{"kǎn", "khǎn"},
				{"kàn", "khàn"},
				{"kang", "khang"},
				{"kāng", "khāng"},
				{"káng", "kháng"},
				{"kǎng", "khǎng"},
				{"kàng", "khàng"},
				{"kao", "khao"},
				{"kāo", "khāo"},
				{"káo", "kháo"},
				{"kǎo", "khǎo"},
				{"kào", "khào"},
				{"ke", "khe"},
				{"kē", "khē"},
				{"ké", "khé"},
				{"kě", "khě"},
				{"kè", "khè"},
				{"ken", "khen"},
				{"kēn", "khēn"},
				{"kén", "khén"},
				{"kěn", "khěn"},
				{"kèn", "khèn"},
				{"keng", "kheng"},
				{"kēng", "khēng"},
				{"kéng", "khéng"},
				{"kěng", "khěng"},
				{"kèng", "khèng"},
				{"kong", "khong"},
				{"kōng", "khōng"},
				{"kóng", "khóng"},
				{"kǒng", "khǒng"},
				{"kòng", "khòng"},
				{"kou", "khou"},
				{"kōu", "khōu"},
				{"kóu", "khóu"},
				{"kǒu", "khǒu"},
				{"kòu", "khòu"},
				{"ku", "khu"},
				{"kū", "khū"},
				{"kú", "khú"},
				{"kǔ", "khǔ"},
				{"kù", "khù"},
				{"kua", "khua"},
				{"kuā", "khuā"},
				{"kuá", "khuá"},
				{"kuǎ", "khuǎ"},
				{"kuà", "khuà"},
				{"kuai", "khuai"},
				{"kuāi", "khuāi"},
				{"kuái", "khuái"},
				{"kuǎi", "khuǎi"},
				{"kuài", "khuài"},
				{"kuan", "khuan"},
				{"kuān", "khuān"},
				{"kuán", "khuán"},
				{"kuǎn", "khuǎn"},
				{"kuàn", "khuàn"},
				{"kuang", "khuang"},
				{"kuāng", "khuāng"},
				{"kuáng", "khuáng"},
				{"kuǎng", "khuǎng"},
				{"kuàng", "khuàng"},
				{"kui", "khui"},
				{"kuī", "khuī"},
				{"kuí", "khuí"},
				{"kuǐ", "khuǐ"},
				{"kuì", "khuì"},
				{"kuo", "khuo"},
				{"kuō", "khuō"},
				{"kuó", "khuó"},
				{"kuǒ", "khuǒ"},
				{"kuò", "khuò"},
				{"pa", "pha"},
				{"pā", "phā"},
				{"pá", "phá"},
				{"pǎ", "phǎ"},
				{"pà", "phà"},
				{"pai", "phai"},
				{"pāi", "phāi"},
				{"pái", "phái"},
				{"pǎi", "phǎi"},
				{"pài", "phài"},
				{"pan", "phan"},
				{"pān", "phān"},
				{"pán", "phán"},
				{"pǎn", "phǎn"},
				{"pàn", "phàn"},
				{"pang", "phang"},
				{"pāng", "phāng"},
				{"páng", "pháng"},
				{"pǎng", "phǎng"},
				{"pàng", "phàng"},
				{"pao", "phao"},
				{"pāo", "phāo"},
				{"páo", "pháo"},
				{"pǎo", "phǎo"},
				{"pào", "phào"},
				{"pei", "phëi"},
				{"pēi", "ph¡i"},
				{"péi", "ph¢i"},
				{"pěi", "ph£i"},
				{"pèi", "ph¤i"},
				{"pen", "phen"},
				{"pēn", "phēn"},
				{"pén", "phén"},
				{"pěn", "phěn"},
				{"pèn", "phèn"},
				{"peng", "pheng"},
				{"pēng", "phēng"},
				{"péng", "phéng"},
				{"pěng", "phěng"},
				{"pèng", "phèng"},
				{"pi", "phi"},
				{"pī", "phī"},
				{"pí", "phí"},
				{"pǐ", "phǐ"},
				{"pì", "phì"},
				{"pian", "phiën"},
				{"piān", "phi¡n"},
				{"pián", "phi¢n"},
				{"piǎn", "phi£n"},
				{"piàn", "phi¤n"},
				{"piao", "phiao"},
				{"piāo", "phiāo"},
				{"piáo", "phiáo"},
				{"piǎo", "phiǎo"},
				{"piào", "phiào"},
				{"pie", "phië"},
				{"piē", "phi¡"},
				{"pié", "phi¢"},
				{"piě", "phi£"},
				{"piè", "phi¤"},
				{"pin", "phin"},
				{"pīn", "phīn"},
				{"pín", "phín"},
				{"pǐn", "phǐn"},
				{"pìn", "phìn"},
				{"ping", "phing"},
				{"pīng", "phīng"},
				{"píng", "phíng"},
				{"pǐng", "phǐng"},
				{"pìng", "phìng"},
				{"po", "pho"},
				{"pō", "phō"},
				{"pó", "phó"},
				{"pǒ", "phǒ"},
				{"pò", "phò"},
				{"pou", "phou"},
				{"pōu", "phōu"},
				{"póu", "phóu"},
				{"pǒu", "phǒu"},
				{"pòu", "phòu"},
				{"pu", "phu"},
				{"pū", "phū"},
				{"pú", "phú"},
				{"pǔ", "phǔ"},
				{"pù", "phù"},
				{"qi", "chi"},
				{"qī", "chī"},
				{"qí", "chí"},
				{"qǐ", "chǐ"},
				{"qì", "chì"},
				{"qia", "chia"},
				{"qiā", "chiā"},
				{"qiá", "chiá"},
				{"qiǎ", "chiǎ"},
				{"qià", "chià"},
				{"qian", "chiën"},
				{"qiān", "chi¡n"},
				{"qián", "chi¢n"},
				{"qiǎn", "chi£n"},
				{"qiàn", "chi¤n"},
				{"qiang", "chiang"},
				{"qiāng", "chiāng"},
				{"qiáng", "chiáng"},
				{"qiǎng", "chiǎng"},
				{"qiàng", "chiàng"},
				{"qiao", "chiao"},
				{"qiāo", "chiāo"},
				{"qiáo", "chiáo"},
				{"qiǎo", "chiǎo"},
				{"qiào", "chiào"},
				{"qie", "chië"},
				{"qiē", "chi¡"},
				{"qié", "chi¢"},
				{"qiě", "chi£"},
				{"qiè", "chi¤"},
				{"qin", "chin"},
				{"qīn", "chīn"},
				{"qín", "chín"},
				{"qǐn", "chǐn"},
				{"qìn", "chìn"},
				{"qing", "ching"},
				{"qīng", "chīng"},
				{"qíng", "chíng"},
				{"qǐng", "chǐng"},
				{"qìng", "chìng"},
				{"qiong", "chiong"},
				{"qiōng", "chiōng"},
				{"qióng", "chióng"},
				{"qiǒng", "chiǒng"},
				{"qiòng", "chiòng"},
				{"qiu", "chiu"},
				{"qiū", "chiū"},
				{"qiú", "chiú"},
				{"qiǔ", "chiǔ"},
				{"qiù", "chiù"},
				{"qu", "chuiy"},
				{"qū", "chuīy"},
				{"qú", "chuíy"},
				{"qǔ", "chuǐy"},
				{"qù", "chuìy"},
				{"quan", "chuën"},
				{"quān", "chu¡n"},
				{"quán", "chu¢n"},
				{"quǎn", "chu£n"},
				{"quàn", "chu¤n"},
				{"que", "chuë"},
				{"quē", "chu¡"},
				{"qué", "chu¢"},
				{"quě", "chu£"},
				{"què", "chu¤"},
				{"qun", "chuin"},
				{"qūn", "chuīn"},
				{"qún", "chuín"},
				{"qǔn", "chuǐn"},
				{"qùn", "chuìn"},
				{"ta", "tha"},
				{"tā", "thā"},
				{"tá", "thá"},
				{"tǎ", "thǎ"},
				{"tà", "thà"},
				{"tai", "thai"},
				{"tāi", "thāi"},
				{"tái", "thái"},
				{"tǎi", "thǎi"},
				{"tài", "thài"},
				{"tan", "than"},
				{"tān", "thān"},
				{"tán", "thán"},
				{"tǎn", "thǎn"},
				{"tàn", "thàn"},
				{"tang", "thang"},
				{"tāng", "thāng"},
				{"táng", "tháng"},
				{"tǎng", "thǎng"},
				{"tàng", "thàng"},
				{"tao", "thao"},
				{"tāo", "thāo"},
				{"táo", "tháo"},
				{"tǎo", "thǎo"},
				{"tào", "thào"},
				{"te", "the"},
				{"tē", "thē"},
				{"té", "thé"},
				{"tě", "thě"},
				{"tè", "thè"},
				{"teng", "theng"},
				{"tēng", "thēng"},
				{"téng", "théng"},
				{"těng", "thěng"},
				{"tèng", "thèng"},
				{"ti", "thi"},
				{"tī", "thī"},
				{"tí", "thí"},
				{"tǐ", "thǐ"},
				{"tì", "thì"},
				{"tian", "thiën"},
				{"tiān", "thi¡n"},
				{"tián", "thi¢n"},
				{"tiǎn", "thi£n"},
				{"tiàn", "thi¤n"},
				{"tiao", "thiao"},
				{"tiāo", "thiāo"},
				{"tiáo", "thiáo"},
				{"tiǎo", "thiǎo"},
				{"tiào", "thiào"},
				{"tie", "thië"},
				{"tiē", "thi¡"},
				{"tié", "thi¢"},
				{"tiě", "thi£"},
				{"tiè", "thi¤"},
				{"ting", "thing"},
				{"tīng", "thīng"},
				{"tíng", "thíng"},
				{"tǐng", "thǐng"},
				{"tìng", "thìng"},
				{"tong", "thong"},
				{"tōng", "thōng"},
				{"tóng", "thóng"},
				{"tǒng", "thǒng"},
				{"tòng", "thòng"},
				{"tou", "thou"},
				{"tōu", "thōu"},
				{"tóu", "thóu"},
				{"tǒu", "thǒu"},
				{"tòu", "thòu"},
				{"tu", "thu"},
				{"tū", "thū"},
				{"tú", "thú"},
				{"tǔ", "thǔ"},
				{"tù", "thù"},
				{"tuan", "thuan"},
				{"tuān", "thuān"},
				{"tuán", "thuán"},
				{"tuǎn", "thuǎn"},
				{"tuàn", "thuàn"},
				{"tui", "thui"},
				{"tuī", "thuī"},
				{"tuí", "thuí"},
				{"tuǐ", "thuǐ"},
				{"tuì", "thuì"},
				{"tuo", "thuo"},
				{"tuō", "thuō"},
				{"tuó", "thuó"},
				{"tuǒ", "thuǒ"},
				{"tuò", "thuò"},
				{"tun", "thun"},
				{"tūn", "thūn"},
				{"tún", "thún"},
				{"tǔn", "thǔn"},
				{"tùn", "thùn"},
				{"xi", "shi"},
				{"xī", "shī"},
				{"xí", "shí"},
				{"xǐ", "shǐ"},
				{"xì", "shì"},
				{"xia", "shia"},
				{"xiā", "shiā"},
				{"xiá", "shiá"},
				{"xiǎ", "shiǎ"},
				{"xià", "shià"},
				{"xian", "shiën"},
				{"xiān", "shi¡n"},
				{"xián", "shi¢n"},
				{"xiǎn", "shi£n"},
				{"xiàn", "shi¤n"},
				{"xiang", "shiang"},
				{"xiāng", "shiāng"},
				{"xiáng", "shiáng"},
				{"xiǎng", "shiǎng"},
				{"xiàng", "shiàng"},
				{"xiao", "shiao"},
				{"xiāo", "shiāo"},
				{"xiáo", "shiáo"},
				{"xiǎo", "shiǎo"},
				{"xiào", "shiào"},
				{"xie", "shië"},
				{"xiē", "shi¡"},
				{"xié", "shi¢"},
				{"xiě", "shi£"},
				{"xiè", "shi¤"},
				{"xin", "shin"},
				{"xīn", "shīn"},
				{"xín", "shín"},
				{"xǐn", "shǐn"},
				{"xìn", "shìn"},
				{"xing", "shing"},
				{"xīng", "shīng"},
				{"xíng", "shíng"},
				{"xǐng", "shǐng"},
				{"xìng", "shìng"},
				{"xiong", "shiong"},
				{"xiōng", "shiōng"},
				{"xióng", "shióng"},
				{"xiǒng", "shiǒng"},
				{"xiòng", "shiòng"},
				{"xiu", "shiu"},
				{"xiū", "shiū"},
				{"xiú", "shiú"},
				{"xiǔ", "shiǔ"},
				{"xiù", "shiù"},
				{"xu", "shuiy"},
				{"xū", "shuīy"},
				{"xú", "shuíy"},
				{"xǔ", "shuǐy"},
				{"xù", "shuìy"},
				{"xuan", "shuën"},
				{"xuān", "shu¡n"},
				{"xuán", "shu¢n"},
				{"xuǎn", "shu£n"},
				{"xuàn", "shu¤n"},
				{"xue", "shuë"},
				{"xuē", "shu¡"},
				{"xué", "shu¢"},
				{"xuě", "shu£"},
				{"xuè", "shu¤"},
				{"xun", "shuin"},
				{"xūn", "shuīn"},
				{"xún", "shuín"},
				{"xǔn", "shuǐn"},
				{"xùn", "shuìn"},
				{"za", "ca"},
				{"zā", "cā"},
				{"zá", "cá"},
				{"zǎ", "cǎ"},
				{"zà", "cà"},
				{"zai", "cai"},
				{"zāi", "cāi"},
				{"zái", "cái"},
				{"zǎi", "cǎi"},
				{"zài", "cài"},
				{"zan", "can"},
				{"zān", "cān"},
				{"zán", "cán"},
				{"zǎn", "cǎn"},
				{"zàn", "càn"},
				{"zang", "cang"},
				{"zāng", "cāng"},
				{"záng", "cáng"},
				{"zǎng", "cǎng"},
				{"zàng", "càng"},
				{"zao", "cao"},
				{"zāo", "cāo"},
				{"záo", "cáo"},
				{"zǎo", "cǎo"},
				{"zào", "cào"},
				{"ze", "ce"},
				{"zē", "cē"},
				{"zé", "cé"},
				{"zě", "cě"},
				{"zè", "cè"},
				{"zei", "cëi"},
				{"zēi", "c¡i"},
				{"zéi", "c¢i"},
				{"zěi", "c£i"},
				{"zèi", "c¤i"},
				{"zen", "cen"},
				{"zēn", "cēn"},
				{"zén", "cén"},
				{"zěn", "cěn"},
				{"zèn", "cèn"},
				{"zeng", "ceng"},
				{"zēng", "cēng"},
				{"zéng", "céng"},
				{"zěng", "cěng"},
				{"zèng", "cèng"},
				{"zi", "ce"},
				{"zī", "cē"},
				{"zí", "cé"},
				{"zǐ", "cě"},
				{"zì", "cè"},
				{"zong", "cong"},
				{"zōng", "cōng"},
				{"zóng", "cóng"},
				{"zǒng", "cǒng"},
				{"zòng", "còng"},
				{"zou", "cou"},
				{"zōu", "cōu"},
				{"zóu", "cóu"},
				{"zǒu", "cǒu"},
				{"zòu", "còu"},
				{"zu", "cu"},
				{"zū", "cū"},
				{"zú", "cú"},
				{"zǔ", "cǔ"},
				{"zù", "cù"},
				{"zuan", "cuan"},
				{"zuān", "cuān"},
				{"zuán", "cuán"},
				{"zuǎn", "cuǎn"},
				{"zuàn", "cuàn"},
				{"zui", "cui"},
				{"zuī", "cuī"},
				{"zuí", "cuí"},
				{"zuǐ", "cuǐ"},
				{"zuì", "cuì"},
				{"zuo", "cuo"},
				{"zuō", "cuō"},
				{"zuó", "cuó"},
				{"zuǒ", "cuǒ"},
				{"zuò", "cuò"},
				{"zun", "cun"},
				{"zūn", "cūn"},
				{"zún", "cún"},
				{"zǔn", "cǔn"},
				{"zùn", "cùn"},
				{"zha", "ça"}, // START
				{"zhā", "çā"},
				{"zhá", "çá"},
				{"zhǎ", "çǎ"},
				{"zhà", "çà"},
				{"zhai", "çai"},
				{"zhāi", "çāi"},
				{"zhái", "çái"},
				{"zhǎi", "çǎi"},
				{"zhài", "çài"},
				{"zhan", "çan"},
				{"zhān", "çān"},
				{"zhán", "çán"},
				{"zhǎn", "çǎn"},
				{"zhàn", "çàn"},
				{"zhang", "çang"},
				{"zhāng", "çāng"},
				{"zháng", "çáng"},
				{"zhǎng", "çǎng"},
				{"zhàng", "çàng"},
				{"zhao", "çao"},
				{"zhāo", "çāo"},
				{"zháo", "çáo"},
				{"zhǎo", "çǎo"},
				{"zhào", "çào"},
				{"zhe", "çe"},
				{"zhē", "çē"},
				{"zhé", "çé"},
				{"zhě", "çě"},
				{"zhè", "çè"},
				{"zhei", "çëi"},
				{"zhēi", "ç¡i"},
				{"zhéi", "ç¢i"},
				{"zhěi", "ç£i"},
				{"zhèi", "ç¤i"},
				{"zhen", "çen"},
				{"zhēn", "çēn"},
				{"zhén", "çén"},
				{"zhěn", "çěn"},
				{"zhèn", "çèn"},
				{"zheng", "çeng"},
				{"zhēng", "çēng"},
				{"zhéng", "çéng"},
				{"zhěng", "çěng"},
				{"zhèng", "çèng"},
				{"zhi", "çe"},
				{"zhī", "çē"},
				{"zhí", "çé"},
				{"zhǐ", "çě"},
				{"zhì", "çè"},
				{"zhong", "çong"},
				{"zhōng", "çōng"},
				{"zhóng", "çóng"},
				{"zhǒng", "çǒng"},
				{"zhòng", "çòng"},
				{"zhou", "çou"},
				{"zhōu", "çōu"},
				{"zhóu", "çóu"},
				{"zhǒu", "çǒu"},
				{"zhòu", "çòu"},
				{"zhu", "çu"},
				{"zhū", "çū"},
				{"zhú", "çú"},
				{"zhǔ", "çǔ"},
				{"zhù", "çù"},
				{"zhua", "çua"},
				{"zhuā", "çuā"},
				{"zhuá", "çuá"},
				{"zhuǎ", "çuǎ"},
				{"zhuà", "çuà"},
				{"zhuai", "çuai"},
				{"zhuāi", "çuāi"},
				{"zhuái", "çuái"},
				{"zhuǎi", "çuǎi"},
				{"zhuài", "çuài"},
				{"zhuan", "çuan"},
				{"zhuān", "çuān"},
				{"zhuán", "çuán"},
				{"zhuǎn", "çuǎn"},
				{"zhuàn", "çuàn"},
				{"zhuang", "çuang"},
				{"zhuāng", "çuāng"},
				{"zhuáng", "çuáng"},
				{"zhuǎng", "çuǎng"},
				{"zhuàng", "çuàng"},
				{"zhui", "çui"},
				{"zhuī", "çuī"},
				{"zhuí", "çuí"},
				{"zhuǐ", "çuǐ"},
				{"zhuì", "çuì"},
				{"zhuo", "çuo"},
				{"zhuō", "çuō"},
				{"zhuó", "çuó"},
				{"zhuǒ", "çuǒ"},
				{"zhuò", "çuò"},
				{"zhun", "çun"},
				{"zhūn", "çūn"},
				{"zhún", "çún"},
				{"zhǔn", "çǔn"},
				{"zhùn", "çùn"}, // END

				// Permanent Exemption, a pinyin that similar, example: 'yang' where 'yan' is detected
				{"yang", "yang"},
				{"yāng", "yāng"},
				{"yáng", "yáng"},
				{"yǎng", "yǎng"},
				{"yàng", "yàng"},

				{"tangao","tankao"},
				{"tāngāo","tānkāo"},
				{"tángáo","tánkáo"},
				{"tǎngǎo","tǎnkǎo"},
				{"tàngào","tànkào"},

				{"liang", "liang"},
				{"liāng", "liāng"},
				{"liáng", "liáng"},
				{"liǎng", "liǎng"},
				{"liàng", "liàng"},

			}.OrderByDescending(x => x.Key.Length).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

			var excl = new Dictionary<string, string>();
			foreach (var item in File.ReadAllLines("Excluded.lst"))
			{
				string t = item.ToLower();

				if (t.Contains(';'))
					continue;

				if (!excl.ContainsKey(t))
					excl.Add(t, t);
			}

			string Tx = userule ? RulesOfPinyin(input) : input;
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

				if (new[] { 'h', 'n' }.Contains(char.ToLower(Tx[pos])) && new[] { 'ǎ', 'ě', 'ǐ', 'ǒ', 'ǔ' }.Contains(char.ToLower(Tx[++pos])))
				{
					mrk = pos++;
					while (new[] { 'ǎ', 'ě', 'ǐ', 'ǒ', 'ǔ' }.Contains(char.ToLower(Tx[mrk])))
					{
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

				if ('u' == char.ToLower(Tx[pos]) && 'i' == char.ToLower(Tx[pos + 1]))
				{
					mrk = pos++;
					continue;
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

				while (new[] { '1', '2', '3', '4', '5' }.Contains(Tx[pos]))
				{
					if (max > pos + 1)
						if (new[] { '6', '7', '8', '9', '0' }.Contains(Tx[pos + 1]))
							break;

					if (new[] { '6', '7', '8', '9', '0' }.Contains(Tx[pos - 1]))
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
								pos++;
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
								pos++;
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
								pos++;
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
								pos++;
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
								pos++;
								break;
						}
					Tx[pos] = '\0';
					break;
				}

				pos++;
			}

			return new string(Tx).Replace("\0", "");
		}
    }
}
