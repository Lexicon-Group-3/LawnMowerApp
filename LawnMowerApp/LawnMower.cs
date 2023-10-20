using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LawnMowerApp
{
    public class LawnMower
    {
        public int MowerId { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public decimal DailyRate { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
       
}
 