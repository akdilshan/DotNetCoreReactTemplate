using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Models
{
    public class AirLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Country Country { get; set; }

        //Navigation Properties
        public List<Flight> Flights { get; set; }
    }
}
