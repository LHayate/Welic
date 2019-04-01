using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Models.Fazenda.Map;

namespace Infra.Mapeamentos
{
    public class MappingFazendas : EntityTypeConfiguration<FazendasMap>
    {
        public MappingFazendas()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties




            //One to Many            
            HasRequired(c1 => c1.AspNetUser)
                .WithMany(c2 => c2.FazendasMap)
                .HasForeignKey(x => x.IdUser)
                .WillCascadeOnDelete();
        }
    }
}
