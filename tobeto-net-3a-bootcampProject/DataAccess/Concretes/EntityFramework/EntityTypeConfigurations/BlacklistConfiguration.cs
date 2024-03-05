using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
    {
        public void Configure(EntityTypeBuilder<Blacklist> builder)
        {
            builder.ToTable("Blacklists").HasKey(u => u.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Reason).IsRequired().HasMaxLength(150).HasColumnName("Reason");
            builder.Property(x => x.Date).IsRequired().HasColumnName("Date");
            builder.Property(x => x.ApplicantId).IsRequired().HasColumnName("ApplicantId");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");


            builder.HasOne(x => x.Applicant); //one to one
        }
    }
}
