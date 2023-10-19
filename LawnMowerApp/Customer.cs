using LawnMowerApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LawnMowerApp
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        

        public Customer(string name, string address, string phoneNumber, string personalNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            PersonalNumber = personalNumber;
        }
    }
}
