﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class BootcampStateConfigurations : IEntityTypeConfiguration<BootcampState>
    {
        public void Configure(EntityTypeBuilder<BootcampState> builder)
        {
            builder.ToTable("BootcampStates").HasKey(u => u.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(x => x.Bootcamp);
        }
    }
}
