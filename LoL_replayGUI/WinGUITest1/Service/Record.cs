

namespace WinGUITest1.Service
{
    public class Record : BaseEntity
    {
        public string QQ { get; set; }
        public int IsWin { get; set; }
        //[DisplayName("贡献值")]
        public double Contribute { get; set; }
        public int ContributeOrder { get; set; }
        public int TotalDamage { get; set; }
        public int ChampionId { get; set; }
        public int GoldEarned { get; set; }
        public int Kill { get; set; }
        public int Death { get; set; }
        public int Assist { get; set; }
        //[DisplayName("召唤师")]
        public string Name { get; set; }
        public int DamageTaken { get; set; }
        public int Item0 { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
        public int Item5 { get; set; }
        public int Item6 { get; set; }
        public string KDA { get; set; }
        public int MinionsKilled { get; set; }
        public string BattleTagList { get; set; }
        public int LargestKillingSpree { get; set; }
        public virtual Battle Battle { get; set; }
    }
}
