using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Uploads.Maps;


namespace Welic.Infra.Mapeamentos
{
    class MappingUploads:EntityTypeConfiguration<UploadsMap>
    {
        public MappingUploads()
        {
            // Primary Key
            this.HasKey(t => t.UploadId);

            // Properties
            this.Property(t => t.UploadId)
                .IsRequired() ;

            this.Property(t => t.Path)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Uploads");
            this.Property(t => t.UploadId).HasColumnName("UploadId");
            this.Property(t => t.Path).HasColumnName("Path");
            this.Property(t => t.UserId).HasColumnName("UserId");

            //One to Many
            HasRequired(c1 => c1.User)
                .WithMany(c2 => c2.Uploads)  
                .HasForeignKey(x=> x.UserId)
                .WillCascadeOnDelete();            
        }
    }
}
