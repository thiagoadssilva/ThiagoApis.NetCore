﻿using ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pessoa");
            builder.HasKey(x => x.Id); 

            builder.Property(x => x.Id).HasColumnName("idpessoa").UseMySqlIdentityColumn();
            builder.Property(x => x.Document).HasColumnName("documento");
            builder.Property(x => x.Name).HasColumnName("nome");
            builder.Property(x => x.Phone).HasColumnName("celular");

            builder.HasMany(c => c.Purchases).WithOne(p => p.Person).HasForeignKey(x => x.PersonId);
        }
    }
}
