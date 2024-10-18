using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Ports;

using Domain.Entities;

namespace Persistence.Database
{
    public class TaskRepository : ITaskRepository
    {
        public Task CreateTask(TaskItem task)
        {
            throw new NotImplementedException();
        }
    }

}