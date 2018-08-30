using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Infra.Mapeamentos
{
    public class MapeamentoLogin
        : EntityTypeConfiguration<UserMap>
    {
        public MapeamentoLogin()
        {
            ToTable("Login");

            HasKey(x => x.Email);

            Property(x => x.Email)
                .HasMaxLength(60)
                .IsRequired()
                .HasColumnType("varchar");

            Property(x => x.Password)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("varchar");            
            Property(x => x.RememberMe)
                .HasColumnType("bit");

        }
        
    }
}
