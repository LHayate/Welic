using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Estacionamento.Map;

namespace Welic.Infra.Mapeamentos
{
    public class MappingVeiculos : EntityTypeConfiguration<VeiculosMap>
    {
        public MappingVeiculos()
        {
            // Primary Key
            HasKey(t => t.IdVeiculo);

            // Properties           

            // Table & Column Mappings
            ToTable("Veiculos");


            // Relationships
            HasRequired(x => x.PessoaMap)
                .WithMany(x => x.Veiculo)
                .HasForeignKey(x => x.IdPessoa);
        }
    }
}
