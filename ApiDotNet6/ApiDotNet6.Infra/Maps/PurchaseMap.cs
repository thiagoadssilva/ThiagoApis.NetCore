﻿using ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("compra");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("idcompra").UseMySqlIdentityColumn();
            builder.Property(x => x.ProductId).HasColumnName("idproduto");
            builder.Property(x => x.PersonId).HasColumnName("idpessoa");
            builder.Property(x => x.Date).HasColumnName("datacompra");

            builder.HasOne(x => x.Person).WithMany(x => x.Purchases);
            builder.HasOne(x => x.Product).WithMany(x => x.Purchases);
        }
    }
}
