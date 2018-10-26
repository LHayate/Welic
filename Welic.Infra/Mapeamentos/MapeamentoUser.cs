using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Infra.Mapeamentos
{
    public class MapeamentoUser
        : EntityTypeConfiguration<UserMap>
    {
        public MapeamentoUser()
        {
            ToTable("Users","dbo");
            HasKey(x => x.Id);            

            Property(x => x.Id)
                .HasColumnName("Id")          
                .IsRequired()                
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Guid)
                .HasColumnName("Guid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            Property(x => x.Email)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasColumnName("Email");
            Property(x => x.EmailConfirmed)
                .IsRequired()
                .HasColumnType("bit");
            Property(x => x.NickName)                
                .HasColumnType("varchar")
                .HasColumnName("NickName");
            Property(x => x.Password)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("nvarchar");
            Property(x => x.FirstName)                
                .HasColumnName("FirstName")
                .HasColumnType("varchar");
            Property(x => x.LastName)                
                .HasColumnType("varchar");
            Property(x => x.FullName)                
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .HasColumnName("NameComplete");
            Property(x => x.PhoneNumber)                
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar");
            Property(x => x.PhoneNumberConfirmed)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("PhoneNumberConfirmed");
            Property(x => x.ImagemPerfil)
                .HasColumnName("ImagePerfil")
                .HasColumnType("image");                        
            Property(x => x.Identity)                
                .HasColumnType("varchar");
            Property(x => x.LastAcess)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("LastAcess");
            Property(x => x.Profession)
                .HasColumnName("Profession")
                .HasColumnType("varchar");


            HasRequired(x => x.GroupUserMap)
                .WithMany(p => p.Users)                
                .WillCascadeOnDelete()
                ;
            
        }
        
    }
}
