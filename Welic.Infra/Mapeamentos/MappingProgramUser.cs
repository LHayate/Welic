using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Infra.Mapeamentos
{
    class MappingProgramUser
        : EntityTypeConfiguration<ProgramUserMap>
    {
        public MappingProgramUser()
        {
            ToTable("ProgramUser");

            Property(x => x.Create)
                .IsRequired()
                .HasColumnName("Create")
                .HasColumnType("bit");
            Property(x => x.Read)
                .IsRequired()
                .HasColumnName("Read")
                .HasColumnType("bit");
            Property(x => x.Update)
                .IsRequired()
                .HasColumnName("Update")
                .HasColumnType("bit");
            Property(x => x.Delete)
                .IsRequired()
                .HasColumnName("Delete")
                .HasColumnType("bit");


        }
    }
}
