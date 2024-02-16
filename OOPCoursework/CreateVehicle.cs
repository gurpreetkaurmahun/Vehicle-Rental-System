using System;
namespace OOPCoursework
{
    //Class for creating Object instances of vehicle class
	public class CreateVehicle
	{
        // Method to create a Car object and handle exceptions

        public Vehicle CreateVan()
        {
            try
            {
                Console.WriteLine($"Enter registration no:");
                string regno = Console.ReadLine()!;
                Console.WriteLine("Enter Model name:");
                string model = Console.ReadLine()!;
                Console.WriteLine("Enter Make :");
                string make = Console.ReadLine()!;
                Console.WriteLine("Enter Price per day:");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Cargo Capacity:");
                double Cargo = Convert.ToDouble(Console.ReadLine());
                return new Van(regno, model, price, make,Cargo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating van: {ex.Message}");
                return null;
            }

        }

        // Method to create a Car object and handle exceptions
        public Vehicle CreateCar()
        {
            try
            {
                Console.WriteLine("Enter registration no:");
                string regno = Console.ReadLine()!;
                Console.WriteLine("Enter Model :");
                string model = Console.ReadLine()!;
                Console.WriteLine("Enter Make :");
                string make = Console.ReadLine()!;
                Console.WriteLine("Enter Price per day:");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Person Capacity:");
                int PersonCapacity = Convert.ToInt32(Console.ReadLine());
                return new Cars(regno, model, price, make, PersonCapacity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating car: {ex.Message}");
                return null;
            }
        }

        // Method to create an ElectricCar object and handle exceptions
        public  Vehicle CreateElectricCar()
        {
            try
            {
                Console.WriteLine("Enter registration no:");
                string regno = Console.ReadLine()!;
                Console.WriteLine("Enter Model:");
                string model = Console.ReadLine()!;
                Console.WriteLine("Enter Make :");
                string make = Console.ReadLine()!;
                Console.WriteLine("Enter Price :");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter battery capacity");
                double battery= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Person Capacity");
                int persons = Convert.ToInt32(Console.ReadLine());
                return new ElectricCar(regno, model, price, battery, make,persons);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error creating car: {ex.Message}");
                return null;
            }

        }

        // Method to create a Motorbike object and handle exceptions
        public  Vehicle CreateMotorBike()
        {

            try
            {
                Console.WriteLine("Enter registration no:");
                string regno = Console.ReadLine()!;

                Console.WriteLine("Enter Model :");
                string model = Console.ReadLine()!;
                Console.WriteLine("Enter Make:");
                string make = Console.ReadLine()!;
                Console.WriteLine("Enter Price per day :");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Seating Capacity");
                int seat = Convert.ToInt32(Console.ReadLine());

                return new Motorbike(regno, model, price, seat, make);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating car: {ex.Message}");
                return null;
            }

        }

        // Method to create a Vehicle based on the type provided
        public Vehicle NewVehicle(string type)
        {
            switch (type.ToLower())
            {
                case "van":
                    return CreateVan();
                case "cars":
                    return CreateCar();
                case "electriccar":
                    return CreateElectricCar();
                case "Motorbike":
                    return CreateMotorBike();
                // Add other cases as needed
                default:
                    throw new ArgumentException("Invalid type of vehicle entered");
            }
        }
    }
}

