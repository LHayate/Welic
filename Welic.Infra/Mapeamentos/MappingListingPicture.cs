using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    class MappingListingPicture : EntityTypeConfiguration<ListingPicture>
    {
        public MappingListingPicture()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ListingPictures");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ListingID).HasColumnName("ListingID");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
            this.Property(t => t.Ordering).HasColumnName("Ordering");

            // Relationships
            this.HasRequired(t => t.Listing)
                .WithMany(t => t.ListingPictures)
                .HasForeignKey(d => d.ListingID).WillCascadeOnDelete();
            this.HasRequired(t => t.Picture)
                .WithMany(t => t.ListingPictures)
                .HasForeignKey(d => d.PictureID).WillCascadeOnDelete();
        }
    }
}
