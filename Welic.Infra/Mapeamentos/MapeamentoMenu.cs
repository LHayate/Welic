using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Mapeamentos;

namespace Welic.Infra.Mapeamentos
{
    public class MapeamentoMenu
        : EntityTypeConfiguration<MenuMap>
    {
        public MapeamentoMenu()
        {
            ToTable("MasterMenus");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int");
            Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("string");
            Property(x => x.IconMenu)
                .IsRequired()
                .HasColumnName("IconMenu")
                .HasColumnType("string");

        }
    }
}
