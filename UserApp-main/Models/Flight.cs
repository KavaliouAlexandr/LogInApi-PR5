using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Models
{
    class Flight
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string Time { get; set; }


        public Flight() { }
        public Flight(string name, string from, string to, string departure, string arrival, string time)
        {
            Name = name;
            From = from;
            To = to;
            Departure = departure;
            Arrival = arrival;
            Time = time;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, From-To: {From}-{To}, Dep-Arr: {Departure}-{Arrival}";
        }
    }
}
