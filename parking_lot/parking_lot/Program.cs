using System;

namespace parking_lot
{
    class Program
    {
        public string[] InputData()
        {
            return @"create_parking_lot 6 
park KA-01-HH-1234 
park KA-01-HH-9999 
park KA-01-BB-0001 
park KA-01-HH-7777 
park KA-01-HH-2701 
park KA-01-HH-3141 
leave KA-01-HH-3141 4 
status 
park KA-01-P-333 
park DL-12-AA-9999 
leave KA-01-HH-1234 4 
leave KA-01-BB-0001 6 
leave DL-12-AA-9999 2 
park KA-09-HH-0987 
park CA-09-IO-1111 
park KA-09-HH-0123 
status".Split('\n',StringSplitOptions.RemoveEmptyEntries);
        }

        static void Main(string[] args)
        {
            ParkingPlot parkingPlot = new ParkingPlot();
            while (true)
            {
                switch (UserInput())
                {
                    case "1":
                        Console.WriteLine("Enter Car Number:...  ");
                        var carNumber_Book = Console.ReadLine();
                        parkingPlot.Book(carNumber_Book);
                        break;
                    case "2":
                        Console.WriteLine("Enter Car Number:...  ");
                        var carNumber_Leave = Console.ReadLine();
                        parkingPlot.Book(carNumber_Leave);
                        break;
                    case "3":
                        var cars = parkingPlot.Status();
                        foreach (var car in cars)
                        {
                            Console.WriteLine(car)
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Wrong input...! Please select option from the list.");
                        break;
                }
            }
        }

        public static string UserInput()
        {
            Console.WriteLine("Enter you choise...");
            Console.WriteLine("1. Book Parking");
            Console.WriteLine("2. Leave Parking");
            Console.WriteLine("3. Parking Status");
            Console.WriteLine("4. Exit");
            return Console.ReadLine();
        }
    }
}
