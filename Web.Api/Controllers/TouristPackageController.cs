using Application.TouristPackages.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("TouristPackage")]
public class TouristPackages : ApiController
{
    private readonly ISender _mediator;

    public TouristPackages(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTouristPackageCommand command)
    {
        var createTouristPackageResult = await _mediator.Send(command);

        return createTouristPackageResult.Match(
            customer => Ok(),
            errors => Problem(errors)
        );
    }
}