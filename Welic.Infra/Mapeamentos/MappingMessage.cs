using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    public class MappingMessage : EntityTypeConfiguration<Message>
    {
        public MappingMessage()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Body)
                .IsRequired();

            this.Property(t => t.UserFrom)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Message");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.MessageThreadID).HasColumnName("MessageThreadID");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.UserFrom).HasColumnName("UserFrom");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.UserFrom).WillCascadeOnDelete();
            this.HasRequired(t => t.MessageThread)
                .WithMany(t => t.Messages)
                .HasForeignKey(d => d.MessageThreadID);

        }
    }
}
