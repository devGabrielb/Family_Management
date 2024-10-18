using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Tasks.CreateTask
{
    public record CreateTaskCommand(Guid OwnerId, string Name, string Description, DateTime DueDate, Guid FamilyGroupId);
}