using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Schedule.Maps;

namespace Welic.Infra.Mapeamentos
{
    public class MappingSchedule
        : EntityTypeConfiguration<ScheduleMap>
    {
        public MappingSchedule()
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

            Property(x => x.Price)
                .IsRequired()
                .HasColumnName("Price")
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

            Property(t => t.TeacherId)
                .IsRequired()
                .HasMaxLength(128);

            //Many to Many
            HasMany(p => p.UserClass)
                .WithMany(c => c.SchedulesAluno)
                .Map(c =>
                {
                    c.MapLeftKey("ScheduleId");
                    c.MapRightKey("UserId");
                    c.ToTable("ScheduleClass");
                })
                ;

            //One to Many
            HasRequired(c1 => c1.UserTeacher)
                .WithMany(c2 => c2.SchedulesTeacher)
                .HasForeignKey(x => x.TeacherId)
                .WillCascadeOnDelete();

            //One to One
            //HasRequired(s => s.Live)
            //    .WithRequiredPrincipal(t => t.Lives);

        }
    }
}