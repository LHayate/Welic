using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    public class MappingMessageParticipant : EntityTypeConfiguration<MessageParticipant>
    {
        public MappingMessageParticipant()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UserID)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("MessageParticipant");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.MessageThreadID).HasColumnName("MessageThreadID");
            this.Property(t => t.UserID).HasColumnName("UserID");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.MessageParticipants)
                .HasForeignKey(d => d.UserID).WillCascadeOnDelete();
            this.HasRequired(t => t.MessageThread)
                .WithMany(t => t.MessageParticipants)
                .HasForeignKey(d => d.MessageThreadID);

        }
    }
}
