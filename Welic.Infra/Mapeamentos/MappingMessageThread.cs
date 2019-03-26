using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    public class MappingMessageThread : EntityTypeConfiguration<MessageThread>
    {
        public MappingMessageThread()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Subject)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MessageThread");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.ListingID).HasColumnName("ListingID");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");

            // Relationships
            this.HasOptional(t => t.Listing)
                .WithMany(t => t.MessageThreads)
                .HasForeignKey(d => d.ListingID);

        }
    }
}
