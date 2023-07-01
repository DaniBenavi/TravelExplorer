using Application.Customers.Create;
using Domain.Customers;
using Domain.Primitives;
using Domain.DomainErrors;

namespace Application.Customers.UnitTests.Create;

public class CreateCustomerCommandHandlerUnitTests
{
    private readonly Mock<ICustomerRepository> _mockCustomerRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly CreateCustomerCommandHandler _handler;
    public CreateCustomerCommandHandlerUnitTests()
    {
        _mockCustomerRepository = new Mock<ICustomerRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object, _mockUnitOfWork.Object);
    }
    [Fact]
    public async void HandleCreateCustomer_WhenPhoneNumberHasBadFormat_ShouldReturnValidationError()
    {
        CreateCustomerCommand command = new(
            "Daniel",
            "Benavides",
            "danibenavi@gmail.com",
            "6546546523",
            "", "", "", "", "", ""
            );


        var result = await _handler.Handle(command, default);

        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorOr.ErrorType.Validation);
        result.FirstError.Code.Should().Be(Errors.Customer.PhoneNumberWhitBadFormat.Code);
        result.FirstError.Description.Should().Be(Errors.Customer.PhoneNumberWhitBadFormat.Description);
    }
}