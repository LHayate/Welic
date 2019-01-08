using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Segurança.Map;

namespace Welic.Infra.Mapeamentos
{
    class MappingPermission : EntityTypeConfiguration<PermissionMap>
    {
        public MappingPermission()
        {
            // Primary Key
            this.HasKey(t => t.IdPermissao);                     

            //Properties
            this.Property(x => x.IdPermissao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.IdUser)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Permissions");
            this.Property(t => t.IdPermissao).HasColumnName("IdPermission");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.All).HasColumnName("All");
            this.Property(t => t.Delete).HasColumnName("Delete");
            this.Property(t => t.Insert).HasColumnName("Insert");
            this.Property(t => t.Update).HasColumnName("Update");
            this.Property(t => t.IdUser).HasColumnName("idUser");
            this.Property(t => t.Read).HasColumnName("Read");



           


            // Relationships
            HasRequired(x => x.AspNetUser)
                .WithMany(x => x.Permission)
                .HasForeignKey(x => x.IdUser);
            HasRequired(x => x.ProgransMap)
                .WithMany(x => x.Permission)
                .HasForeignKey(x => x.IdProgram);
        }
    }
}
