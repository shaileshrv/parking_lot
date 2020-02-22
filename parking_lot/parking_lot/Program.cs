using System;
using System.Text.RegularExpressions;

namespace parking_lot
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking carParking = new Car(6, new CarValidation());
            while (true)
            {
                var userInput = UserInput1();
                switch (userInput.Command)
                {
                    case ParkingOption.Book:
                        if (carParking.IsAvailable() != -1)
                        {
                            try
                            {
                                int allocatedNumber = carParking.Book(userInput.Car);
                                Console.WriteLine("Allocated slot number: {0}", allocatedNumber);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Parking is full..");
                        }
                        break;
                    case ParkingOption.Leave:
                        try
                        {
                            int freeSlot = carParking.Leave(userInput.Car);
                            Console.WriteLine("Registration number {0} with Slot Number {1} is free with Charge {2}", userInput.Car, freeSlot, userInput.Hour);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case ParkingOption.Status:
                        var cars = carParking.Status();
                        if (cars.Length == 0)
                        {
                            Console.WriteLine("No car parked.");
                        }
                        else
                        {
                            Console.WriteLine("Slot No. Registration No.");
                            for (int index = 0; index < cars.Length; index++)
                            {
                                Console.WriteLine("{0}\t{1}", index + 1, cars[index]);
                            }
                        }
                        break;
                }
            }
        }

        public static ParkingOptionDetails UserInput1()
        {
            Console.WriteLine("command... ");
            var command = Console.ReadLine().Split(' ');

            ParkingOptionDetails parkingOptionDetails = new ParkingOptionDetails();
            switch (command[0].ToLower())
            {
                case "park":
                    parkingOptionDetails.Command = ParkingOption.Book;
                    parkingOptionDetails.Car = command[1];
                    break;
                case "leave":
                    parkingOptionDetails.Command = ParkingOption.Leave;
                    parkingOptionDetails.Car = command[1];
                    parkingOptionDetails.Hour = int.Parse(command[2]);
                    break;
                case "status":
                    parkingOptionDetails.Command = ParkingOption.Status;
                    break;

            }
            return parkingOptionDetails;
        }
    }


    class ParkingOptionDetails
    {
        public ParkingOption Command { get; set; }
        public string Car { get; set; }
        public int Hour { get; set; }
    }
}
