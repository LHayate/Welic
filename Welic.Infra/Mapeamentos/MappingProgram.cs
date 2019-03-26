using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Segurança.Map;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class MappingProgram
    : EntityTypeConfiguration<ProgransMap>
    {
        public MappingProgram()
        {
            ToTable("Programs");
            HasKey(x => x.IdProgram);

            Property(x => x.IdProgram)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int");

            Property(x => x.Active)
                .IsRequired()
                .HasColumnName("Active")
                .HasColumnType("bit");

            Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar");
            Property(x => x.Type)
                .IsRequired()
                .HasColumnName("Type");
        }
    }
}
