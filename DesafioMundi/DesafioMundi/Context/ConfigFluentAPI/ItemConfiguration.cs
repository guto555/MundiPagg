﻿using DesafioMundi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMundi.Context.ConfigFluentAPI
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>

    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasKey(x => x.Id);
        }
    }
}
