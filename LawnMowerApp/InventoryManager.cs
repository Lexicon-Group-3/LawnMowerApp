using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerApp
{

    class InventoryManager
    {
        private List<LawnMower> inventory;

        public InventoryManager()
        {
            inventory = new List<LawnMower>
        {
            new LawnMower { MowerId = 1, Model = "HUSKVARNA LB 146", Type = "Petrol", DailyRate = 30, QuantityInStock = 5 },
            new LawnMower{ MowerId = 2, Model = "HUSQVARNA LC 141C", Type = "Electric", DailyRate =20 , QuantityInStock = 5 },
            new LawnMower{ MowerId = 3,Model = "HUSQVARNA Aspire™ LC34 ", Type = "Manual", DailyRate = 10, QuantityInStock = 5 },

        };
        }
        public void DisplayInventory()
        {
            Console.WriteLine("Current Inventory:");
            foreach (var item in inventory)
            {
                Console.WriteLine($"MowerId:{item.MowerId}, Model: {item.Model}, Type: {item.Type}, DailyRate: {item.DailyRate}SEK, QuantityInStock:{item.QuantityInStock} available");
            }
        }

        public bool RentLawnMower(int mowerId, int quantity)
        {

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

                Console.Write("Enter Rental End Date (YY-MM-DD): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                int daysRented = (int)(endDate - startDate).TotalDays;

                lawnMower.QuantityInStock -= quantity;
                Console.WriteLine($"\nMowerId:{mowerId} & Quantity:{quantity} has rented for {daysRented} days.");
                return true;
            }
            else
            {
                Console.WriteLine($"Not enough {mowerId} lawn mowers available.");
                return false;
            }
        }

        public bool ReturnLawnMower(int mowerId, int quantity)
        {
            var lawnMower = inventory.Find(lm => lm.MowerId == mowerId);
            if (lawnMower == null)
            {
                Console.WriteLine("Lawn MowerId not found.");
                return false;
            }

            lawnMower.QuantityInStock += quantity;

           
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
    }
}









