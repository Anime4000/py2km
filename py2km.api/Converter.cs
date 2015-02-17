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
		public static string PinyinToKwikMandarin(string input)
		{
			var dict = new Dictionary<string, string>
			{
				{"fei", "fëi"},
				{"fēi", "f¡i"},
				{"féi", "f¢i"},
				{"fĕi", "f£i"},
				{"fèi", "f¤i"},
				{"hei", "hëi"},
				{"hēi", "h¡i"},
				{"héi", "h¢i"},
				{"hĕi", "h£i"},
				{"hèi", "h¤i"},
				{"lei", "lëi"},
				{"lēi", "l¡i"},
				{"léi", "l¢i"},
				{"lĕi", "l£i"},
				{"lèi", "l¤i"},
				{"lian", "liën"},
				{"liān", "li¡n"},
				{"lián", "li¢n"},
				{"liăn", "li£n"},
				{"liàn", "li¤n"},
				{"lie", "lië"},
				{"liē", "li¡"},
				{"lié", "li¢"},
				{"liĕ", "li£"},
				{"liè", "li¤"},
				{"lüe", "luië"},
				{"lüē", "lui¡"},
				{"lüé", "lui¢"},
				{"lüĕ", "lui£"},
				{"lüè", "lui¤"},
				{"lü", "luiy"},
				{"lǖ", "luīy"},
				{"lǘ", "luíy"},
				{"lǚ", "luĭy"},
				{"lǜ", "luìy"},
				{"mei", "mëi"},
				{"mēi", "m¡i"},
				{"méi", "m¢i"},
				{"mĕi", "m£i"},
				{"mèi", "m¤i"},
				{"mian", "miën"},
				{"miān", "mi¡n"},
				{"mián", "mi¢n"},
				{"miăn", "mi£n"},
				{"miàn", "mi¤n"},
				{"mie", "mië"},
				{"miē", "mi¡"},
				{"mié", "mi¢"},
				{"miĕ", "mi£"},
				{"miè", "mi¤"},
				{"nei", "nëi"},
				{"nēi", "n¡i"},
				{"néi", "n¢i"},
				{"nĕi", "n£i"},
				{"nèi", "n¤i"},
				{"nian", "niën"},
				{"niān", "ni¡n"},
				{"nián", "ni¢n"},
				{"niăn", "ni£n"},
				{"niàn", "ni¤n"},
				{"nü", "nuiy"},
				{"nǖ", "nuīy"},
				{"nǘ", "nuíy"},
				{"nǚ", "nuĭy"},
				{"nǜ", "nuìy"},
				{"nüe", "nuië"},
				{"nüē", "nui¡"},
				{"nüé", "nui¢"},
				{"nüĕ", "nui£"},
				{"nüè", "nui¤"},
				{"ri", "re"},
				{"rī", "rē"},
				{"rí", "ré"},
				{"rĭ", "rĕ"},
				{"rì", "rè"},
				{"si", "se"},
				{"sī", "sē"},
				{"sí", "sé"},
				{"sĭ", "sĕ"},
				{"sì", "sè"},
				{"shei", "shëi"},
				{"shēi", "sh¡i"},
				{"shéi", "sh¢i"},
				{"shĕi", "sh£i"},
				{"shèi", "sh¤i"},
				{"shi", "she"},
				{"shī", "shē"},
				{"shí", "shé"},
				{"shĭ", "shĕ"},
				{"shì", "shè"},
				{"wei", "wëi"},
				{"wēi", "w¡i"},
				{"wéi", "w¢i"},
				{"wĕi", "w£i"},
				{"wèi", "w¤i"},
				{"ye", "yë"},
				{"yē", "y¡"},
				{"yé", "y¢"},
				{"yĕ", "y£"},
				{"yè", "y¤"},
				{"yan", "yën"},
				{"yān", "y¡n"},
				{"yán", "y¢n"},
				{"yăn", "y£n"},
				{"yàn", "y¤n"},
				{"yu", "yuiy"},
				{"yū", "yuīy"},
				{"yú", "yuíy"},
				{"yŭ", "yuĭy"},
				{"yù", "yuìy"},
				{"yuan", "yuën"},
				{"yuān", "yu¡n"},
				{"yuán", "yu¢n"},
				{"yuăn", "yu£n"},
				{"yuàn", "yu¤n"},
				{"yue", "yuë"},
				{"yuē", "yu¡"},
				{"yué", "yu¢"},
				{"yuĕ", "yu£"},
				{"yuè", "yu¤"},
				{"yun", "yuin"},
				{"yūn", "yuīn"},
				{"yún", "yuín"},
				{"yŭn", "yuĭn"},
				{"yùn", "yuìn"},
				{"ba", "pa"},
				{"bā", "pā"},
				{"bá", "pá"},
				{"bă", "pă"},
				{"bà", "pà"},
				{"bai", "pai"},
				{"bāi", "pāi"},
				{"bái", "pái"},
				{"băi", "păi"},
				{"bài", "pài"},
				{"ban", "pan"},
				{"bān", "pān"},
				{"bán", "pán"},
				{"băn", "păn"},
				{"bàn", "pàn"},
				{"bang", "pang"},
				{"bāng", "pāng"},
				{"báng", "páng"},
				{"băng", "păng"},
				{"bàng", "pàng"},
				{"bao", "pao"},
				{"bāo", "pāo"},
				{"báo", "páo"},
				{"băo", "păo"},
				{"bào", "pào"},
				{"bei", "pëi"},
				{"bēi", "p¡i"},
				{"béi", "p¢i"},
				{"bĕi", "p£i"},
				{"bèi", "p¤i"},
				{"ben", "pen"},
				{"bēn", "pēn"},
				{"bén", "pén"},
				{"bĕn", "pĕn"},
				{"bèn", "pèn"},
				{"beng", "peng"},
				{"bēng", "pēng"},
				{"béng", "péng"},
				{"bĕng", "pĕng"},
				{"bèng", "pèng"},
				{"bi", "pi"},
				{"bī", "pī"},
				{"bí", "pí"},
				{"bĭ", "pĭ"},
				{"bì", "pì"},
				{"bian", "piën"},
				{"bīan", "pi¡n"},
				{"bían", "pi¢n"},
				{"bĭan", "pi£n"},
				{"bìan", "pi¤n"},
				{"biao", "piao"},
				{"biāo", "piāo"},
				{"biáo", "piáo"},
				{"biăo", "piăo"},
				{"biào", "piào"},
				{"bie", "pië"},
				{"biē", "pi¡"},
				{"bié", "pi¢"},
				{"biĕ", "pi£"},
				{"biè", "pi¤"},
				{"bin", "pin"},
				{"bīn", "pīn"},
				{"bín", "pín"},
				{"bĭn", "pĭn"},
				{"bìn", "pìn"},
				{"bing", "ping"},
				{"bīng", "pīng"},
				{"bíng", "píng"},
				{"bĭng", "pĭng"},
				{"bìng", "pìng"},
				{"bo", "po"},
				{"bō", "pō"},
				{"bó", "pó"},
				{"bŏ", "pŏ"},
				{"bò", "pò"},
				{"bu", "pu"},
				{"bū", "pū"},
				{"bú", "pú"},
				{"bŭ", "pŭ"},
				{"bù", "pù"},
				{"ca", "cha"},
				{"cā", "chā"},
				{"cá", "chá"},
				{"că", "chă"},
				{"cà", "chà"},
				{"cai", "chai"},
				{"cāi", "chāi"},
				{"cái", "chái"},
				{"căi", "chăi"},
				{"cài", "chài"},
				{"can", "chan"},
				{"cān", "chān"},
				{"cán", "chán"},
				{"căn", "chăn"},
				{"càn", "chàn"},
				{"cang", "chang"},
				{"cāng", "chāng"},
				{"cáng", "cháng"},
				{"căng", "chăng"},
				{"càng", "chàng"},
				{"cao", "chao"},
				{"cāo", "chāo"},
				{"cáo", "cháo"},
				{"căo", "chăo"},
				{"cào", "chào"},
				{"ce", "che"},
				{"cē", "chē"},
				{"cé", "ché"},
				{"cĕ", "chĕ"},
				{"cè", "chè"},
				{"cen", "chen"},
				{"cēn", "chēn"},
				{"cén", "chén"},
				{"cĕn", "chĕn"},
				{"cèn", "chèn"},
				{"ceng", "cheng"},
				{"cēng", "chēng"},
				{"céng", "chéng"},
				{"cĕng", "chĕng"},
				{"cèng", "chèng"},
				{"ci", "che"},
				{"cī", "chē"},
				{"cí", "ché"},
				{"cĭ", "chĕ"},
				{"cì", "chè"},
				{"cong", "chong"},
				{"cōng", "chōng"},
				{"cóng", "chóng"},
				{"cŏng", "chŏng"},
				{"còng", "chòng"},
				{"cou", "chou"},
				{"cōu", "chōu"},
				{"cóu", "chóu"},
				{"cŏu", "chŏu"},
				{"còu", "chòu"},
				{"cu", "chu"},
				{"cū", "chū"},
				{"cú", "chú"},
				{"cŭ", "chŭ"},
				{"cù", "chù"},
				{"cuo", "chuo"},
				{"cuō", "chuō"},
				{"cuó", "chuó"},
				{"cuŏ", "chuŏ"},
				{"cuò", "chuò"},
				{"cun", "chun"},
				{"cūn", "chūn"},
				{"cún", "chún"},
				{"cŭn", "chŭn"},
				{"cùn", "chùn"},
				{"chi", "che"},
				{"chī", "chē"},
				{"chí", "ché"},
				{"chĭ", "chĕ"},
				{"chì", "chè"},
				{"da", "ta"},
				{"dā", "tā"},
				{"dá", "tá"},
				{"dă", "tă"},
				{"dà", "tà"},
				{"dai", "tai"},
				{"dāi", "tāi"},
				{"dái", "tái"},
				{"dăi", "tăi"},
				{"dài", "tài"},
				{"dan", "tan"},
				{"dān", "tān"},
				{"dán", "tán"},
				{"dăn", "tăn"},
				{"dàn", "tàn"},
				{"dang", "tang"},
				{"dāng", "tāng"},
				{"dáng", "táng"},
				{"dăng", "tăng"},
				{"dàng", "tàng"},
				{"dao", "tao"},
				{"dāo", "tāo"},
				{"dáo", "táo"},
				{"dăo", "tăo"},
				{"dào", "tào"},
				{"de", "te"},
				{"dē", "tē"},
				{"dé", "té"},
				{"dĕ", "tĕ"},
				{"dè", "tè"},
				{"dei", "tëi"},
				{"dēi", "t¡i"},
				{"déi", "t¢i"},
				{"dĕi", "t£i"},
				{"dèi", "t¤i"},
				{"deng", "teng"},
				{"dēng", "tēng"},
				{"déng", "téng"},
				{"dĕng", "tĕng"},
				{"dèng", "tèng"},
				{"di", "ti"},
				{"dī", "tī"},
				{"dí", "tí"},
				{"dĭ", "tĭ"},
				{"dì", "tì"},
				{"dian", "tiën"},
				{"diān", "tī¡n"},
				{"dián", "tí¢n"},
				{"diăn", "tĭ£n"},
				{"diàn", "tì¤n"},
				{"diao", "tiao"},
				{"diāo", "tiāo"},
				{"diáo", "tiáo"},
				{"diăo", "tiăo"},
				{"diào", "tiào"},
				{"die", "tië"},
				{"diē", "ti¡"},
				{"dié", "ti¢"},
				{"diĕ", "ti£"},
				{"diè", "ti¤"},
				{"ding", "ting"},
				{"dīng", "tīng"},
				{"díng", "tíng"},
				{"dĭng", "tĭng"},
				{"dìng", "tìng"},
				{"diu", "tiu"},
				{"diū", "tiū"},
				{"diú", "tiú"},
				{"diŭ", "tiŭ"},
				{"diù", "tiù"},
				{"dong", "tong"},
				{"dōng", "tōng"},
				{"dóng", "tóng"},
				{"dŏng", "tŏng"},
				{"dòng", "tòng"},
				{"dou", "tou"},
				{"dōu", "tōu"},
				{"dóu", "tóu"},
				{"dŏu", "tŏu"},
				{"dòu", "tòu"},
				{"du", "tu"},
				{"dū", "tū"},
				{"dú", "tú"},
				{"dŭ", "tŭ"},
				{"dù", "tù"},
				{"duan", "tuan"},
				{"duān", "tuān"},
				{"duán", "tuán"},
				{"duăn", "tuăn"},
				{"duàn", "tuàn"},
				{"dui", "tui"},
				{"duī", "tuī"},
				{"duí", "tuí"},
				{"duĭ", "tuĭ"},
				{"duì", "tuì"},
				{"duo", "tuo"},
				{"duō", "tuō"},
				{"duó", "tuó"},
				{"duŏ", "tuŏ"},
				{"duò", "tuò"},
				{"dun", "tun"},
				{"dūn", "tūn"},
				{"dún", "tún"},
				{"dŭn", "tŭn"},
				{"dùn", "tùn"},
				{"ga", "ka"},
				{"gā", "kā"},
				{"gá", "ká"},
				{"gă", "kă"},
				{"gà", "kà"},
				{"gan", "kan"},
				{"gān", "kān"},
				{"gán", "kán"},
				{"găn", "kăn"},
				{"gàn", "kàn"},
				{"gang", "kang"},
				{"gāng", "kāng"},
				{"gáng", "káng"},
				{"găng", "kăng"},
				{"gàng", "kàng"},
				{"gao", "kao"},
				{"gāo", "kāo"},
				{"gáo", "káo"},
				{"găo", "kăo"},
				{"gào", "kào"},
				{"ge", "ke"},
				{"gē", "kē"},
				{"gé", "ké"},
				{"gĕ", "kĕ"},
				{"gè", "kè"},
				{"gei", "këi"},
				{"gēi", "k¡i"},
				{"géi", "k¢i"},
				{"gĕi", "k£i"},
				{"gèi", "k¤i"},
				{"gen", "ken"},
				{"gēn", "kēn"},
				{"gén", "kén"},
				{"gĕn", "kĕn"},
				{"gèn", "kèn"},
				{"geng", "keng"},
				{"gēng", "kēng"},
				{"géng", "kéng"},
				{"gĕng", "kĕng"},
				{"gèng", "kèng"},
				{"gong", "kong"},
				{"gōng", "kōng"},
				{"góng", "kóng"},
				{"gŏng", "kŏng"},
				{"gòng", "kòng"},
				{"gou", "kou"},
				{"gōu", "kōu"},
				{"góu", "kóu"},
				{"gŏu", "kŏu"},
				{"gòu", "kòu"},
				{"gu", "ku"},
				{"gū", "kū"},
				{"gú", "kú"},
				{"gŭ", "kŭ"},
				{"gù", "kù"},
				{"gua", "kua"},
				{"guā", "kuā"},
				{"guá", "kuá"},
				{"guă", "kuă"},
				{"guà", "kuà"},
				{"guai", "kuai"},
				{"guaī", "kuaī"},
				{"guaí", "kuaí"},
				{"guaĭ", "kuaĭ"},
				{"guaì", "kuaì"},
				{"guan", "kuan"},
				{"guān", "kuān"},
				{"guán", "kuán"},
				{"guăn", "kuăn"},
				{"guàn", "kuàn"},
				{"guang", "kuang"},
				{"guāng", "kuāng"},
				{"guáng", "kuáng"},
				{"guăng", "kuăng"},
				{"guàng", "kuàng"},
				{"gui", "kui"},
				{"guī", "kuī"},
				{"guí", "kuí"},
				{"guĭ", "kuĭ"},
				{"guì", "kuì"},
				{"guo", "kuo"},
				{"guō", "kuō"},
				{"guó", "kuó"},
				{"guŏ", "kuŏ"},
				{"guò", "kuò"},
				{"gun", "kun"},
				{"gūn", "kūn"},
				{"gún", "kún"},
				{"gŭn", "kŭn"},
				{"gùn", "kùn"},
				{"ji", "ci"},
				{"jī", "cī"},
				{"jí", "cí"},
				{"jĭ", "cĭ"},
				{"jì", "cì"},
				{"jia", "cia"},
				{"jiā", "ciā"},
				{"jiá", "ciá"},
				{"jiă", "ciă"},
				{"jià", "cià"},
				{"jian", "ciën"},
				{"jiān", "ci¡n"},
				{"jián", "ci¢n"},
				{"jiăn", "ci£n"},
				{"jiàn", "ci¤n"},
				{"jiang", "ciang"},
				{"jiāng", "ciāng"},
				{"jiáng", "ciáng"},
				{"jiăng", "ciăng"},
				{"jiàng", "ciàng"},
				{"jiao", "ciao"},
				{"jiāo", "ciāo"},
				{"jiáo", "ciáo"},
				{"jiăo", "ciăo"},
				{"jiào", "ciào"},
				{"jie", "cië"},
				{"jiē", "ci¡"},
				{"jié", "ci¢"},
				{"jiĕ", "ci£"},
				{"jiè", "ci¤"},
				{"jin", "cin"},
				{"jīn", "cīn"},
				{"jín", "cín"},
				{"jĭn", "cĭn"},
				{"jìn", "cìn"},
				{"jing", "cing"},
				{"jīng", "cīng"},
				{"jíng", "cíng"},
				{"jĭng", "cĭng"},
				{"jìng", "cìng"},
				{"jiu", "ciu"},
				{"jiū", "ciū"},
				{"jiú", "ciú"},
				{"jiŭ", "ciŭ"},
				{"jiù", "ciù"},
				{"ju", "cuiy"},
				{"jū", "cūiy"},
				{"jú", "cúiy"},
				{"jŭ", "cŭiy"},
				{"jù", "cùiy"},
				{"juan", "cuën"},
				{"juān", "cu¡n"},
				{"juán", "cu¢n"},
				{"juăn", "cu£n"},
				{"juàn", "cu¤n"},
				{"jue", "cuë"},
				{"juē", "cu¡"},
				{"jué", "cu¢"},
				{"juĕ", "cu£"},
				{"juè", "cu¤"},
				{"jun", "cuin"},
				{"jūn", "cūin"},
				{"jún", "cúin"},
				{"jŭn", "cŭin"},
				{"jùn", "cùin"},
				{"ka", "kha"},
				{"kā", "khā"},
				{"ká", "khá"},
				{"kă", "khă"},
				{"kà", "khà"},
				{"kai", "khai"},
				{"kāi", "khāi"},
				{"kái", "khái"},
				{"kăi", "khăi"},
				{"kài", "khài"},
				{"kan", "khan"},
				{"kān", "khān"},
				{"kán", "khán"},
				{"kăn", "khăn"},
				{"kàn", "khàn"},
				{"kang", "khang"},
				{"kāng", "khāng"},
				{"káng", "kháng"},
				{"kăng", "khăng"},
				{"kàng", "khàng"},
				{"kao", "khao"},
				{"kāo", "khāo"},
				{"káo", "kháo"},
				{"kăo", "khăo"},
				{"kào", "khào"},
				{"ke", "khe"},
				{"kē", "khē"},
				{"ké", "khé"},
				{"kĕ", "khĕ"},
				{"kè", "khè"},
				{"ken", "khen"},
				{"kēn", "khēn"},
				{"kén", "khén"},
				{"kĕn", "khĕn"},
				{"kèn", "khèn"},
				{"keng", "kheng"},
				{"kēng", "khēng"},
				{"kéng", "khéng"},
				{"kĕng", "khĕng"},
				{"kèng", "khèng"},
				{"kong", "khong"},
				{"kōng", "khōng"},
				{"kóng", "khóng"},
				{"kŏng", "khŏng"},
				{"kòng", "khòng"},
				{"kou", "khou"},
				{"kōu", "khōu"},
				{"kóu", "khóu"},
				{"kŏu", "khŏu"},
				{"kòu", "khòu"},
				{"ku", "khu"},
				{"kū", "khū"},
				{"kú", "khú"},
				{"kŭ", "khŭ"},
				{"kù", "khù"},
				{"kua", "khua"},
				{"kuā", "khuā"},
				{"kuá", "khuá"},
				{"kuă", "khuă"},
				{"kuà", "khuà"},
				{"kuai", "khuai"},
				{"kuāi", "khuāi"},
				{"kuái", "khuái"},
				{"kuăi", "khuăi"},
				{"kuài", "khuài"},
				{"kuan", "khuan"},
				{"kuān", "khuān"},
				{"kuán", "khuán"},
				{"kuăn", "khuăn"},
				{"kuàn", "khuàn"},
				{"kuang", "khuang"},
				{"kuāng", "khuāng"},
				{"kuáng", "khuáng"},
				{"kuăng", "khuăng"},
				{"kuàng", "khuàng"},
				{"kui", "khui"},
				{"kuī", "khuī"},
				{"kuí", "khuí"},
				{"kuĭ", "khuĭ"},
				{"kuì", "khuì"},
				{"kuo", "khuo"},
				{"kuō", "khuō"},
				{"kuó", "khuó"},
				{"kuŏ", "khuŏ"},
				{"kuò", "khuò"},
				{"pa", "pha"},
				{"pā", "phā"},
				{"pá", "phá"},
				{"pă", "phă"},
				{"pà", "phà"},
				{"pai", "phai"},
				{"pāi", "phāi"},
				{"pái", "phái"},
				{"păi", "phăi"},
				{"pài", "phài"},
				{"pan", "phan"},
				{"pān", "phān"},
				{"pán", "phán"},
				{"păn", "phăn"},
				{"pàn", "phàn"},
				{"pang", "phang"},
				{"pāng", "phāng"},
				{"páng", "pháng"},
				{"păng", "phăng"},
				{"pàng", "phàng"},
				{"pao", "phao"},
				{"pāo", "phāo"},
				{"páo", "pháo"},
				{"păo", "phăo"},
				{"pào", "phào"},
				{"pei", "phëi"},
				{"pēi", "ph¡i"},
				{"péi", "ph¢i"},
				{"pĕi", "ph£i"},
				{"pèi", "ph¤i"},
				{"pen", "phen"},
				{"pēn", "phēn"},
				{"pén", "phén"},
				{"pĕn", "phĕn"},
				{"pèn", "phèn"},
				{"peng", "pheng"},
				{"pēng", "phēng"},
				{"péng", "phéng"},
				{"pĕng", "phĕng"},
				{"pèng", "phèng"},
				{"pi", "phi"},
				{"pī", "phī"},
				{"pí", "phí"},
				{"pĭ", "phĭ"},
				{"pì", "phì"},
				{"pian", "phiën"},
				{"piān", "phi¡n"},
				{"pián", "phi¢n"},
				{"piăn", "phi£n"},
				{"piàn", "phi¤n"},
				{"piao", "phiao"},
				{"piāo", "phiāo"},
				{"piáo", "phiáo"},
				{"piăo", "phiăo"},
				{"piào", "phiào"},
				{"pie", "phië"},
				{"piē", "phi¡"},
				{"pié", "phi¢"},
				{"piĕ", "phi£"},
				{"piè", "phi¤"},
				{"pin", "phin"},
				{"pīn", "phīn"},
				{"pín", "phín"},
				{"pĭn", "phĭn"},
				{"pìn", "phìn"},
				{"ping", "phing"},
				{"pīng", "phīng"},
				{"píng", "phíng"},
				{"pĭng", "phĭng"},
				{"pìng", "phìng"},
				{"po", "pho"},
				{"pō", "phō"},
				{"pó", "phó"},
				{"pŏ", "phŏ"},
				{"pò", "phò"},
				{"pou", "phou"},
				{"pōu", "phōu"},
				{"póu", "phóu"},
				{"pŏu", "phŏu"},
				{"pòu", "phòu"},
				{"pu", "phu"},
				{"pū", "phū"},
				{"pú", "phú"},
				{"pŭ", "phŭ"},
				{"pù", "phù"},
				{"qi", "chi"},
				{"qī", "chī"},
				{"qí", "chí"},
				{"qĭ", "chĭ"},
				{"qì", "chì"},
				{"qia", "chia"},
				{"qiā", "chiā"},
				{"qiá", "chiá"},
				{"qiă", "chiă"},
				{"qià", "chià"},
				{"qian", "chiën"},
				{"qiān", "chi¡n"},
				{"qián", "chi¢n"},
				{"qiăn", "chi£n"},
				{"qiàn", "chi¤n"},
				{"qiang", "chiang"},
				{"qiāng", "chiāng"},
				{"qiáng", "chiáng"},
				{"qiăng", "chiăng"},
				{"qiàng", "chiàng"},
				{"qiao", "chiao"},
				{"qiāo", "chiāo"},
				{"qiáo", "chiáo"},
				{"qiăo", "chiăo"},
				{"qiào", "chiào"},
				{"qie", "chië"},
				{"qiē", "chi¡"},
				{"qié", "chi¢"},
				{"qiĕ", "chi£"},
				{"qiè", "chi¤"},
				{"qin", "chin"},
				{"qīn", "chīn"},
				{"qín", "chín"},
				{"qĭn", "chĭn"},
				{"qìn", "chìn"},
				{"qing", "ching"},
				{"qīng", "chīng"},
				{"qíng", "chíng"},
				{"qĭng", "chĭng"},
				{"qìng", "chìng"},
				{"qiong", "chiong"},
				{"qiōng", "chiōng"},
				{"qióng", "chióng"},
				{"qiŏng", "chiŏng"},
				{"qiòng", "chiòng"},
				{"qiu", "chiu"},
				{"qiū", "chiū"},
				{"qiú", "chiú"},
				{"qiŭ", "chiŭ"},
				{"qiù", "chiù"},
				{"qu", "chuiy"},
				{"qū", "chuīy"},
				{"qú", "chuíy"},
				{"qŭ", "chuĭy"},
				{"qù", "chuìy"},
				{"quan", "chuën"},
				{"quān", "chu¡n"},
				{"quán", "chu¢n"},
				{"quăn", "chu£n"},
				{"quàn", "chu¤n"},
				{"que", "chuë"},
				{"quē", "chu¡"},
				{"qué", "chu¢"},
				{"quĕ", "chu£"},
				{"què", "chu¤"},
				{"qun", "chuin"},
				{"qūn", "chuīn"},
				{"qún", "chuín"},
				{"qŭn", "chuĭn"},
				{"qùn", "chuìn"},
				{"ta", "tha"},
				{"tā", "thā"},
				{"tá", "thá"},
				{"tă", "thă"},
				{"tà", "thà"},
				{"tai", "thai"},
				{"tāi", "thāi"},
				{"tái", "thái"},
				{"tăi", "thăi"},
				{"tài", "thài"},
				{"tan", "than"},
				{"tān", "thān"},
				{"tán", "thán"},
				{"tăn", "thăn"},
				{"tàn", "thàn"},
				{"tang", "thang"},
				{"tāng", "thāng"},
				{"táng", "tháng"},
				{"tăng", "thăng"},
				{"tàng", "thàng"},
				{"tao", "thao"},
				{"tāo", "thāo"},
				{"táo", "tháo"},
				{"tăo", "thăo"},
				{"tào", "thào"},
				{"te", "the"},
				{"tē", "thē"},
				{"té", "thé"},
				{"tĕ", "thĕ"},
				{"tè", "thè"},
				{"teng", "theng"},
				{"tēng", "thēng"},
				{"téng", "théng"},
				{"tĕng", "thĕng"},
				{"tèng", "thèng"},
				{"ti", "thi"},
				{"tī", "thī"},
				{"tí", "thí"},
				{"tĭ", "thĭ"},
				{"tì", "thì"},
				{"tian", "thiën"},
				{"tiān", "thi¡n"},
				{"tián", "thi¢n"},
				{"tiăn", "thi£n"},
				{"tiàn", "thi¤n"},
				{"tiao", "thiao"},
				{"tiāo", "thiāo"},
				{"tiáo", "thiáo"},
				{"tiăo", "thiăo"},
				{"tiào", "thiào"},
				{"tie", "thië"},
				{"tiē", "thi¡"},
				{"tié", "thi¢"},
				{"tiĕ", "thi£"},
				{"tiè", "thi¤"},
				{"ting", "thing"},
				{"tīng", "thīng"},
				{"tíng", "thíng"},
				{"tĭng", "thĭng"},
				{"tìng", "thìng"},
				{"tong", "thong"},
				{"tōng", "thōng"},
				{"tóng", "thóng"},
				{"tŏng", "thŏng"},
				{"tòng", "thòng"},
				{"tou", "thou"},
				{"tōu", "thōu"},
				{"tóu", "thóu"},
				{"tŏu", "thŏu"},
				{"tòu", "thòu"},
				{"tu", "thu"},
				{"tū", "thū"},
				{"tú", "thú"},
				{"tŭ", "thŭ"},
				{"tù", "thù"},
				{"tuan", "thuan"},
				{"tuān", "thuān"},
				{"tuán", "thuán"},
				{"tuăn", "thuăn"},
				{"tuàn", "thuàn"},
				{"tui", "thui"},
				{"tuī", "thuī"},
				{"tuí", "thuí"},
				{"tuĭ", "thuĭ"},
				{"tuì", "thuì"},
				{"tuo", "thuo"},
				{"tuō", "thuō"},
				{"tuó", "thuó"},
				{"tuŏ", "thuŏ"},
				{"tuò", "thuò"},
				{"tun", "thun"},
				{"tūn", "thūn"},
				{"tún", "thún"},
				{"tŭn", "thŭn"},
				{"tùn", "thùn"},
				{"xi", "shi"},
				{"xī", "shī"},
				{"xí", "shí"},
				{"xĭ", "shĭ"},
				{"xì", "shì"},
				{"xia", "shia"},
				{"xiā", "shiā"},
				{"xiá", "shiá"},
				{"xiă", "shiă"},
				{"xià", "shià"},
				{"xian", "shiën"},
				{"xiān", "shi¡n"},
				{"xián", "shi¢n"},
				{"xiăn", "shi£n"},
				{"xiàn", "shi¤n"},
				{"xiang", "shiang"},
				{"xiāng", "shiāng"},
				{"xiáng", "shiáng"},
				{"xiăng", "shiăng"},
				{"xiàng", "shiàng"},
				{"xiao", "shiao"},
				{"xiāo", "shiāo"},
				{"xiáo", "shiáo"},
				{"xiăo", "shiăo"},
				{"xiào", "shiào"},
				{"xie", "shië"},
				{"xiē", "shi¡"},
				{"xié", "shi¢"},
				{"xiĕ", "shi£"},
				{"xiè", "shi¤"},
				{"xin", "shin"},
				{"xīn", "shīn"},
				{"xín", "shín"},
				{"xĭn", "shĭn"},
				{"xìn", "shìn"},
				{"xing", "shing"},
				{"xīng", "shīng"},
				{"xíng", "shíng"},
				{"xĭng", "shĭng"},
				{"xìng", "shìng"},
				{"xiong", "shiong"},
				{"xiōng", "shiōng"},
				{"xióng", "shióng"},
				{"xiŏng", "shiŏng"},
				{"xiòng", "shiòng"},
				{"xiu", "shiu"},
				{"xiū", "shiū"},
				{"xiú", "shiú"},
				{"xiŭ", "shiŭ"},
				{"xiù", "shiù"},
				{"xu", "shuiy"},
				{"xū", "shuīy"},
				{"xú", "shuíy"},
				{"xŭ", "shuĭy"},
				{"xù", "shuìy"},
				{"xuan", "shuën"},
				{"xuān", "shu¡n"},
				{"xuán", "shu¢n"},
				{"xuăn", "shu£n"},
				{"xuàn", "shu¤n"},
				{"xue", "shuë"},
				{"xuē", "shu¡"},
				{"xué", "shu¢"},
				{"xuĕ", "shu£"},
				{"xuè", "shu¤"},
				{"xun", "shuin"},
				{"xūn", "shuīn"},
				{"xún", "shuín"},
				{"xŭn", "shuĭn"},
				{"xùn", "shuìn"},
				{"za", "ca"},
				{"zā", "cā"},
				{"zá", "cá"},
				{"ză", "că"},
				{"zà", "cà"},
				{"zai", "cai"},
				{"zāi", "cāi"},
				{"zái", "cái"},
				{"zăi", "căi"},
				{"zài", "cài"},
				{"zan", "can"},
				{"zān", "cān"},
				{"zán", "cán"},
				{"zăn", "căn"},
				{"zàn", "càn"},
				{"zang", "cang"},
				{"zāng", "cāng"},
				{"záng", "cáng"},
				{"zăng", "căng"},
				{"zàng", "càng"},
				{"zao", "cao"},
				{"zāo", "cāo"},
				{"záo", "cáo"},
				{"zăo", "căo"},
				{"zào", "cào"},
				{"ze", "ce"},
				{"zē", "cē"},
				{"zé", "cé"},
				{"zĕ", "cĕ"},
				{"zè", "cè"},
				{"zei", "cëi"},
				{"zēi", "c¡i"},
				{"zéi", "c¢i"},
				{"zĕi", "c£i"},
				{"zèi", "c¤i"},
				{"zen", "cen"},
				{"zēn", "cēn"},
				{"zén", "cén"},
				{"zĕn", "cĕn"},
				{"zèn", "cèn"},
				{"zeng", "ceng"},
				{"zēng", "cēng"},
				{"zéng", "céng"},
				{"zĕng", "cĕng"},
				{"zèng", "cèng"},
				{"zi", "ce"},
				{"zī", "cē"},
				{"zí", "cé"},
				{"zĭ", "cĕ"},
				{"zì", "cè"},
				{"zong", "cong"},
				{"zōng", "cōng"},
				{"zóng", "cóng"},
				{"zŏng", "cŏng"},
				{"zòng", "còng"},
				{"zou", "cou"},
				{"zōu", "cōu"},
				{"zóu", "cóu"},
				{"zŏu", "cŏu"},
				{"zòu", "còu"},
				{"zu", "cu"},
				{"zū", "cū"},
				{"zú", "cú"},
				{"zŭ", "cŭ"},
				{"zù", "cù"},
				{"zuan", "cuan"},
				{"zuān", "cuān"},
				{"zuán", "cuán"},
				{"zuăn", "cuăn"},
				{"zuàn", "cuàn"},
				{"zui", "cui"},
				{"zuī", "cuī"},
				{"zuí", "cuí"},
				{"zuĭ", "cuĭ"},
				{"zuì", "cuì"},
				{"zuo", "cuo"},
				{"zuō", "cuō"},
				{"zuó", "cuó"},
				{"zuŏ", "cuŏ"},
				{"zuò", "cuò"},
				{"zun", "cun"},
				{"zūn", "cūn"},
				{"zún", "cún"},
				{"zŭn", "cŭn"},
				{"zùn", "cùn"},
				{"zha", "ca"},
				{"zhā", "cā"},
				{"zhá", "cá"},
				{"zhă", "că"},
				{"zhà", "cà"},
				{"zhai", "cai"},
				{"zhāi", "cāi"},
				{"zhái", "cái"},
				{"zhăi", "căi"},
				{"zhài", "cài"},
				{"zhan", "can"},
				{"zhān", "cān"},
				{"zhán", "cán"},
				{"zhăn", "căn"},
				{"zhàn", "càn"},
				{"zhang", "cang"},
				{"zhāng", "cāng"},
				{"zháng", "cáng"},
				{"zhăng", "căng"},
				{"zhàng", "càng"},
				{"zhao", "cao"},
				{"zhāo", "cāo"},
				{"zháo", "cáo"},
				{"zhăo", "căo"},
				{"zhào", "cào"},
				{"zhe", "ce"},
				{"zhē", "cē"},
				{"zhé", "cé"},
				{"zhĕ", "cĕ"},
				{"zhè", "cè"},
				{"zhei", "cëi"},
				{"zhēi", "c¡i"},
				{"zhéi", "c¢i"},
				{"zhĕi", "c£i"},
				{"zhèi", "c¤i"},
				{"zhen", "cen"},
				{"zhēn", "cēn"},
				{"zhén", "cén"},
				{"zhĕn", "cĕn"},
				{"zhèn", "cèn"},
				{"zheng", "ceng"},
				{"zhēng", "cēng"},
				{"zhéng", "céng"},
				{"zhĕng", "cĕng"},
				{"zhèng", "cèng"},
				{"zhi", "ce"},
				{"zhī", "cē"},
				{"zhí", "cé"},
				{"zhĭ", "cĕ"},
				{"zhì", "cè"},
				{"zhong", "cong"},
				{"zhōng", "cōng"},
				{"zhóng", "cóng"},
				{"zhŏng", "cŏng"},
				{"zhòng", "còng"},
				{"zhou", "cou"},
				{"zhōu", "cōu"},
				{"zhóu", "cóu"},
				{"zhŏu", "cŏu"},
				{"zhòu", "còu"},
				{"zhu", "cu"},
				{"zhū", "cū"},
				{"zhú", "cú"},
				{"zhŭ", "cŭ"},
				{"zhù", "cù"},
				{"zhua", "cua"},
				{"zhuā", "cuā"},
				{"zhuá", "cuá"},
				{"zhuă", "cuă"},
				{"zhuà", "cuà"},
				{"zhuai", "cuai"},
				{"zhuāi", "cuāi"},
				{"zhuái", "cuái"},
				{"zhuăi", "cuăi"},
				{"zhuài", "cuài"},
				{"zhuan", "cuan"},
				{"zhuān", "cuān"},
				{"zhuán", "cuán"},
				{"zhuăn", "cuăn"},
				{"zhuàn", "cuàn"},
				{"zhuang", "cuang"},
				{"zhuāng", "cuāng"},
				{"zhuáng", "cuáng"},
				{"zhuăng", "cuăng"},
				{"zhuàng", "cuàng"},
				{"zhui", "cui"},
				{"zhuī", "cuī"},
				{"zhuí", "cuí"},
				{"zhuĭ", "cuĭ"},
				{"zhuì", "cuì"},
				{"zhuo", "cuo"},
				{"zhuō", "cuō"},
				{"zhuó", "cuó"},
				{"zhuŏ", "cuŏ"},
				{"zhuò", "cuò"},
				{"zhun", "cun"},
				{"zhūn", "cūn"},
				{"zhún", "cún"},
				{"zhŭn", "cŭn"},
				{"zhùn", "cùn"},

			}.OrderByDescending(x => x.Key.Length).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

			string[] Tx = input.ToLower().Split(' ');
			string[] Fi = new string[Tx.Length];

			for (int x = 0; x < Tx.Length; x++)
			{
				int idx = 0;
				int pos = Tx[x].Length;
				int len = Tx[x].Length;
				while (len != 0)
				{
					string test;
					string temp = Tx[x].Substring(idx, len);
					if (dict.TryGetValue(temp, out test))
					{
						Fi[x] += test;
						idx = pos;
						pos = Tx[x].Length;
						len = pos - idx;
					}
					else
					{
						len--;
						pos--;
						if (idx == pos)
						{
							Fi[x] += Tx[x].Substring(pos, 1);
							idx++;
							pos = Tx[x].Length;
							len = pos - idx;
						}
					}
				}
			}

			input = "";

			for (int i = 0; i < Fi.Length; i++)
				input += Fi[i] + " ";
			
			return input.Remove(input.Length - 1);
		}
		//
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
