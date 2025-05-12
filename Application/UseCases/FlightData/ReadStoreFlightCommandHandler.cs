using Application.UseCases.FlightData.DTO;
using Domain.Abstract;
using Domain.Aggregation.AirCrafts;
using Domain.Aggregation.Airports;
using Domain.Aggregation.Flights;

namespace Application.UseCases.FlightData;

public record ReadStoreFlightCommand : IRequest;

/// <summary>
/// Command to read flight data from csv file and store it in the database
/// </summary>
/// <param name="fileReaderService">File reader service to read csv file</param>
/// <param name="mapper">>Mapper to map flight data dto to flight entity</param>
/// <param name="unitOfWork">>Unit of work to save changes to the database</param>

public class ReadStoreFlightCommandHandler(IFileReaderService fileReaderService, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<ReadStoreFlightCommand>
{
    public async Task Handle(ReadStoreFlightCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var flights = fileReaderService.ReadCsv<FlightDataDto>("flights.csv");

            foreach (var flight in flights)
            {
                // Check aircraft exist already in the database
                var aircraft = await unitOfWork.AirCraftRepository()
                    .GetByRegistrationNumber(flight.AircraftRegistrationNumber);
                if (aircraft is null)
                {
                    var aircraftType = GetAircraftType(flight.AircraftType);

                    aircraft = new AirCraft().SetAircraftType(aircraftType)
                        .SetRegistrationNumber(flight.AircraftRegistrationNumber);
                    await unitOfWork.AirCraftRepository().Add(aircraft);
                    await unitOfWork.SaveAsync();
                }

                // Check airports exist already in the database
                var departureAirport = await unitOfWork.AirportRepository()
                    .GetByCode(flight.DepartureAirport);
                if (departureAirport is null)
                {
                    departureAirport = new Airport().SetCode(flight.DepartureAirport);
                    await unitOfWork.AirportRepository().Add(departureAirport);
                    await unitOfWork.SaveAsync();
                }

                var arrivalAirport = await unitOfWork.AirportRepository()
                    .GetByCode(flight.ArrivalAirport);
                if (arrivalAirport is null)
                {
                    arrivalAirport = new Airport().SetCode(flight.ArrivalAirport);
                    await unitOfWork.AirportRepository().Add(arrivalAirport);
                    await unitOfWork.SaveAsync();
                }

                var entity = mapper.Map<Flight>(flight);
                entity.SetAirCraftId(aircraft.Id)
                    .SetArrivalAirportId(arrivalAirport.Id)
                    .SetDepartureAirportId(departureAirport.Id);

                await unitOfWork.FlightRepository().Add(entity);
                await unitOfWork.SaveAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static AircraftType GetAircraftType(string type)
    {
        var aircraftTypes = Enum.GetValues(typeof(AircraftType))
            .Cast<AircraftType>().Select(x => x.ToString()).ToList();

        var aircraftType = aircraftTypes
            .First(x => x.Contains(type, StringComparison.OrdinalIgnoreCase));
        return (AircraftType)Enum.Parse(typeof(AircraftType), aircraftType);
    }
}