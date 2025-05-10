using Domain.Abstract;
using Domain.Aggregation.Flights;

namespace Application.UseCases.FlightData;

public record CheckFlightConsistencyCommand : IRequest;

public class CheckFlightConsistencyCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CheckFlightConsistencyCommand>
{
    public async Task Handle(CheckFlightConsistencyCommand request, CancellationToken cancellationToken)
    {
        var flights = await unitOfWork.FlightRepository().GetUncheckedFlights();

        var groupedFlights = flights.GroupBy(x => x.AirCraftId)
            .Select(g => new
            {
                AirCraftId = g.Key,
                Flights = g.ToList().OrderBy(x => x.DepartureDateTime).ToList()
            }).ToArray();

        foreach (var group in groupedFlights)
        {
            var flightsList = group.Flights;

            for (var i = 0; i < flightsList.Count; i++)
            {
                if (i == 0)
                {
                    flightsList[i]
                        .SetConsistencyType(FlightConsistencyType.Consistent)
                        .SetInconsistencyReason(string.Empty);
                    await unitOfWork.SaveAsync();
                    continue;
                }

                var reasons = new List<string>();
                var previousFlight = flightsList[i - 1];
                var currentFlight = flightsList[i];
                if (previousFlight.ArrivalAirportId != currentFlight.DepartureAirportId)
                    reasons.Add($"Arrival airport mismatch with previous flight {previousFlight.Id}");

                if (currentFlight.DepartureDateTime <= previousFlight.ArrivalDateTime)
                    reasons.Add(
                        $"Departure and arrival time mismatch with previous flight {previousFlight.Id}");

                currentFlight
                    .SetConsistencyType(reasons.Count > 0
                        ? FlightConsistencyType.Inconsistent
                        : FlightConsistencyType.Consistent)
                    .SetInconsistencyReason(string.Join(", ", reasons));

                await unitOfWork.SaveAsync();
            }
        }
    }
}