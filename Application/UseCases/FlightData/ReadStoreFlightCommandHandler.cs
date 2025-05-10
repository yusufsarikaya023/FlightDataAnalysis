namespace Application.UseCases.FlightData;

public record ReadStoreFlightCommand : IRequest;

public class ReadStoreFlightCommandHandler(): IRequestHandler<ReadStoreFlightCommand>
{
    public async Task Handle(ReadStoreFlightCommand request, CancellationToken cancellationToken)
    {
       await Task.CompletedTask;
    }
}