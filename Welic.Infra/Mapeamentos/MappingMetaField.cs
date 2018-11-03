using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.Infra.Mapeamentos
{
    public class MappingMetaField : EntityTypeConfiguration<MetaField>
    {
        public MappingMetaField()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Placeholder)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MetaFields");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Placeholder).HasColumnName("Placeholder");
            this.Property(t => t.ControlTypeID).HasColumnName("ControlTypeID");
            this.Property(t => t.Options).HasColumnName("Options");
            this.Property(t => t.Required).HasColumnName("Required");
            this.Property(t => t.Searchable).HasColumnName("Searchable");
            this.Property(t => t.Ordering).HasColumnName("Ordering");
        }
    }
}
