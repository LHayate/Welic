using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Estacionamento.Map;

namespace Infra.Mapeamentos
{
    public class MappingSolicitacoesEstacionamento : EntityTypeConfiguration<SolicitacoesEstacionamentoMap>
    {
        public MappingSolicitacoesEstacionamento()
        {
            // Primary Key
            this.HasKey(t => t.Solicitacao);

            // Properties
            

            // Table & Column Mappings
            this.ToTable("SolicitacoesEstacionamento");
            

            // Relationships
            HasRequired(s => s.EstacionamentoMap)
                .WithMany(t => t.SolicitacoesEstacionamento)
                .HasForeignKey(x => x.Estacionamento);
        }
    }
}
