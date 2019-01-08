using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.City.Map;

namespace Welic.Infra.Mapeamentos
{
    public class MappingCity : EntityTypeConfiguration<CityMap>
    {
        public MappingCity()
        {
            // Primary Key
            this.HasKey(t => t.IdCity);

            // Properties           

            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(256);
            this.Property(x => x.IdCity)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Estado)
                .IsRequired();
            this.Property(x => x.Cep)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("City");
            this.Property(t => t.IdCity).HasColumnName("IdCity");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(x => x.Estado).HasColumnName("Estado");           
            this.Property(x => x.Cep).HasColumnName("Cep");           

        }
    }
}
