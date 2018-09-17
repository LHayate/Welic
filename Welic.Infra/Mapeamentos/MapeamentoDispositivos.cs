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
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.Plataforma)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.DeviceName)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.Versao)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.NomeUsuario)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.Dt_Sincronismo)
                .IsRequired()
                .HasColumnType("datetime");
            Property(x => x.Dt_UltimoEnvio)
                .IsRequired()
                .HasColumnType("datetime");
            Property(x => x.Situacao)
                .IsRequired()
                .HasColumnType("varchar");
            Property(x => x.IdUsuario)
                .IsRequired()
                .HasColumnType("varchar");
        }
    }
}
