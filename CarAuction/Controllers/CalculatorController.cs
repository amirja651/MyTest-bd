using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarAuction.Commands;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly IMediator _mediator;

    public CalculatorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CalculateTotal([FromBody] PriceCalculationCommand command)
    {
        var total = await _mediator.Send(command);
        return Ok(total);
    }
}
