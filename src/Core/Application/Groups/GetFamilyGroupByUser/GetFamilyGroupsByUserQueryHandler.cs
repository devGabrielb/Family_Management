using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Ports;

using Domain.Entities;

namespace Application.Groups.GetFamilyGroupByUser
{
    public class GetFamilyGroupsByUserQueryHandler
    {
        private readonly IFamilyGroupRepository _familyGroupRepository;
        public GetFamilyGroupsByUserQueryHandler(IFamilyGroupRepository familyGroupRepository)
        {
            _familyGroupRepository = familyGroupRepository;
        }

        public async Task<List<FamilyGroup>> Handle(GetFamilyGroupsByUserQuery query)
        {

            var groups = await _familyGroupRepository.GetFamilyGroupsByUser(query.UserId);

            if (groups is null)
            {
                return new List<FamilyGroup>();
            }

            return groups;
        }
    }
}