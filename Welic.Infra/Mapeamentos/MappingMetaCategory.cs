using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.Infra.Mapeamentos
{
    public class MappingMetaCategory : EntityTypeConfiguration<MetaCategory>
    {
        public MappingMetaCategory()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MetaCategories");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.FieldID).HasColumnName("FieldID");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.MetaCategories)
                .HasForeignKey(d => d.CategoryID).WillCascadeOnDelete();
            this.HasRequired(t => t.MetaField)
                .WithMany(t => t.MetaCategories)
                .HasForeignKey(d => d.FieldID).WillCascadeOnDelete();

        }
    }
}
