using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Empresa.Map;

namespace Infra.Mapeamentos
{
    public class MappingEmpresa : EntityTypeConfiguration<EmpresaMap>
    {
        public MappingEmpresa()
        {
            HasKey(p => p.IdEmpresa)
                .ToTable("Empresa", "dbo");

            Property(p => p.IdEmpresa)
                .IsRequired()                
                .HasColumnType("int");

            Property(p => p.RazaoSocial)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            Property(p => p.Cnpj)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar");

            Property(p => p.Ie)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");

            Property(p => p.Fone)
                .IsRequired()
                .HasColumnType("numeric")
                .HasPrecision(10, 0);

            Property(p => p.Fone1)
                .HasColumnType("numeric")
                .HasPrecision(10, 0);

            Property(p => p.FoneFax)
                .HasColumnType("numeric")
                .HasPrecision(10, 0);

            Property(p => p.Email)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            Property(p => p.Endereco)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(p => p.Cep)
                .HasMaxLength(8)
                .HasColumnType("nvarchar");

            Property(p => p.Imagem)
                .HasColumnType("image");

            Property(p => p.ConfigMailUser)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(p => p.ConfigMailSenha)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(p => p.ConfigMailSmtp)
                .HasMaxLength(100)
                .HasColumnType("varchar");

            Property(p => p.ConfigMailPorta)
                .HasColumnType("int");

            Property(p => p.InfFaturamento)
                .HasColumnType("text");

            Property(p => p.Cidade)
                .HasMaxLength(80)
                .HasColumnType("varchar");

            Property(p => p.Uf)
                .HasMaxLength(2)
                .HasColumnType("char");

            Property(p => p.ConfigMailEnableSsl)
                .HasColumnType("bit");

            //HasMany(p => p.Usuarios)
            //    .WithRequired(c => c.Empresa)
            //    .HasForeignKey(p => p.EmpresaId);
        }
    }
}
