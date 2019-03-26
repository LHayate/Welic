using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Estacionamento.Map;

namespace Infra.Mapeamentos
{
    public class MappingSolicitacoesVagasLiberadas : EntityTypeConfiguration<SolicitacoesVagasLiberadasMap>
    {
        public MappingSolicitacoesVagasLiberadas()
        {
            // Primary Key
            this.HasKey(t => t.Vaga);

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
            this.ToTable("SolicitacoesVagasLiberadas");


            // Relationships
            HasRequired(s => s.EstacionamentoMap)
                .WithMany(t => t.SolicitacoesVagasLiberadas)
                .HasForeignKey(x => x.IdEstacionamento);

            //HasRequired(s => s.AspNetUser)
            //    .WithMany(t => t.SolicitacoesVagasLiberadas)
            //    .HasForeignKey(x => x.IdUser);

            //HasRequired(s => s.NetUserCancel)
            //    .WithMany(t => t.SolicitacoesVagasLiberadasCancel)
            //    .HasForeignKey(x => x.IdUserCancel);

            //HasRequired(s => s.NetUserSuspensao)
            //    .WithMany(t => t.SolicitacoesVagasLiberadasSuspensao)
            //    .HasForeignKey(x => x.IdUserSuspensao);

            HasRequired(s => s. VeiculosMap)
                .WithMany(t => t.SolicitacoesVagasLiberadas)
                .HasForeignKey(x => x.IdVeiculo);

        }
    }
}
