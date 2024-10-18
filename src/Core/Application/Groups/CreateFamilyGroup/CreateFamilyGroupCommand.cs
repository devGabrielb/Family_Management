using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Groups.CreateFamilyGroup
{
    public record CreateFamilyGroupCommand(Guid OwnerId, string Name, string Description);
}