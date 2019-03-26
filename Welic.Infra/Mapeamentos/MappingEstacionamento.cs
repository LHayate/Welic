using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Estacionamento.Map;

namespace Infra.Mapeamentos
{
    class MappingEstacionamento : EntityTypeConfiguration<EstacionamentoMap>
    {
        public MappingEstacionamento()
        {
            // Primary Key
            HasKey(t => t.IdEstacionamento);

            // Properties
            Property(x => x.IdEstacionamento)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            ToTable("Estacionamento");
            Property(t => t.IdEstacionamento).HasColumnName("IdEstacionamento");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Relacao).HasColumnName("Relacao");
            Property(t => t.TipoIdentificacao).HasColumnName("TipoIdentificacao");
            Property(t => t.ValidaVencimento).HasColumnName("ValidaVencimento");
            
            // Relationships
           
        }
    }
}
