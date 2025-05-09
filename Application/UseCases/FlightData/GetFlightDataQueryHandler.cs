namespace Application.UseCases.FlightData;

public record GetFlightDataQuery: IRequest<string>;

public class GetFlightDataQueryHandler: IRequestHandler<GetFlightDataQuery, string>
{
    public Task<string> Handle(GetFlightDataQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("sucess");
    }
}