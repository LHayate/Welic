using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Departamento.Map;

namespace Infra.Mapeamentos
{
    public class MappingDepartamento : EntityTypeConfiguration<DepartamentoMap>
    {
        public MappingDepartamento()
        {
            // Primary Key
            this.HasKey(t => t.IdDepartamento);

            // Properties
          

            // Table & Column Mappings
            this.ToTable("Departamentos");
            this.Property(t => t.IdDepartamento).HasColumnName("IdDepartamento");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.IdEmpresa).HasColumnName("IdEmpresa");


            // Relationships
            this.HasMany(t => t.AspNetUsers)
                .WithMany(t => t.Departamentos)
                .Map(m =>
                {
                    m.ToTable("DepartamentoUsuario");
                    m.MapLeftKey("IdDepartamento");
                    m.MapRightKey("UserId");
                });
        }
    }
}
