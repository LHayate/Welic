using System.Collections.Generic;

namespace WebApi.Models
{
    public class LanguageSelectorModel
    {
        public LanguageSelectorModel()
        {
            LanguageList = new List<LanguageSelectorModel>();
        }

        public string DisplayName { get; set; }

        public string Culture { get; set; }

        public List<LanguageSelectorModel> LanguageList { get; set; }
    }
}