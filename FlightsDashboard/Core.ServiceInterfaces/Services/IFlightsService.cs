using Core.ServiceInterfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterfaces.Services
{
    public interface IFlightsService
    {
        Task<List<FlightVM>> List();
    }
}
