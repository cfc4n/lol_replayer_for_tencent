using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinGUITest1.Service
{
    class SettingService
    {
        private readonly MyRepository<Setting> settingRepository;

        public SettingService(MyRepository<Setting> settingRepository)
        {
            this.settingRepository = settingRepository;
        }

        public Setting GetById(int id)
        {
            return settingRepository.GetById(id);
        }

        public IEnumerable<Setting> GetAll()
        {
            return settingRepository.Table;
        }

        public string GetValueByName(string name)
        {
            return settingRepository.Table.Where(s => s.Name == name).FirstOrDefault().Value;
        }

        public void AddSetting(Setting setting)
        {
            settingRepository.Insert(setting);
        }

        public void UpdateSetting(Setting setting)
        {
            settingRepository.Update(setting);
        }

        public void RemoveSetting(Setting setting)
        {
            settingRepository.Delete(setting);
        }
    }
}
