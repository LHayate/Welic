using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.ConfigApp.Map;

namespace Welic.Infra.Mapeamentos
{
    public class MappingConfigApp : EntityTypeConfiguration<ConfigAppMap>
    {
        public MappingConfigApp()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Biometria)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ConfigApp");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Biometria).HasColumnName("Biometria");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            //this.HasOptional(t => t.AspNetUser)
            //    .WithRequired(t => t.ConfigApp)
            //    ;
        }
    }
}
