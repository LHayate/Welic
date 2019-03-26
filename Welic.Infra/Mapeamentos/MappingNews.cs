using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.News.Maps;

namespace Infra.Mapeamentos
{
    public class MappingNews
        : EntityTypeConfiguration<NewsMap>
    {
        public MappingNews()
        {
            ToTable("News");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired()
                .HasColumnName("IdNews")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("varchar");
            Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar");
            Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("datetime");
            Property(x => x.Url)
                .IsRequired()
                .HasColumnName("Url")
                .HasColumnType("varchar");

        }
    }
}
