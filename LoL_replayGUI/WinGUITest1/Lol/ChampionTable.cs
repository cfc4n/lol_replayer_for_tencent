using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinGUITest1.Lol
{
    class ChampionTable
    {
        private Hashtable ChampionTableItems = new Hashtable();

        public ChampionTable()
        {
            ChampionTableItems.Add(266, "Aatrox");
            ChampionTableItems.Add(103, "Ahri");
            ChampionTableItems.Add(84, "Akali");
            ChampionTableItems.Add(12, "Alistar");
            ChampionTableItems.Add(32, "Amumu");
            ChampionTableItems.Add(34, "Anivia");
            ChampionTableItems.Add(1, "Annie");
            ChampionTableItems.Add(22, "Ashe");
            ChampionTableItems.Add(136, "AurelionSol");
            ChampionTableItems.Add(268, "Azir");
            ChampionTableItems.Add(432, "Bard");
            ChampionTableItems.Add(53, "Blitzcrank");
            ChampionTableItems.Add(63, "Brand");
            ChampionTableItems.Add(201, "Braum");
            ChampionTableItems.Add(51, "Caitlyn");
            ChampionTableItems.Add(69, "Cassiopeia");
            ChampionTableItems.Add(31, "ChoGath");
            ChampionTableItems.Add(42, "Corki");
            ChampionTableItems.Add(122, "Darius");
            ChampionTableItems.Add(131, "Diana");
            ChampionTableItems.Add(36, "DrMundo");
            ChampionTableItems.Add(119, "Draven");
            ChampionTableItems.Add(245, "Ekko");
            ChampionTableItems.Add(60, "Elise");
            ChampionTableItems.Add(28, "Evelynn");
            ChampionTableItems.Add(81, "Ezreal");
            ChampionTableItems.Add(9, "Fiddlesticks");
            ChampionTableItems.Add(114, "Fiora");
            ChampionTableItems.Add(105, "Fizz");
            ChampionTableItems.Add(3, "Galio");
            ChampionTableItems.Add(41, "Gangplank");
            ChampionTableItems.Add(86, "Garen");
            ChampionTableItems.Add(150, "Gnar");
            ChampionTableItems.Add(79, "Gragas");
            ChampionTableItems.Add(104, "Graves");
            ChampionTableItems.Add(120, "Hecarim");
            ChampionTableItems.Add(74, "Heimerdinger");
            ChampionTableItems.Add(420, "Illaoi");
            ChampionTableItems.Add(39, "Irelia");
            ChampionTableItems.Add(40, "Janna");
            ChampionTableItems.Add(59, "JarvanIV");
            ChampionTableItems.Add(24, "Jax");
            ChampionTableItems.Add(126, "Jayce");
            ChampionTableItems.Add(202, "Jhin");
            ChampionTableItems.Add(222, "Jinx");
            ChampionTableItems.Add(429, "Kalista");
            ChampionTableItems.Add(43, "Karma");
            ChampionTableItems.Add(30, "Karthus");
            ChampionTableItems.Add(38, "Kassadin");
            ChampionTableItems.Add(55, "Katarina");
            ChampionTableItems.Add(10, "Kayle");
            ChampionTableItems.Add(85, "Kennen");
            ChampionTableItems.Add(121, "KhaZix");
            ChampionTableItems.Add(203, "Kindred");
            ChampionTableItems.Add(96, "KogMaw");
            ChampionTableItems.Add(7, "LeBlanc");
            ChampionTableItems.Add(64, "LeeSin");
            ChampionTableItems.Add(89, "Leona");
            ChampionTableItems.Add(127, "Lissandra");
            ChampionTableItems.Add(236, "Lucian");
            ChampionTableItems.Add(117, "Lulu");
            ChampionTableItems.Add(99, "Lux");
            ChampionTableItems.Add(54, "Malphite");
            ChampionTableItems.Add(90, "Malzahar");
            ChampionTableItems.Add(57, "Maokai");
            ChampionTableItems.Add(11, "MasterYi");
            ChampionTableItems.Add(21, "MissFortune");
            ChampionTableItems.Add(82, "Mordekaiser");
            ChampionTableItems.Add(25, "Morgana");
            ChampionTableItems.Add(267, "Nami");
            ChampionTableItems.Add(75, "Nasus");
            ChampionTableItems.Add(111, "Nautilus");
            ChampionTableItems.Add(76, "Nidalee");
            ChampionTableItems.Add(56, "Nocturne");
            ChampionTableItems.Add(20, "Nunu");
            ChampionTableItems.Add(2, "Olaf");
            ChampionTableItems.Add(61, "Orianna");
            ChampionTableItems.Add(80, "Pantheon");
            ChampionTableItems.Add(78, "Poppy");
            ChampionTableItems.Add(133, "Quinn");
            ChampionTableItems.Add(33, "Rammus");
            ChampionTableItems.Add(421, "RekSai");
            ChampionTableItems.Add(58, "Renekton");
            ChampionTableItems.Add(107, "Rengar");
            ChampionTableItems.Add(92, "Riven");
            ChampionTableItems.Add(68, "Rumble");
            ChampionTableItems.Add(13, "Ryze");
            ChampionTableItems.Add(113, "Sejuani");
            ChampionTableItems.Add(35, "Shaco");
            ChampionTableItems.Add(98, "Shen");
            ChampionTableItems.Add(102, "Shyvana");
            ChampionTableItems.Add(27, "Singed");
            ChampionTableItems.Add(14, "Sion");
            ChampionTableItems.Add(15, "Sivir");
            ChampionTableItems.Add(72, "Skarner");
            ChampionTableItems.Add(37, "Sona");
            ChampionTableItems.Add(16, "Soraka");
            ChampionTableItems.Add(50, "Swain");
            ChampionTableItems.Add(134, "Syndra");
            ChampionTableItems.Add(223, "Tahm Kench");
            ChampionTableItems.Add(91, "Talon");
            ChampionTableItems.Add(44, "Taric");
            ChampionTableItems.Add(17, "Teemo");
            ChampionTableItems.Add(412, "Thresh");
            ChampionTableItems.Add(18, "Tristana");
            ChampionTableItems.Add(48, "Trundle");
            ChampionTableItems.Add(23, "Tryndamere");
            ChampionTableItems.Add(4, "Twisted Fate");
            ChampionTableItems.Add(29, "Twitch");
            ChampionTableItems.Add(77, "Udyr");
            ChampionTableItems.Add(6, "Urgot");
            ChampionTableItems.Add(110, "Varus");
            ChampionTableItems.Add(67, "Vayne");
            ChampionTableItems.Add(45, "Veigar");
            ChampionTableItems.Add(161, "VelKoz");
            ChampionTableItems.Add(254, "Vi");
            ChampionTableItems.Add(112, "Viktor");
            ChampionTableItems.Add(8, "Vladimir");
            ChampionTableItems.Add(106, "Volibear");
            ChampionTableItems.Add(19, "Warwick");
            ChampionTableItems.Add(62, "Wukong");
            ChampionTableItems.Add(101, "Xerath");
            ChampionTableItems.Add(5, "XinZhao");
            ChampionTableItems.Add(157, "Yasuo");
            ChampionTableItems.Add(83, "Yorick");
            ChampionTableItems.Add(154, "Zac");
            ChampionTableItems.Add(238, "Zed");
            ChampionTableItems.Add(115, "Ziggs");
            ChampionTableItems.Add(26, "Zilean");
            ChampionTableItems.Add(143, "Zyra");
        }

        public string getNameFromID(int id) {
            foreach (DictionaryEntry entry in ChampionTableItems)
            {
                if ((int)entry.Key == id) return (string)entry.Value;
            }
            return null;
        }
    }
}
