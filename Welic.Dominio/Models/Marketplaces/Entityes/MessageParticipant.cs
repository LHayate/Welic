using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Entidades;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class MessageParticipant : Entity
    {
        public int ID { get; set; }
        public int MessageThreadID { get; set; }
        public string UserID { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual MessageThread MessageThread { get; set; }
    }
}
