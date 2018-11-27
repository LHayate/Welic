using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Curso.Map;

namespace Welic.Infra.Mapeamentos
{
    public class MappingCursos: EntityTypeConfiguration<CursoMap>
    {
        public MappingCursos()
        {
            ToTable("cursos");
            HasKey(x => x.IdCurso);

       
            Property(x => x.IdCurso)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.AuthorId)
                .IsRequired()
                .HasMaxLength(128);


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

          


            this.Property(t => t.AuthorId).HasColumnName("AuthorId");

            //One to Many
            HasRequired(c1 => c1.AspNetUser)
                .WithMany(c2 => c2.Cursos)
                .HasForeignKey(s=> s.AuthorId).WillCascadeOnDelete();
        }
    }
}
