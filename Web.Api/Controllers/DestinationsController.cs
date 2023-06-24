using Application.Destinations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using Web.Api.Controllers;

[Route("destinations")]
public class Destinations : ApiController
{
    private readonly ISender _mediator;

    public Destinations(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDestinationCommand command)
    {
        var createDestinationResult = await _mediator.Send(command);

        return createDestinationResult.Match(
            Destination => Ok(createDestinationResult.Value),
            errors => Problem(errors)
        );
    }
}