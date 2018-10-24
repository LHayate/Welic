using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Infra.Mapeamentos
{
    public class MappingProgram
    : EntityTypeConfiguration<ProgramsMap>
    {
        public MappingProgram()
        {
            ToTable("Programs");
            HasKey(x => x.Id);

            Property(x => x.Id)
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
        }
    }
}
