using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterfaces.ViewModels
{
    public class FlightVM
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        //Navigation properties        
        public string AirLine { get; set; }
    }
}
