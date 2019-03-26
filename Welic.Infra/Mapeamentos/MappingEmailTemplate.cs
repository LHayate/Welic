using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    class MappingEmailTemplate : EntityTypeConfiguration<EmailTemplate>
    {
        public MappingEmailTemplate()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Slug)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Body)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("EmailTemplates");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Slug).HasColumnName("Slug");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.SendCopy).HasColumnName("SendCopy");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
        }
    }
}
