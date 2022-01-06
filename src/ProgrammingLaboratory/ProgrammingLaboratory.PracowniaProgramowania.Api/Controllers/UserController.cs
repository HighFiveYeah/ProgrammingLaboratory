using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain.Queries;
using ProgrammingLaboratory.PracowniaProgramowania.Data.DataTransferObjects;

namespace ProgrammingLaboratory.PracowniaProgramowania.Api.Controllers;

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<ActionResult> Create([FromBody] InputCreateUser inputCreateUser)
    {
        var result = await _mediator.Send(new CreateUserCommand(inputCreateUser.FirstName, inputCreateUser.LastName,
            inputCreateUser.Code, inputCreateUser.Address));

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }

    [HttpPatch]
    public async Task<ActionResult> Update([FromBody] InputUpdateUser inputUpdateUser)
    {
        var result = await _mediator.Send(new UpdateUserCommand(inputUpdateUser.Id, inputUpdateUser.FirstName,
            inputUpdateUser.LastName, inputUpdateUser.Code, inputUpdateUser.Address));

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] InputDeleteUser inputDeleteUser)
    {
        var result = await _mediator.Send(new DeleteUserCommand(inputDeleteUser.Id));

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromBody] InputGetUser inputGetUser)
    {
        var result = await _mediator.Send(new UserQuery(inputGetUser.Id));

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }
}