using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        //Navigation properties        
        public AirLine AirLine { get; set; }
    }
}
