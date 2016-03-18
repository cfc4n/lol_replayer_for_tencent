using System.Linq;

namespace WinGUITest1.Lol
{
   public  interface ISettingService
   {
       Setting GetById(int id);
       IQueryable<Setting> GetAll();

        string GetValueByName(string name);

        void AddSetting(Setting setting);
        void UpdateSetting(Setting setting);
        void RemoveSetting(Setting setting);

    }
}
