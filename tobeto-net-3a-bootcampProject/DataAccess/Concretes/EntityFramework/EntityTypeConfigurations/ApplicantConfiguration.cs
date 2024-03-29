﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("Applicants");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(a => a.About).IsRequired().HasMaxLength(500).HasColumnName("About");

            builder.HasMany(x => x.Applications); //one to many
            builder.HasOne(x => x.Blacklist); //one to one
        }
    }
}
