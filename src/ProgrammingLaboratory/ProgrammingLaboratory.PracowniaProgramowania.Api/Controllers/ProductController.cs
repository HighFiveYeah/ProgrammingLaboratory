using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain.Commands;
using ProgrammingLaboratory.PracowaniaProgramowania.Domain.Queries;
using ProgrammingLaboratory.PracowniaProgramowania.Data.DataTransferObjects;

namespace ProgrammingLaboratory.PracowniaProgramowania.Api.Controllers;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<ActionResult> Create([FromBody] InputCreateProduct inputCreateProduct)
    {
        var result = await _mediator.Send(new CreateProductCommand(inputCreateProduct.Name, inputCreateProduct.Price));

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }

    [HttpPatch]
    public async Task<ActionResult> Update([FromBody] InputUpdateProduct inputUpdateProduct)
    {
        var result = await _mediator.Send(new UpdateProductCommand(inputUpdateProduct.Id, inputUpdateProduct.Name,
            inputUpdateProduct.Price));

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] InputDeleteProduct inputDeleteProduct)
    {
        var result = await _mediator.Send(new DeleteProductCommand(inputDeleteProduct.Id));

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromBody] InputGetProduct inputGetProduct)
    {
        var result = await _mediator.Send(new ProductQuery(inputGetProduct.Id));

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }
}