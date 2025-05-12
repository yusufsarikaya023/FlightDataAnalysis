using System.Text;
using Application.Common;
using Application.UseCases.FlightData.DTO;
using Function.Functions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Test.FunctionalTest.Functions;

/// <summary>
/// This class is responsible for testing the functionality of the GetFlights function.
/// </summary>
[Collection("FunctionalCollection")]
public class GetFlightsTest(FunctionFixture fixture)
{
    private readonly GetFlights _sut = new(fixture.GetService<IMediator>());
    
    [Fact]
    public async Task Get_Flights_Should_Return_200()
    {
        // arrange
        var departureAirport = Faker.GetFakeAirport();
        var arrivalAirport = Faker.GetFakeAirport();
        fixture.Context.Airports.AddRange(departureAirport, arrivalAirport);
        
        var airCraft = Faker.GetFakeAirCraft();
        fixture.Context.AirCrafts.Add(airCraft);
        // Save changes to get the Ids
        await fixture.Context.SaveChangesAsync(CancellationToken.None);
        
        var flight = Faker.GetFakeFlight();
        flight.SetDepartureAirportId(departureAirport.Id)
            .SetArrivalAirportId(arrivalAirport.Id)
            .SetAirCraftId(airCraft.Id);
        
        fixture.Context.Add(flight);
        await fixture.Context.SaveChangesAsync(CancellationToken.None);
        var body = new Pagination(0, 0);
        var httpRequest = new Mock<HttpRequest>();
        httpRequest.Setup(r => r.Body)
            .Returns(new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body))));
                                                        
        // act
        var result = await _sut.Run(httpRequest.Object);
        var flights = (result as OkObjectResult)?.Value as FlightDto[];

        // assert
        Assert.Equal(200, (result as OkObjectResult)?.StatusCode);
        Assert.NotNull(flights);
    }
}