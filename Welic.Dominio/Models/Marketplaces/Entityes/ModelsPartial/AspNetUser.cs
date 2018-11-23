using System;
using System.ComponentModel.DataAnnotations;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    [MetadataType(typeof(UserMetaData))]
    public partial class AspNetUser
    {
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}".Trim(), FirstName, LastName);
            }
        }

        public string RatingClass
        {
            get
            {
                return "s" + Math.Round(Rating * 2);
            }
        }
    }

    public class UserMetaData
    {
    }
}
