using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Schedule.Maps;

namespace Welic.Infra.Mapeamentos
{
    public class MapeamentoSchedule
        : EntityTypeConfiguration<ScheduleMap>
    {
        public MapeamentoSchedule()
        {
            ToTable("Schedules");
            HasKey(x => x.ScheduleId);

            Property(x => x.ScheduleId)
                .IsRequired()
                .HasColumnName("ScheduleId")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnName("Title");
            Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar");
            Property(x => x.Prince)
                .IsRequired()
                .HasColumnName("Prince")
                .HasColumnType("decimal");
            Property(x => x.Private)
                .IsRequired()
                .HasColumnName("Private")
                .HasColumnType("bit");
            Property(x => x.Ativo)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("Ativo");
            Property(x => x.DateEvent)
                .IsRequired()
                .HasColumnName("DateEvent")
                .HasColumnType("datetime");


            HasMany(p => p.UserClass)
                .WithMany(c => c.SchedulesClass)
                .Map(manytoMany => manytoMany
                    .ToTable("ScheduleClass")
                    .MapLeftKey("ScheduleId")
                    .MapRightKey("Id"));

            //One to Many
            //HasRequired(c1 => c1.UserTeacher)
            //    .WithMany(c2 => c2.SchedulesTeacher)
            //    .WillCascadeOnDelete();

            //One to One
            //HasRequired(s => s.Live)
            //    .WithRequiredPrincipal(c => c.Lives);
            
                        


        }
    }
}