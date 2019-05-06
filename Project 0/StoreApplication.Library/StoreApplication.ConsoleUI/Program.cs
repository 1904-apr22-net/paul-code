using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using StoreApplication.DataAccess;
using StoreApplication.DataAccess.Entities;
using StoreApplication.Library;
using System;

namespace StoreApplication.ConsoleUI
{
    public class Program
    {
        public static HeadQuarters MainStore;

        public static readonly LoggerFactory AppLoggerFactory = new LoggerFactory(new[]
        {
            new ConsoleLoggerProvider((_, level)
                => level >= LogLevel.Information, true)
        });
        static void Main(string[] args)
        {
            using (StoreApplicationContext dbContext = CreateDbContext())
            {
                PrintMovies(dbContext);
                
            }







            //MainStore = new HeadQuarters();
            //Console.WriteLine("Hello World!");
            //Location Location = new Location();
            //MainStore.Locations.Add(Location);
            //Product Product = new Product(5, "Pineapple", 2, 4);
            //MainStore.Locations[0].Products.Add(Product);
            //MainStore.Locations[0].DecreaseProduct(2, 2);


            //Console.WriteLine(Location.CountProduct(2));

            //MainOptionDisplay();
        }
        private static void PrintMovies(StoreApplicationContext dbContext)
        {
            foreach (var Customer in dbContext.Store) {
          
                Console.WriteLine($"{Customer.Name} - {Customer.State}");
            }
            //Console.WriteLine('');
        }
        private static StoreApplicationContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreApplicationContext>();
            optionsBuilder
                .UseLoggerFactory(AppLoggerFactory)
                .UseSqlServer(SecretConfiguration.ConnectionString); 

            return new StoreApplicationContext(optionsBuilder.Options);
        }

        static void MainOptionDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("1:\tLookup/Add Customer");
            Console.WriteLine("2:\tSelect Location/Add Location");
            Console.WriteLine("3:\tSave data to disk.");
            Console.WriteLine("4:\tLoad data from disk.");
            Console.WriteLine();

            int input = IntValidation(1, 4);
            switch (input)
            {
                case 1:
                    CustomerDisplay();
                    break;
                case 2:
                    LocationDisplay();
                    break;
            }
            throw new NotImplementedException();
        }

        static void CustomerDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("1:\tSearch For Customer Name");
            Console.WriteLine("2:\tDisplay All Customers");
            Console.WriteLine("3:\tAdd Customer");
            Console.WriteLine("3:\tPlace Order For Customer");
            Console.WriteLine("4:\tReturn to Main Menu");


            throw new NotImplementedException();
        }

        static void LocationDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("1:\tDisplay All Locations");
            Console.WriteLine("2:\tAdd Location");
            Console.WriteLine("3:\tReturn to Main Menu");
            throw new NotImplementedException();
        }

        static void PlaceOrder(Customer Customer)
        {
            Console.WriteLine();
            Console.WriteLine($"\tCurrent Default Store Location for {Customer.GetFullName()} is: {Customer.DefaultLocation.Name}");
            Console.WriteLine("1:\tUse Default");
            Console.WriteLine("2:\tUpdate Default");
            int input = IntValidation(1, 2);
            switch (input)
            {
                case 1:
                    Console.WriteLine("Default Selected");
                    break;
                case 2:
                    foreach (var loc in MainStore.Locations)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"1:\tUpdate Default to: {loc.Name}");
                        Console.WriteLine("2:\tDon't Update Default / View next location");
                        Console.WriteLine("3:\tReturn to Main Menu");
                        input = IntValidation(1, 3);

                        switch (input)
                        {
                            case 1:
                                Customer.DefaultLocation.Name = loc.Name;
                                break;
                            case 2:
                                break;
                            case 3:
                                return;
                        }
                    }
                    Console.WriteLine($"Default is {Customer.DefaultLocation.Name}");
                    break;
            }

        }
        static int IntValidation(int min, int max, string error = "Please enter a valid input")
        {
            bool CheckInt;
            int CheckedInt;
            while (true)
            {
                string input = Console.ReadLine();
                CheckInt = Int32.TryParse(input, out CheckedInt);
                if (CheckInt && CheckedInt >= min && CheckedInt <= max)
                {
                    return CheckedInt;
                }
                else
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}
