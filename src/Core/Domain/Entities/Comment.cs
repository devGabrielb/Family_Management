using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Common;

namespace Domain.Entities
{
    public class Comment : Entity
    {
        public string Content { get; private set; }
        public Guid UserId { get; private set; }
        public Guid TaskId { get; private set; }

        private Comment(string content, Guid userId, Guid taskId)
        {
            Content = content;
            UserId = userId;
            TaskId = taskId;
            CreatedAt = DateTime.UtcNow;
        }

        public static Comment Create(string content, Guid userId, Guid taskId)
        {
            var comment = new Comment(content, userId, taskId);
            return comment;
        }

    }
}