using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Application.Groups.CreateFamilyGroup;
using Application.Groups.GetFamilyGroupByUser;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.FamilyGroup
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyGroupController : ControllerBase
    {
        private readonly CreateFamilyGroupCommandHandler _createFamilyGroupCommandHandler;
        private readonly GetFamilyGroupsByUserQueryHandler _getFamilyGroupsByUserQueryHandler;

        public FamilyGroupController(CreateFamilyGroupCommandHandler createFamilyGroupCommandHandler, GetFamilyGroupsByUserQueryHandler getFamilyGroupsByUserQueryHandler)
        {
            _createFamilyGroupCommandHandler = createFamilyGroupCommandHandler;
            _getFamilyGroupsByUserQueryHandler = getFamilyGroupsByUserQueryHandler;
        }


        [HttpPost]
        public async Task<IActionResult> CreateFamilyGroup([FromBody] CreateFamilyGroupRequest request)
        {

            var command = new CreateFamilyGroupCommand(request.OwnerId, request.Name, request.Description);
            var familyGroupId = await _createFamilyGroupCommandHandler.Handle(command);
            return Ok(familyGroupId);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetFamilyGroupsByUser([FromRoute] Guid userId)
        {
            var getFamilyGroupsByUserQuery = new GetFamilyGroupsByUserQuery(userId);
            var groups = await _getFamilyGroupsByUserQueryHandler.Handle(getFamilyGroupsByUserQuery);
            return Ok(groups);
        }
    }
}