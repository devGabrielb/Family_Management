using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Ports;

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