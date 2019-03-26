using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Estacionamento.Map;

namespace Infra.Mapeamentos
{
    public class MappingSolicitacoesVagas : EntityTypeConfiguration<SolicitacoesVagasMap>
    {
        public MappingSolicitacoesVagas()
        {
            // Primary Key
            this.HasKey(t => t.IdSolicitacao);

            // Properties
            this.Property(t => t.IdUser)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserCancel)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.IdUser)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("SolicitacoesMap");           

            // Relationships
            HasOptional(s => s.PessoaMap)
                .WithRequired(s => s.SolicitacaoVaga);

            HasRequired(x => x.AspNetUserCadastro)
                .WithMany(x => x.SolicitacoesVagasCadastro)
                .HasForeignKey(x => x.IdUser);

            HasRequired(x => x.AspNetUserCancel)
                .WithMany(x => x.SolicitacoesVagasCancel)
                .HasForeignKey(x => x.UserCancel);   

        }
    }
}
