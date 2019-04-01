using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Infra.Mapeamentos
{
    class MappingAspNetRole : EntityTypeConfiguration<AspNetRole>
    {
        public MappingAspNetRole()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("AspNetRoles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasMany(t => t.AspNetUsers)
                .WithMany(t => t.AspNetRoles)
                .Map(m =>
                {
                    m.ToTable("AspNetUserRoles");
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                });



        }
    }
}
