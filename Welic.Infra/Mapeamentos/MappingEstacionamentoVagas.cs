using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Estacionamento.Map;

namespace Infra.Mapeamentos
{
    public class MappingEstacionamentoVagas : EntityTypeConfiguration<EstacionamentoVagasMap>
    {
        public MappingEstacionamentoVagas()
        {
            // Primary Key
            this.HasKey(t => t.IdEstacionamento);

            // Properties
            //this.Property(t => t.IdUser)
            //    .IsRequired()
            //    .HasMaxLength(128);
            //this.Property(t => t.IdUserCancel)
            //    .IsRequired()
            //    .HasMaxLength(128);
            //this.Property(t => t.IdUserSuspensao)
            //    .IsRequired()
            //    .HasMaxLength(128);


            // Table & Column Mappings
            this.ToTable("EstacionamentoVagas");


            // Relationships
           
        }
    }
}
