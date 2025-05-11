using Application.UseCases.FlightData.DTO;
using Domain.Abstract;

namespace Application.UseCases.FlightData;

public record GetInconsistentFlightsQuery : IRequest<FlightDto[]>;

public class GetInconsistentFlightsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetInconsistentFlightsQuery, FlightDto[]>
{
    public Task<FlightDto[]> Handle(GetInconsistentFlightsQuery request, CancellationToken cancellationToken)
    {
        var flights = unitOfWork.FlightRepository()
            .GetInconsistentFlights()
            .Select(x => new FlightDto
            {
                Id = x.Id,
                DepartureDateTime = x.DepartureDateTime,
                ArrivalDateTime = x.ArrivalDateTime,
                DepartureAirport = x.DepartureAirport.Code,
                ArrivalAirport = x.ArrivalAirport.Code,
                AirCraftRegistrationNumber = x.AirCraft.RegistrationNumber,
                ConsistencyType = x.ConsistencyType.ToString(),
                InconsistencyReason = x.InconsistencyReason
            }).ToArray();

        return Task.FromResult(flights);
    }
}