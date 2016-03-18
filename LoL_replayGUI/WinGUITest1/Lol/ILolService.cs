using System;
using System.Collections.Generic;
using System.Linq;

namespace WinGUITest1.Lol
{
   public  interface ILolService
   {
       
       void UpdateBattle(List<int> ids,int areaId,string myRoleName);
       IQueryable<Battle> GetAllBattles();
     
       IQueryable<Record> GetRecordsByName(string name);
       IQueryable<Record> GetAllRecords();
       List<int> GetUpdateIds(string qq,int areaId);
       Dictionary<int, int> GetAppearRate(string  starttime="2014-10-19");
       Dictionary<int, int> GetCarryAbility(string starttime = "2014-10-19");
        IQueryable<SnapShot> GetAllSnapShots();
        void GetDataById(int v1, int v2);
    }
}
