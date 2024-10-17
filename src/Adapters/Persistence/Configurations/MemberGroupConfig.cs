using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MemberGroupConfig : IEntityTypeConfiguration<MemberGroup>
    {

        public void Configure(EntityTypeBuilder<MemberGroup> builder)
        {
            builder.HasKey(mg => mg.Id);
            builder.Property(mg => mg.Status).IsRequired();

            builder.HasOne<User>().WithMany().HasForeignKey(mg => mg.UserId);
        }
    }
}