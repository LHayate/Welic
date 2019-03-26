using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    public class MappingPicture : EntityTypeConfiguration<Picture>
    {
        public MappingPicture()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.MimeType)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.SeoFilename)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Pictures");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.MimeType).HasColumnName("MimeType");
            this.Property(t => t.SeoFilename).HasColumnName("SeoFilename");
        }
    }
}
