using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinGUITest1.Lol
{
    public  class SnapShot: BaseEntity
    {
        public string FileUrl { get; set; }
        public int ChampionId { get; set; }
        public ActionType ActionType { get; set; }

        public int GameId { get; set; }
        public DateTime CommitTime { get; set; }
    }
    public  enum ActionType
    {
        TribleKill = 103,
        UltraKill = 104,
        PantaKill = 105,
        Legendary = 208
    }
}
