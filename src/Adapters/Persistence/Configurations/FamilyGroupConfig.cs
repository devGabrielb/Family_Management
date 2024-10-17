using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FamilyGroupConfig : IEntityTypeConfiguration<FamilyGroup>
    {
        public void Configure(EntityTypeBuilder<FamilyGroup> builder)
        {
            builder.HasKey(fg => fg.Id);
            builder.Property(fg => fg.Name).IsRequired();
            builder.Property(fg => fg.Description).IsRequired();
            builder.Property(fg => fg.CreatedAt).IsRequired();
            builder.Property(fg => fg.UpdatedAt).IsRequired();
            builder.Property(fg => fg.OwnerId).IsRequired();
            builder.HasMany(fg => fg.Members).WithOne().HasForeignKey(mg => mg.FamilyGroupId);
            builder.HasMany(fg => fg.Tasks).WithOne().HasForeignKey(t => t.GroupId);

        }
    }


}