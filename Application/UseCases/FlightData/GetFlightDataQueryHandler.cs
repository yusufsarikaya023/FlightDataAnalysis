using Application.UseCases.FlightData.DTO;
using Domain.Abstract;

namespace Application.UseCases.FlightData;

/// <summary>
/// Query to get flight data
/// </summary>
/// <param name="Pagination">Pagination object containing page and page size</param>
public record GetFlightDataQuery(Pagination Pagination) : IRequest<FlightDto[]>;

/// <summary>
/// Handler for GetFlightDataQuery for getting flight data
/// </summary>
/// <param name="unitOfWork">The unit of work instance.</param>
public class GetFlightDataQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetFlightDataQuery, FlightDto[]>
{
    public Task<FlightDto[]> Handle(GetFlightDataQuery request, CancellationToken cancellationToken)
    {
        var (page, size) = request.Pagination;
        var flights = unitOfWork.FlightRepository()
            .GetFlights(page, size)
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