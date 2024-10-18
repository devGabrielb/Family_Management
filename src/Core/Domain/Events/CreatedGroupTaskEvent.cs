using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Common;

namespace Domain.Events
{
    public record CreatedGroupTaskEvent(Guid groupTaskId) : IDomainEvent;

}