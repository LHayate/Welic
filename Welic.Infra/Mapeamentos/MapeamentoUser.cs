using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Infra.Mapeamentos
{
    public class MapeamentoUser
        : EntityTypeConfiguration<UserMap>
    {
        public MapeamentoUser()
        {
            ToTable("UserInfo","dbo");
            HasKey(x => x.Id);
            HasKey(x => x.Email);

            Property(x => x.Id)
                .HasColumnName("Id")          
                .IsRequired()                
                .HasColumnType("int");
            Property(x => x.Guid)
                .HasColumnName("Guid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            Property(x => x.EmailConfirmed)
                .IsRequired()
                .HasColumnType("bit");            
            Property(x => x.Email)                
                .IsRequired()
                .HasColumnType("nvarchar");
           
            Property(x => x.Password)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("nvarchar");
            Property(x => x.NomeCompleto)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .HasColumnName("NameComplete");
            Property(x => x.ImagemPerfil)
                .HasColumnName("ImagePerfil")
                .HasColumnType("image");
            Property(x => x.PhoneNumber)
                .IsRequired()
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar");
            


        }
        
    }
}
