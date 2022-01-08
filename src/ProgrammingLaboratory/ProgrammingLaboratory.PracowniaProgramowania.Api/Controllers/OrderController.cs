using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain.Queries;
using ProgrammingLaboratory.PracowniaProgramowania.Data.DataTransferObjects;

namespace ProgrammingLaboratory.PracowniaProgramowania.Api.Controllers;

[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPut]
    public async Task<ActionResult> Create([FromBody] InputCreateOrder inputCreateOrder)
    {
        var response = await _mediator.Send(new CreateOrderCommand(inputCreateOrder.ProductId, inputCreateOrder.UserId));

        if (response.IsFailed)
            return BadRequest(response.Errors);

        return Ok(response.Value);
    }

    [HttpPatch]
    public async Task<ActionResult> Update([FromBody] InputUpdateOrder inputUpdateOrder)
    {
        var response = await _mediator.Send(new UpdateOrderCommand(inputUpdateOrder.Id, inputUpdateOrder.ProductId, inputUpdateOrder.UserId));

        if (response.IsFailed)
            return BadRequest(response.Errors);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] InputDeleteOrder inputDeleteOrder)
    {
        var response = await _mediator.Send(new DeleteOrderCommand(inputDeleteOrder.Id));

        if (response.IsFailed)
            return BadRequest(response.Errors);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromBody] InputGetOrder inputGetOrder)
    {
        var response = await _mediator.Send(new OrderQuery(inputGetOrder.Id));

        if (response.IsFailed)
            return BadRequest(response.Errors);

        return Ok(response.Value);
    }
}