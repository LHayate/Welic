using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Maps;

namespace Infra.Mapeamentos
{
    public class MappingFavoriteLive : EntityTypeConfiguration<FavoriteLiveMap>
    {
        public MappingFavoriteLive()
        {
            // Primary Key
            this.HasKey(t => t.IdFavorite);

            // Properties
            this.Property(t => t.IdUser)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.IdUser)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("LiveFavorite");
            this.Property(t => t.IdFavorite).HasColumnName("IdFavorite");            

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.FavoriteUserLive)
                .HasForeignKey(s => s.IdUser)                
                ;
                

            this.HasRequired(x => x.LiveMap)
                .WithMany(x => x.Favorites)
                .HasForeignKey(x => x.IdLive)                
                ;
        }
    }
}
