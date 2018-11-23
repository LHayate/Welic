using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class Picture : Entity
    {
        public Picture()
        {
            this.ListingPictures = new List<ListingPicture>();
        }

        public int ID { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public virtual ICollection<ListingPicture> ListingPictures { get; set; }
    }
}
