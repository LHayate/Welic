using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Client.Map;

namespace Infra.Mapeamentos
{
    public class MappingPessoa : EntityTypeConfiguration<PessoaMap>
    {
        public MappingPessoa()
        {
            // Primary Key
            this.HasKey(t => t.IdPessoa);

            // Properties           
            this.Property(x => x.IdPessoa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(256);
            this.Property(x => x.TelComercial)
                .IsRequired()
                .HasMaxLength(11);
            this.Property(x => x.Celular)
                .IsRequired()
                .HasMaxLength(12);
            
            // Table & Column Mappings
            this.ToTable("Pessoas");
            this.Property(t => t.IdPessoa).HasColumnName("IdPessoa");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(x => x.DataNascimeto).HasColumnName("DataNascimento");
            this.Property(x => x.Sexo).HasColumnName("Sexo");
            this.Property(x => x.EstadoCivil).HasColumnName("EstadoCivil");
            this.Property(x => x.NomePai).HasColumnName("NomePai");
            this.Property(x => x.NomeMae).HasColumnName("NomeMae");
            this.Property(x => x.Naturalidade).HasColumnName("Naturalidade");
            this.Property(x => x.Nacionalidade).HasColumnName("Nacionalidade");

            this.Property(x => x.Identidade).HasColumnName("Identidade");
            this.Property(x => x.DataExpedicao).HasColumnName("DataExpedicao");
            this.Property(x => x.OrgaoExpeditor).HasColumnName("OrgaoExpeditor");
            this.Property(x => x.UfExpeditor).HasColumnName("UfExpeditor");
            this.Property(x => x.Cpf).HasColumnName("Cpf");
            this.Property(x => x.TituloEleitor).HasColumnName("TituloEleitor");
            this.Property(x => x.Zona).HasColumnName("Zona");
            this.Property(x => x.Secao).HasColumnName("Secao");

            this.Property(x => x.Endereco).HasColumnName("Endereco");
            this.Property(x => x.Numero).HasColumnName("Numero");
            this.Property(x => x.Cep).HasColumnName("Cep");
            this.Property(x => x.Cidade).HasColumnName("Cidade");
            this.Property(x => x.Complemento).HasColumnName("Complemento");

            this.Property(x => x.Telefone).HasColumnName("Telefone");
            this.Property(x => x.TelComercial).HasColumnName("TelComercial");
            this.Property(x => x.Email).HasColumnName("Email");
            this.Property(x => x.EmailCorporativo).HasColumnName("EmailCorporativo");
            


           
        }
    }
}
