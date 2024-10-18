using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Ports
{
    public interface ITaskRepository
    {
        public Task CreateTask(TaskItem task);
    }
}