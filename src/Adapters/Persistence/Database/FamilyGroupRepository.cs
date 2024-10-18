using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Ports;

using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Database
{
    public class FamilyGroupRepository : IFamilyGroupRepository
    {
        private readonly FamilyManagementContext _context;

        public FamilyGroupRepository(FamilyManagementContext context)
        {
            _context = context;
        }
        public Task<Guid> CreateFamilyGroup(Guid ownerId, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<FamilyGroup> GetFamilyGroup(Guid familyGroupId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FamilyGroup>> GetFamilyGroupsByUser(Guid userId)
        {
            var groups = await _context.FamilyGroups.Where(fg => fg.OwnerId == userId).ToListAsync();
            return groups;

        }

        public Task UpdateFamilyGroup(FamilyGroup familyGroup)
        {
            throw new NotImplementedException();
        }
    }
}