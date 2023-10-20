using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerApp
{
    public class Rental
    {
        public int MowerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int CustomerId { get; set; }
       
        public int Quantity { get; set; }
      
        public DateTime ExpectedReturnDate { get; set; }
        public string PersonalNumber { get; set; }
       
    }


}

