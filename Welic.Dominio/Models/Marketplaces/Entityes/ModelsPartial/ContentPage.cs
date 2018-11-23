using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    [MetadataType(typeof(ContentPageMetaData))]
    public partial class ContentPage
    {
        [NotMapped]
        public string Author { get; set; }
    }

    public class ContentPageMetaData
    {
        [DataType(DataType.MultilineText)]
        public string Html { get; set; }
    }
}
