using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrimaryCode { get; set; }
        public Country Country { get; set; }
    }
}
