using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Infra.Mapeamentos
{
    public class MappingGroupUser
        : EntityTypeConfiguration<GroupUserMap>
    {
        public MappingGroupUser()
        {
            ToTable("GroupUser");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar");
            Property(x => x.Nivel)
                .IsRequired()
                .HasColumnName("nivel")
                .HasColumnType("int") ;

            

        }
    }
}
