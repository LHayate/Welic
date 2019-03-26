using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    public class MappingSettingDictionary : EntityTypeConfiguration<SettingDictionary>
    {
        public MappingSettingDictionary()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Value)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("SettingDictionary");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.SettingID).HasColumnName("SettingID");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");

            // Relationships
            this.HasRequired(t => t.Setting)
                .WithMany(t => t.SettingDictionaries)
                .HasForeignKey(d => d.SettingID);

        }
    }
}
