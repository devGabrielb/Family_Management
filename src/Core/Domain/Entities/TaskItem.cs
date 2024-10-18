using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class TaskItem : Entity
    {
        private readonly List<Comment> _comments = [];

        public Guid OwnerId { get; private set; }
        public Guid? AssignTo { get; private set; }
        public Guid? GroupId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }

        public TaskItemState State { get; private set; }

        public IReadOnlyCollection<Comment> Comments => [.. _comments];
        public bool IsComplete => State == TaskItemState.Done;

        private TaskItem(Guid ownerId, string title, string description, DateTime dueDate)
        {
            OwnerId = ownerId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            State = TaskItemState.New;
        }

        public static TaskItem Create(Guid ownerId, string title, string description, DateTime dueDate)
        {

            var taskItem = new TaskItem(
                ownerId,
                title,
                description,
                dueDate
            );

            return taskItem;
        }


        public void AddToGroup(Guid groupId)
        {

            if (!GroupId.HasValue)
            {
                GroupId = groupId;
            }
        }

        public void AddComment(string content, Guid userId)
        {
            var comment = Comment.Create(content, userId, Id);
            _comments.Add(comment);
        }

    }
}