using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Acesso.Mapeamentos;

namespace Welic.Infra.Mapeamentos
{
    public class MapeamentoDispositivos
        : EntityTypeConfiguration<DispositivosMap>
    {
        public MapeamentoDispositivos()
        {
            ToTable("Dispositivos");

            HasKey(x => x.Id);
            Property(x => x.Id)                
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.Sharedkey)                
                .HasColumnType("varchar");
            Property(x => x.Plataforma)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.DeviceName)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.Version)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.NameUser)                
                .HasColumnType("varchar");
            Property(x => x.DateSynced)
                .IsRequired()
                .HasColumnType("datetime");
            Property(x => x.DateLastSynced)
                .IsRequired()
                .HasColumnType("datetime");
            Property(x => x.Status)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.EmailUsuario)
                .IsRequired()
                .HasColumnType("varchar");
        }
    }
}
