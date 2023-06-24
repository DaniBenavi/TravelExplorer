using Application.Destinations.Common;
using Domain.Primitives;
using Domain.Destinations;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Destinations;
internal class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand, ErrorOr<DestinationResponse>>
{
    private readonly IDestinationRepository _destinationRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateDestinationCommandHandler(IDestinationRepository destinationRepository, IUnitOfWork unitOfWork)
    {
        _destinationRepository = destinationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<DestinationResponse>> Handle(CreateDestinationCommand command, CancellationToken cancellationToken)
    {
        var destination = new Destination(
            new DestinationId(Guid.NewGuid()), Sku.Create(command.Sku)!, command.Name, new Money(command.Currency, command.Amount));

        _destinationRepository.Add(destination);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new DestinationResponse();
    }
}