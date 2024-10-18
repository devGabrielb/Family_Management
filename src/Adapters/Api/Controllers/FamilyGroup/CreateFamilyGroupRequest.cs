using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.FamilyGroup
{
    
    public record CreateFamilyGroupRequest(Guid OwnerId, string Name, string Description);
}