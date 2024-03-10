using Core.Utilities.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims");

            builder.HasKey(x => new { x.UserId, x.OperationClaimId });
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId");

            //Relationships
            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.UserOperationClaims)
                .HasForeignKey(x => x.UserId);

            builder.HasOne<OperationClaim>(x => x.OperationClaim)
                .WithMany(x => x.UserOperationClaims)
                .HasForeignKey(x => x.OperationClaimId);
        }
    }
}
