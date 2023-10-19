using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerApp
{
    internal class Rental
    {
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public int MowerId { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

    }
}