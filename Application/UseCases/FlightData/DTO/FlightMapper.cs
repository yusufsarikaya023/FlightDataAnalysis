using Domain.Aggregation.Flights;

namespace Application.UseCases.FlightData.DTO;

public class FlightMapper : Profile
{
    public FlightMapper()
    {
        CreateMap<FlightDataDto, Flight>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.DepartureAirport, opt => opt.Ignore())
            .ForMember(x => x.ArrivalAirport, opt => opt.Ignore())
            // convert to utc date time
            .ForMember(x => x.DepartureDateTime,
                opt => opt.MapFrom(x => DateTime.SpecifyKind(x.DepartureDateTime, DateTimeKind.Utc)))
            .ForMember(x => x.ArrivalDateTime,
                opt => opt.MapFrom(x => DateTime.SpecifyKind(x.ArrivalDateTime, DateTimeKind.Utc)));
    }
}