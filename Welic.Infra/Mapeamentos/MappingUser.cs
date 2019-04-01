using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Infra.Mapeamentos
{
    public class MappingUser
        : EntityTypeConfiguration<AspNetUser>
    {
        public MappingUser()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Email)
                .HasMaxLength(256);

            this.Property(t => t.NickName)
                .IsRequired()
                .HasMaxLength(256);

            //this.Property(x => x.EmpresaId)
            //    .IsRequired();

            // Table & Column Mappings
            this.ToTable("AspNetUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.RegisterDate).HasColumnName("RegisterDate");
            this.Property(t => t.RegisterIP).HasColumnName("RegisterIP");
            this.Property(t => t.LastAccessDate).HasColumnName("LastAccessDate");
            this.Property(t => t.LastAccessIP).HasColumnName("LastAccessIP");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.AcceptEmail).HasColumnName("AcceptEmail");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.LeadSourceID).HasColumnName("LeadSourceID");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            this.Property(t => t.Password).HasColumnName("PasswordHash");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
            this.Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            this.Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
            this.Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
            this.Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");
            this.Property(t => t.NickName).HasColumnName("UserName");
            this.Property(t => t.Disabled).HasColumnName("Disabled");
            this.Property(t => t.Rating).HasColumnName("Rating");
            //this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            //ToTable("AspNetUser", "dbo");
            //HasKey(x => x.Id);            

            //Property(x => x.Id)
            //    .HasColumnName("UserId")          
            //    .IsRequired()                
            //    .HasColumnType("int")
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Guid)
                .HasColumnName("Guid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            //Property(x => x.Email)
            //    .IsRequired()
            //    .HasColumnType("nvarchar")
            //    .HasColumnName("Email");
            //Property(x => x.EmailConfirmed)
            //    .IsRequired()
            //    .HasColumnType("bit");
            //Property(x => x.NickName)                
            //    .HasColumnType("varchar")
            //    .HasColumnName("NickName");
            //Property(x => x.Password)
            //    .HasMaxLength(20)
            //    .IsRequired()
            //    .HasColumnType("nvarchar");
            //Property(x => x.FirstName)                
            //    .HasColumnName("FirstName")
            //    .HasColumnType("varchar");
            //Property(x => x.LastName)                
            //    .HasColumnType("varchar");            
            //Property(x => x.PhoneNumber)                
            //    .HasColumnName("PhoneNumber")
            //    .HasColumnType("varchar");
            //Property(x => x.PhoneNumberConfirmed)
            //    .IsRequired()
            //    .HasColumnType("bit")
            //    .HasColumnName("PhoneNumberConfirmed");
            Property(x => x.ImagePerfil)
                .HasColumnName("ImagePerfil")
                .HasColumnType("varchar")
                ;
            Property(x => x.Identity)
                .HasColumnType("varchar");
            //Property(x => x.LastAcess)
            //    .IsRequired()
            //    .HasColumnType("datetime")
            //    .HasColumnName("LastAcess");
            Property(x => x.Profession)
                .HasColumnName("Profession")
                .HasColumnType("int");


            //HasRequired(x => x.GroupUserMap)
            //    .WithMany(p => p.Users)                
            //    .WillCascadeOnDelete()
            //    ;

            //this.Property(t => t.RegisterDate).HasColumnName("RegisterDate");
            //this.Property(t => t.RegisterIP).HasColumnName("RegisterIP");            
            //this.Property(t => t.LastAccessIP).HasColumnName("LastAccessIP");
            //this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            //this.Property(t => t.AcceptEmail).HasColumnName("AcceptEmail");
            //this.Property(t => t.Gender).HasColumnName("Gender");
            //this.Property(t => t.LeadSourceID).HasColumnName("LeadSourceID");                        
            //this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");            
            //this.Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            //this.Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
            //this.Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
            //this.Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");            
            //this.Property(t => t.Disabled).HasColumnName("Disabled");
            //this.Property(t => t.Rating).HasColumnName("Rating");


        }

    }
}
