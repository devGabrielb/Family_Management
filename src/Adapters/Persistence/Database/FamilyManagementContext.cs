using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Ports;

using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Database
{
    public class FamilyManagementContext : DbContext, IUnitOfWork
    {
        public FamilyManagementContext(
        DbContextOptions options
       )
        : base(options)
        {
        }

        public DbSet<FamilyGroup> FamilyGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FamilyManagementContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}