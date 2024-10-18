using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class MemberGroup : Entity
    {
        public Guid UserId { get; private set; }
        public Guid FamilyGroupId { get; private set; }
        public MemberStatus Status { get; private set; }

        private MemberGroup(Guid userId, Guid familyGroupId, MemberStatus status)
        {
            UserId = userId;
            FamilyGroupId = familyGroupId;
            Status = status;
        }

        public static MemberGroup Create(Guid userId, Guid familyGroupId, MemberStatus status = MemberStatus.Pending)
        {

            var memberGroup = new MemberGroup(userId, familyGroupId, status);
            return memberGroup;
        }
    }
}