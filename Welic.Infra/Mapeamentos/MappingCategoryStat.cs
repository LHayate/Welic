using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.Infra.Mapeamentos
{
    class MappingCategoryStat : EntityTypeConfiguration<CategoryStat>
    {
        public MappingCategoryStat()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CategoryStats");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Count).HasColumnName("Count");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.CategoryStats)
                .HasForeignKey(d => d.CategoryID).WillCascadeOnDelete();
        }
    }
}
