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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("idproduto").UseMySqlIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Coderp).HasColumnName("codErp");
            builder.Property(x => x.Price).HasColumnName("preco");

            builder.HasMany(c => c.Purchases).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
