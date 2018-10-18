using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Maps;

namespace Welic.Infra.Mapeamentos
{
    class MapeamentoLive
        : EntityTypeConfiguration<LiveMap>
    {
        public MapeamentoLive()
        {
            ToTable("Lives");
            HasKey(x => x.Id);
            

            Property(x => x.Id)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Id");
            Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("Title");
            Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("Description");
            Property(x => x.Prince)
                .IsRequired()
                .HasColumnType("decimal")
                .HasColumnName("Prince");
            Property(x => x.Print)
                .IsOptional()
                .HasColumnType("image")
                .HasColumnName("Print");
            Property(x => x.Themes)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("Theme");
            Property(x => x.Chat)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("Chat");
            Property(x => x.UrlDestino)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("UrlDestino");

            //One to Many
            HasRequired(c1 => c1.Author)
                .WithMany(c2 => c2.Lives)
                .WillCascadeOnDelete();

        }
    }
}
