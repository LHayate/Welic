using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    public class MappingListingStat : EntityTypeConfiguration<ListingStat>
    {
        public MappingListingStat()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ListingStats");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CountView).HasColumnName("CountView");
            this.Property(t => t.CountSpam).HasColumnName("CountSpam");
            this.Property(t => t.CountRepeated).HasColumnName("CountRepeated");
            this.Property(t => t.ListingID).HasColumnName("ListingID");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");

            // Relationships
            this.HasRequired(t => t.Listing)
                .WithMany(t => t.ListingStats)
                .HasForeignKey(d => d.ListingID).WillCascadeOnDelete();

        }
    }
}
