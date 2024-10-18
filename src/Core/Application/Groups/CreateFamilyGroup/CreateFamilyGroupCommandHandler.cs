using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities; // Assuming FamilyGroup is in the Domain.Entities namespace

using Application.Ports;

namespace Application.Groups.CreateFamilyGroup
{
    public class CreateFamilyGroupCommandHandler
    {
        private readonly IFamilyGroupRepository _familyGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFamilyGroupCommandHandler(IFamilyGroupRepository familyGroupRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _familyGroupRepository = familyGroupRepository;
        }
        public async Task<Guid> Handle(CreateFamilyGroupCommand command)
        {
            ArgumentNullException.ThrowIfNull(command);

            var familyGroup = FamilyGroup.Create(command.OwnerId, command.Name, command.Description);

            var familyGroupId = await _familyGroupRepository.CreateFamilyGroup(familyGroup.OwnerId, familyGroup.Name, familyGroup.Description);

            await _unitOfWork.SaveChangesAsync();
            return familyGroupId;
        }
    }
}