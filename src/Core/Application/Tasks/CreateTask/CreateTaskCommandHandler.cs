using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Ports;
using Application.Provider;

using Domain.Entities;

namespace Application.Tasks.CreateTask
{
    public class CreateTaskCommandHandler
    {

        private readonly ITaskRepository _taskRepository;
        private readonly IFamilyGroupRepository _familyGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IFamilyGroupRepository familyGroupRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
            _familyGroupRepository = familyGroupRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Guid> Handle(CreateTaskCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);

            var currentDate = _dateTimeProvider.UtcNow;

            if (command.DueDate < currentDate)
            {
                throw new InvalidOperationException("Due date cannot be in the past");
            }

            var task = TaskItem.Create(command.OwnerId, command.Name, command.Description, command.DueDate);

            if (command.FamilyGroupId == Guid.Empty)
            {
                await _taskRepository.CreateTask(task);

            }
            else
            {

                var familyGroup = await _familyGroupRepository.GetFamilyGroup(command.FamilyGroupId) ?? throw new InvalidOperationException("Family group not found");
                task.AddToGroup(familyGroup.Id);
                familyGroup.AddTask(task);
                await _familyGroupRepository.UpdateFamilyGroup(familyGroup);
            }

            _ = await _unitOfWork.SaveChangesAsync();
            return task.Id;
        }
    }
}