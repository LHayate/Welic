using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.Infra.Mapeamentos
{
    class MappingListingMeta : EntityTypeConfiguration<ListingMeta>
    {
        public MappingListingMeta()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Value)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ListingMeta");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ListingID).HasColumnName("ListingID");
            this.Property(t => t.FieldID).HasColumnName("FieldID");
            this.Property(t => t.Value).HasColumnName("Value");

            // Relationships
            this.HasRequired(t => t.Listing)
                .WithMany(t => t.ListingMetas)
                .HasForeignKey(d => d.ListingID).WillCascadeOnDelete();
            this.HasRequired(t => t.MetaField)
                .WithMany(t => t.ListingMetas)
                .HasForeignKey(d => d.FieldID).WillCascadeOnDelete();
        }
    }
}
