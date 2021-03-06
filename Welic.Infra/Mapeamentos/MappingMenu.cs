﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Entidades;
using Welic.Dominio.Models.Menu.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class MappingMenu
        : EntityTypeConfiguration<MenuMap>
    {
        public MappingMenu()
        {
            ToTable("MasterMenus");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .IsRequired()
                .HasColumnName("IdMenu")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("varchar");
            Property(x => x.IconMenu)
                .IsRequired()
                .HasColumnName("IconMenu")
                .HasColumnType("varchar");

            Property(x => x.DadId).HasColumnName("DadId");
            Property(x => x.Nivel).HasColumnName("Nivel");            
            Property(x => x.Action).HasColumnName("Action");
            Property(x => x.Controller).HasColumnName("Controller");
            //Property(x => x.GroupAcess).HasColumnName("GroupAcess");


            HasMany(e => e.Usuarios)
                .WithMany(p => p.Menus)
                .Map(ep =>
                        {
                            ep.MapLeftKey("IdMenu");
                            ep.MapRightKey("UserId");
                            ep.ToTable("MenusUser");
                        });
        }
    }
}
