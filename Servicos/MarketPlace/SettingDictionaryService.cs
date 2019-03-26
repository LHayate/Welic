using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Patterns.Pattern.Ef6;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.MarketPlace
{
    public class SettingDictionaryService : Service<SettingDictionary>, ISettingDictionaryService
    {
        public SettingDictionaryService(IRepositoryAsync<SettingDictionary> repository)
            : base(repository)
        {
        }

        public void SaveSettingDictionary(SettingDictionary setting)
        {
            if (setting.ID == 0)
            {
                setting.ObjectState = ObjectState.Added;
                Insert(setting);
            }
            else
            {
                setting.ObjectState = ObjectState.Modified;
                Update(setting);
            }
        }

        public SettingDictionary GetSettingDictionary(int settingID, string settingKey)
        {
            var settingQuery = Query(x => x.Name == settingKey && x.SettingID == settingID).Select();
            var setting = settingQuery.FirstOrDefault();

            if (setting == null)
                return new SettingDictionary()
                {
                    Name = settingKey.ToString(),
                    Value = string.Empty
                };

            return setting;
        }
    }
}
