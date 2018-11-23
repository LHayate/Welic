using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class MessageThread : Entity
    {
        public MessageThread()
        {
            this.Messages = new List<Message>();
            this.MessageParticipants = new List<MessageParticipant>();
        }

        public int ID { get; set; }
        public string Subject { get; set; }
        public Nullable<int> ListingID { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public virtual Listing Listing { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<MessageParticipant> MessageParticipants { get; set; }
    }
}
