using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class Message : Entity
    {
        public Message()
        {
            this.MessageReadStates = new List<MessageReadState>();
        }

        public int ID { get; set; }
        public int MessageThreadID { get; set; }
        public string Body { get; set; }
        public string UserFrom { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual MessageThread MessageThread { get; set; }
        public virtual ICollection<MessageReadState> MessageReadStates { get; set; }
    }
}
