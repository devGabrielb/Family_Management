using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Common;
using Domain.Events;

namespace Domain.Entities
{
    public class FamilyGroup : Entity
    {
        private readonly List<MemberGroup> _members = [];
        private readonly List<TaskItem> _tasks = [];

        public Guid OwnerId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyCollection<MemberGroup> Members => [.. _members];
        public IReadOnlyCollection<TaskItem> Tasks => [.. _tasks];

        private FamilyGroup(Guid ownerId, string name, string description)
        {
            OwnerId = ownerId;
            Name = name;
            Description = description;
        }

        public static FamilyGroup Create(Guid ownerId, string name, string description)
        {
            var familyGroup = new FamilyGroup(ownerId, name, description);
            return familyGroup;
        }

        public void InviteMember(Guid userId)
        {
            var member = MemberGroup.Create(userId, Id);
            _members.Add(member);

            RaiseDomainEvent(new MemberInvitedEvent(Id, member.FamilyGroupId));

        }

        public void RemoveMember(Guid userId)
        {
            var member = _members.Find(x => x.UserId == userId);
            if (member == null)
            {
                throw new InvalidOperationException("User is not a member of this group");
            }
            _members.Remove(member);
        }

        public void AddTask(TaskItem task)
        {
            ArgumentNullException.ThrowIfNull(task);
            if (!_members.Exists(x => x.UserId == task.OwnerId))
            {
                throw new InvalidOperationException("User is not a member of this group");
            }
            var taskItem = TaskItem.Create(task.OwnerId, task.Title, task.Description, task.DueDate);
            _tasks.Add(taskItem);
        }

    }
}