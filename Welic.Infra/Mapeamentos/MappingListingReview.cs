using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    public class MappingListingReview : EntityTypeConfiguration<ListingReview>
    {
        public MappingListingReview()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(250);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.UserFrom)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserTo)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("ListingReviews");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Rating).HasColumnName("Rating");
            this.Property(t => t.ListingID).HasColumnName("ListingID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.UserFrom).HasColumnName("UserFrom");
            this.Property(t => t.UserTo).HasColumnName("UserTo");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
            this.Property(t => t.Spam).HasColumnName("Spam");
            this.Property(t => t.Created).HasColumnName("Created");

            // Relationships
            this.HasRequired(t => t.AspNetUserFrom)
                .WithMany(t => t.ListingReviewsUserFrom)
                .HasForeignKey(d => d.UserFrom);

            this.HasRequired(t => t.AspNetUserTo)
                .WithMany(t => t.ListingReviewsUserTo)
                .HasForeignKey(d => d.UserTo);

            this.HasOptional(t => t.Listing)
                .WithMany(t => t.ListingReviews)
                .HasForeignKey(d => d.ListingID).WillCascadeOnDelete();

            this.HasOptional(t => t.Order)
                .WithMany(t => t.ListingReviews)
                .HasForeignKey(d => d.OrderID).WillCascadeOnDelete();

        }
    }
}
