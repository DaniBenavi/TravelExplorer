using Application.Reservations.Create;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("Reservation")]
public class Reservations : ApiController
{
    private readonly ISender _mediator;

    public Reservations(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservationCommand command)
    {
        var createReservationResult = await _mediator.Send(command);

        return createReservationResult.Match(
            Reservation => Ok(createReservationResult.Value),
            errors => Problem(errors)
        );
    }
}