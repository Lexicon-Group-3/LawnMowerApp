using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerApp
{
    internal class AddCustomer
    {

        static List<Customer> customerDatabase = new List<Customer>();
       

        public static void RegisterNewCustomer()
        {
            Console.WriteLine("\nRegistering a New Customer");
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
                Console.WriteLine("\nThis customer is already registered.");
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

