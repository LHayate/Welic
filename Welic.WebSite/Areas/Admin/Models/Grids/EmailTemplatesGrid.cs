using GridMvc;
using System.Linq;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.WebSite.Areas.Admin.Models
{
    public class EmailTemplatesGrid : Grid<EmailTemplate>
    {
        public EmailTemplatesGrid(IQueryable<EmailTemplate> emailTemplate)
            : base(emailTemplate)
        {
        }
    }
}