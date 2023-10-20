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
    public class Customer
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

        static List<Customer> customerDatabase = new List<Customer>();
        public static void RegisterNewCustomer()
        {
            Console.WriteLine("\nRegistering a New Customer");
            Console.WriteLine("----------------------------");
            Console.Write("\nEnter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter customer Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter customer Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter customer's personal number (unique identifier): ");
            string personalNumber = Console.ReadLine();

            if (IsCustomerRegistered(personalNumber))
            {
                Console.WriteLine("\nThe Customer is already registered.");
                return;
            }

            else
            {
                Customer newCustomer = new Customer(name, address, phoneNumber, personalNumber);
                customerDatabase.Add(newCustomer);
                Console.WriteLine("\nCustomer registered Successfully.");
            }
        }
        static bool IsCustomerRegistered(string personalNumber)
        {

            return customerDatabase.Any(customer => customer.PersonalNumber == personalNumber);
        }
    }
}

    

