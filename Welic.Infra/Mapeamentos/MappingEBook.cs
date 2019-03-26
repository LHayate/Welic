using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.EBook.Map;

namespace Infra.Mapeamentos
{
    public class MappingEBook: EntityTypeConfiguration<EBookMap>
    {
        public MappingEBook()
        {
            ToTable("Ebooks");
            HasKey(x => x.Id);


            Property(x => x.Id)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("Title");
            Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("Description");
            Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasColumnName("Prince");
            Property(x => x.Print)
                .IsOptional()
                .HasColumnType("varchar")
                .HasColumnName("Print");
            Property(x => x.Themes)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("Theme");      
            Property(x => x.UrlDestino)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("UrlDestino");
            Property(x => x.DateRegister)
                .IsRequired()
                .HasColumnName("DateRegister")
                .HasColumnType("datetime");



            // Properties
            this.Property(t => t.TeacherId)
                .IsRequired()
                .HasMaxLength(128);


            //One to One 
            //HasRequired(s => s.Schedules)
            //    .WithRequiredPrincipal(ad => ad.Ebook);


            //One to Many            
            HasRequired(c1 => c1.TeacherUser)
                .WithMany(c2 => c2.EbookTeacher)
                .HasForeignKey(x => x.TeacherId)
                .WillCascadeOnDelete();


            //Many to Many
            HasMany(p => p.ClassUser)
                .WithMany(c => c.EBookClass)
                .Map(c =>
                {
                    c.MapLeftKey("BookId");
                    c.MapRightKey("UserId");
                    c.ToTable("EbookClass");
                })
                ;
            HasMany(p => p.Courses)
                .WithMany(c => c.Ebook)
                .Map(c =>
                {
                    c.MapLeftKey("BookId");
                    c.MapRightKey("CourseId");
                    c.ToTable("CourseEbook");
                })
                ;
        }
    }
}
