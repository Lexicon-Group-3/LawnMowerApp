// See https://aka.ms/new-console-template for more information
using LawnMowerApp;
using System.Xml.Linq;


InventoryManager manager = new InventoryManager();


Console.WriteLine("\nWelcome to Lawn Mower Rental App !");

while (true)
{

    Console.WriteLine("\nMain Menu");
    Console.WriteLine("1. Register New Customer");
    Console.WriteLine("2. Display Inventory");
    Console.WriteLine("3. Rent a Lawn Mower");
    Console.WriteLine("4. Return a Lawn Mower");
    Console.WriteLine("5. View Customers with Active Rentals");
    Console.WriteLine("6. Exit");
    Console.Write("\nEnter your choice: ");

    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                AddCustomer.RegisterNewCustomer();
                break;
            case 2:
                manager.DisplayInventory();
                break;
                case 3:
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.Write("Enter the MowerId to rent: ");
                int rentMowerId = int.Parse(Console.ReadLine());
                Console.Write("Enter the quantity to rent: ");
                int rentQuantity = int.Parse(Console.ReadLine());
                manager.RentLawnMower(rentMowerId, rentQuantity);
               
                break;
                case 4:
                Console.Write("Enter Customer ID: ");
                int customerid = int.Parse(Console.ReadLine());
                Console.Write("Enter the MowerId to return: ");
                int returnMowerId = int.Parse(Console.ReadLine());
                Console.Write("Enter the quantity to return: ");
                int returnQuantity = int.Parse(Console.ReadLine());
                manager.ReturnLawnMower(returnMowerId, returnQuantity);
                decimal rentalCost = manager.CalculateRentalCost(returnMowerId);
                Console.WriteLine($"Rental Cost: {rentalCost}SEK");
                Console.WriteLine($"MowerId:{returnMowerId}, Quantity: {returnQuantity} has returned successfully.");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid option.");
    }
 
}

