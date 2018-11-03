using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.Infra.Mapeamentos
{
    class MappingCategoryListingType : EntityTypeConfiguration<CategoryListingType>
    {
        public MappingCategoryListingType()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CategoryListingTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.ListingTypeID).HasColumnName("ListingTypeID");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.CategoryListingTypes)
                .HasForeignKey(d => d.CategoryID).WillCascadeOnDelete();
            this.HasRequired(t => t.ListingType)
                .WithMany(t => t.CategoryListingTypes)
                .HasForeignKey(d => d.ListingTypeID).WillCascadeOnDelete();
        }
    }
}
