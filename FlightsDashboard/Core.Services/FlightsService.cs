using Core.DataAccess.Data;
using Core.ServiceInterfaces.Services;
using Core.ServiceInterfaces.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class FlightsService : IFlightsService
    {
        private readonly ApplicationDbContext __dbContext;

        public FlightsService(ApplicationDbContext dbContext)
        {
            __dbContext = dbContext;
        }
        public async Task<List<FlightVM>> List()
        {
            var flights = await (from flight in __dbContext.Flights 
                                 select new FlightVM() { 
                                  Id = flight.Id.ToString(),
                                  AirLine = flight.AirLine.Name,
                                  From = flight.From.Name,
                                  To = flight.To.Name,
                                 }).ToListAsync();
            return flights;
        }
    }
}
