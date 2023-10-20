using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LawnMowerApp
{

    class InventoryManager
    {

        static List<Customer> customerDatabase = new List<Customer>();
        static List<Rental> rentals = new List<Rental>();

        static List<LawnMower> inventory;

        public InventoryManager()
        {

            inventory = new List<LawnMower>
        {
            new LawnMower { MowerId = 1, Model = "HUSKVARNA LB 146 ",  Type = "Petrol  ",   DailyRate = 30,  QuantityInStock = 5 },
            new LawnMower { MowerId = 2, Model = "HUSQVARNA LC 141C",  Type = "Electric",   DailyRate = 20,  QuantityInStock = 5 },
            new LawnMower { MowerId = 3, Model = "HUSQVARNA LC 34  ",  Type = "Manual  ",   DailyRate = 10,  QuantityInStock = 5 },

        };
        }
        public void DisplayInventory()
        {
            Console.WriteLine("\nCurrent Inventory:");
            Console.WriteLine("-------------------");
            foreach (var item in inventory)
            {
                Console.WriteLine($"MowerId:{item.MowerId}, Model: {item.Model}, Type: {item.Type}, DailyRate: {item.DailyRate}SEK, QuantityInStock: {item.QuantityInStock}");
            }
        }

        public bool RentLawnMower()
        {
            Console.WriteLine("\n Rent a lawn Mower ");
            Console.WriteLine("---------------------\n ");
            Console.Write("\nEnter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter MowerId to Rent: ");
            int mowerId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to Rent: ");
            int quantity = int.Parse(Console.ReadLine());

            var lawnMower = inventory.Find(lm => lm.MowerId == mowerId);
            if (lawnMower == null)
            {
                Console.WriteLine("Lawn mowerId not found.");
                return false;
            }

            if (lawnMower.QuantityInStock >= quantity)
            {
                Console.Write("Enter Rental Start Date (YY-MM-DD): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Rental Return Date (YY-MM-DD): ");
                DateTime returnDate = DateTime.Parse(Console.ReadLine());

                int daysRented = (int)(returnDate - startDate).TotalDays;

                lawnMower.QuantityInStock -= quantity;
                rentals.Add(new Rental
                {
                    CustomerId = customerId, 
                    MowerId = mowerId,
                    Quantity = quantity,
                    StartDate = startDate,
                    ReturnDate = returnDate
                });

                Console.WriteLine($"\nMowerId:{mowerId} is rented for {daysRented} days.");
                return true;

            }
            else
            {
                Console.WriteLine($"Not enough {mowerId} lawn mowers available.");
                return false;
            }
        }


        public bool ReturnLawnMower()
        {
            Console.WriteLine("\n Return a lawn Mower ");
            Console.WriteLine("---------------------\n ");
            Console.Write("Enter Customer ID: ");
            int customerid = int.Parse(Console.ReadLine());

            Console.Write("Enter the MowerId to return: ");
            int mowerId = int.Parse(Console.ReadLine());

            Console.Write("Enter the quantity to return: ");
            int quantity = int.Parse(Console.ReadLine());

            var lawnMower = inventory.Find(lm => lm.MowerId == mowerId);
            if (lawnMower == null)
            {
                Console.WriteLine("Lawn MowerId not found.");
                return false;
            }

            lawnMower.QuantityInStock += quantity;
            decimal rentalCost = CalculateRentalCost(mowerId);
            Console.WriteLine($"\nRental Cost: {rentalCost} SEK");
            Console.WriteLine($"\nMowerId:{mowerId} has returned successfully.");
            return true;

        }
        public decimal CalculateRentalCost(int mowerId)
        {

            LawnMower mower = inventory.Find(m => m.MowerId == mowerId);

            if (mower != null)
            {
                Console.WriteLine("Enter the number of days rented: ");
                int rentalDays = int.Parse(Console.ReadLine());
                decimal rentalCost = rentalDays * mower.DailyRate;
                return rentalCost;
            }
            else
            {
                Console.WriteLine("Invalid mower ID.");
                return 0;
            }
        }


        public static void ListCustomersWithAtiveRentals()
        {

            foreach (var rental in rentals)
            {
                if (DateTime.Now >= rental.StartDate && DateTime.Now <= rental.ReturnDate)
                {
                    Console.WriteLine($"\n----Customer with Active Rentals----\n");
                    Console.WriteLine($"CustomerId: {rental.CustomerId}");
                    Console.WriteLine($"MowerId: {rental.MowerId}");
                    Console.WriteLine($"Quantity: {rental.Quantity}");
                    Console.WriteLine($"Start Date: {rental.StartDate.ToShortDateString()}");
                    Console.WriteLine($"Return Date: {rental.ReturnDate.ToShortDateString()}");
                }
            }
            }
        }
    }


      












