using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinGUITest1.Lol
{
  public   class Battle:BaseEntity 
    {
        [DisplayName("比赛类型")]
        public int BattleType { get; set; }
        [DisplayName("游戏Id")]
        public int GameId { get; set; }
        [DisplayName("开始时间")]
        public DateTime StartTime { get; set; }
        [DisplayName("比赛历时")]
        public int Duration { get; set; }
        [DisplayName("是否获胜")]
        public int IsWin { get; set; }
        [DisplayName("英雄")]
        public int ChampionId { get; set; }
        [DisplayName("贡献排名")]
        public int ContributeOrder { get; set; }

       public virtual  ICollection<Record> Records { get; set; }
      
    }
}
