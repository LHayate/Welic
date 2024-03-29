﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Infra.Mapeamentos
{
    public class MappingStripeTransaction : EntityTypeConfiguration<StripeTransaction>
    {
        public MappingStripeTransaction()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ChargeID)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.StripeToken)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.StripeEmail)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.FailureCode)
                .HasMaxLength(100);

            this.Property(t => t.FailureMessage)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("StripeTransaction");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.ChargeID).HasColumnName("ChargeID");
            this.Property(t => t.StripeToken).HasColumnName("StripeToken");
            this.Property(t => t.StripeEmail).HasColumnName("StripeEmail");
            this.Property(t => t.IsCaptured).HasColumnName("IsCaptured");
            this.Property(t => t.FailureCode).HasColumnName("FailureCode");
            this.Property(t => t.FailureMessage).HasColumnName("FailureMessage");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
        }
    }
}
