using System.ComponentModel;


namespace WinGUITest1.Service
{
    public class ChampionInfo : BaseEntity
    {
        //[DisplayName("英雄")]
        public int ChampionId { get; set; }
        //[DisplayName("英文名")]
        public string EnglishName { get; set; }
        //[DisplayName("中文前缀")]
        public string PreCnName { get; set; }
        //[DisplayName("中文名")]
        public string ChineseName { get; set; }
        //[DisplayName("俗名")]
        public string NickName { get; set; }
        //[DisplayName("主要定位")]
        public string Position { get; set; }
        //[DisplayName("次要定位")]
        public string SecondPosition { get; set; }
        //[DisplayName("金币价格")]
        public int GoldPrice { get; set; }
        //[DisplayName("点券价格")]
        public int PointTicket { get; set; }


    }
}
