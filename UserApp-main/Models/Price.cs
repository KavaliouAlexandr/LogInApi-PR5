using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Models
{
    class Price
    {
        public int ID { get; set; }
        public int IDFlight { get; set; }
        public string Type { get; set; }
        public string Cost { get; set; }

        public Price() { }
        public Price(int idFlight, string type, string cost)
        {
            IDFlight = idFlight;
            Type = type;
            Cost = cost;
        }
    }
}
