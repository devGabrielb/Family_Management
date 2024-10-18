using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Ports
{
    public interface IFamilyGroupRepository
    {
        public Task<Guid> CreateFamilyGroup(Guid ownerId, string name, string description);
        public Task<FamilyGroup> GetFamilyGroup(Guid familyGroupId);

        public Task UpdateFamilyGroup(FamilyGroup familyGroup);
        public Task<List<FamilyGroup>> GetFamilyGroupsByUser(Guid userId);
    }
}