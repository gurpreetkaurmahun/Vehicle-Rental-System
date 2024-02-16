using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;


namespace OOPCoursework
{




    public class WestminsterRentalVehice : IRentalManager, IRentalCustomer
    {
        private  int ParkingLots;
        //Using Dictionary to store the Vehicle details because the system doesnot holds Vehicles with same Registration no 
        Dictionary<string, Vehicle> VehicleList;


        public WestminsterRentalVehice()
        {
            ParkingLots = 0;
            VehicleList = new Dictionary<string, Vehicle>(); ;

        }


        // Method to add a vehicle to the parking lot
        public bool AddVehicle(Vehicle V)
        {

            try
            {
                // Check if there are available parking lots
                if (ParkingLots < 50)
                {
                    // Add the vehicle to the VehicleList dictionary using its registration number as the key
                    VehicleList.Add(V.GetRegNo(), V);

                    // Increment the count of occupied parking lots
                    ParkingLots++;
                    Console.WriteLine($"Vehicle with Registration No {V .GetRegNo()} Successfully added to the Lot, Remaining Parking lots are {50 - ParkingLots}");

                    // Return true to indicate successful addition of the vehicle
                    return true;
                }
                else
                {
                    // Display exceptions that might occur during the vehicle addition process
                    throw new InvalidOperationException("Maximum Available Parking lots are 50. Can't add more vehicles to the Lot!");
                }
            }
            catch (Exception )
            {
                // Return false to indicate failure in adding the vehicle
                return false;
               
            }
        }
    



        public void GenerateReport()


        {
            // Create a list of vehicles ordered by their registration numbers
            List<Vehicle> OrderedVehicles = new List<Vehicle>(VehicleList.Values);

            // Creating a list to store booking details (registration number, make, model, price, schedule, booking price) and perform sort operations later.
            List<(string, string, string, double, Schedule, double)> Booking = new List<(string, string, string, double, Schedule, double)>();
            foreach (Vehicle v in OrderedVehicles)
            {
                
                
                
                foreach (Schedule S in v.GEtList())
                {
                    int days = S.GetDropDate().Subtract(S.GetPickUpDate()).Days + 1;
                    double bookingprice = days * v.GetPrice();
                    Booking.Add((v.GetRegNo(), v.GetMake(), v.GetModel(), v.GetPrice(), S, bookingprice));
                }
            }

            // Sort the Booking list using a custom DateComparer
            Booking.Sort(new DateComparer());
            string filename = "output.txt";
            TextReader reader = new StreamReader(filename, true);

            // Iterate through each booking in the sorted list

            foreach ((string R, string M, string Mo, double pr, Schedule S,double bp) in Booking)
            {

               

                string text = $"Regno{R} Make{M} Model{Mo}Price perday{pr} Booking Schedule{S.GetPickUpDate().ToShortDateString()}  && {S.GetDropDate().ToShortDateString()}, Price for Booked Schedule{bp}";
                TextWriter writer = new StreamWriter(filename, true);

                // Write the formatted text to the file
                writer.WriteLine(text);
                writer.Dispose();
               
            }
            // Displaying the existing content of the file using the TextReader
            while (reader.Peek() != -1)
            {
                
                Console.WriteLine(reader.ReadLine());
                Console.WriteLine();
            }
            reader.Dispose();
        }


        // Method to delete a vehicle by its registration number
        public bool DeleteVehicle(string Regno)
        {
            // Checking if the vehicle with the specified registration number exists in the VehicleList
            if (!VehicleList.ContainsKey(Regno))
            {
                throw new KeyNotFoundException($"The vehicle with requested registration no {Regno}not found in the system");
                
            }
            // Remove the vehicle from the VehicleList

            VehicleList.Remove(Regno);

            // Decrement the count of occupied parking lots
            ParkingLots--;

            // Display a success message with the remaining parking lots

            Console.WriteLine($"Vehicle Sucessfully removed to the Lot, Remaining Parkin lots are {50 - ParkingLots}");
                
            return true;
        }

        
        public void ListOrderedVehicles()
        {
            // Check if the VehicleList is empty
            if (VehicleList.Count == 0)
            {
                throw new ArgumentNullException("Vehicle System has no Vehicles to display");
            }

            // Create a list of vehicles to order the Vehicle information based on their make
            List<Vehicle> OrderedVehicles = new List<Vehicle>(VehicleList.Values);
            OrderedVehicles.Sort(new MyComparer());
            Console.WriteLine("Ordered Vehicles Are:");

            // Iterate through each ordered vehicle and display its details
            foreach (Vehicle V in OrderedVehicles)
            {

                V.Display();
            }
        }


        // Method to list available vehicles based on schedule and vehicle type
        public void ListAvailableVehicles(Schedule S,Type type)
        {
            // Check if the 'type' parameter is null and throwing relevant error
            if (type == null)
            {
                throw new ArgumentNullException("type null");
            }

            // Initialise a boolean variable to track availability
            bool availability = false;

            foreach (KeyValuePair<string, Vehicle> kvp in VehicleList)
            {
                if (kvp.Value.GetType() == type)
                {
                    if (kvp.Value.GEtList().Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Following vehicles have been found");
                        kvp.Value.Display();
                        availability = true;
                    }
                    // Check if the specified schedule overlaps with any existing schedules for the vehicle
                    if (kvp.Value.Overlaps(kvp.Value.GEtList(), S))
                    {
                        
                        Console.WriteLine();
                        Console.WriteLine("Following vehicles have been found");
                        kvp.Value.Display();
                        Console.WriteLine();
                        availability = true;
                    }

                }

            }
            // Display a message if no vehicles are available for the requested schedule

            if (!availability)
            {
                Console.WriteLine("SORRY NO VEHICLES AVAILABLE FOR THE REQUESTED SCHEDULE!");
            }
        }

        // Method to list information about all vehicles in the system

        public void ListVehicles()
        {// Check if the VehicleList is empty and throwimg  

            if (VehicleList.Count == 0)
            {
                throw new ArgumentNullException("Vehicle System has no Vehicles to display");
            }
            Console.WriteLine("Information regarding vehicle");
            foreach (KeyValuePair<string, Vehicle> kvp in VehicleList)
            {
               
                string RegistrationNo = kvp.Value.GetRegNo();
                Type type = kvp.Value.GetType();
                Console.Write($"Registration Number is : {RegistrationNo} The Vehicle type is: {type.Name}");
             
                int count = kvp.Value.GEtList().Count;
                // Initialising and Iterate through each schedule and display schedule details and driver information
                List<Schedule> s = kvp.Value.GEtList();
                for (int i = 0; i < count; i++)
                {

                    s[i].DisplaySchedule();
                    s[i].GetDriver();
                }
                // Print a newline for better formatting

                Console.WriteLine();
            }
        }

        public bool AddReservation(string Regno, Schedule S)
        {
            if (!VehicleList.ContainsKey(Regno))
            {
                throw new KeyNotFoundException("Key not Found in the Vehicle list");
            }

            // Initialise variables for tracking reservation addition, schedule price, and final reservation price
            bool addition = false;
            double price = 0.0;

            // Iterate through each key-value pair in the VehicleList

            foreach (KeyValuePair<string, Vehicle> kvp in VehicleList)
            {
                // Check if the current key matches the specified registration number
                if (kvp.Key == Regno)
                {

                    // Check if the provided schedule doesnot overlaps with existing schedules for the vehicle
                    if (!kvp.Value.Overlaps(kvp.Value.GEtList(), S))
                    {
                        
                        kvp.Value.GEtList().Add(S);
                        price = kvp.Value.GetPrice();
                        DateOnly date = new DateOnly(1990, 12, 12);

                        // Create a new driver for the schedule
                        Driver D =new Driver("PAul","Smith",date,"LC123");
                        S.SetDriver(D);

                        addition = true;
                        
                    }
                }

            }
            if (!addition)
            {
                Console.WriteLine($"Reservation for Vehicle no{Regno} COuld not be added for requested Schedule");
                return false;
            }
            //If the Reservation of the schedule is added , the pri;ce for the schesule is calculated and will be displayed in Message
            int days = S.GetDropDate().Subtract(S.GetPickUpDate()).Days + 1;
            double p = days * price;
            Console.WriteLine($"Reservation for Vehicle no{Regno} added Successfully! PickupDate is {S.GetPickUpDate().ToShortDateString()} and Drop Date is{S.GetDropDate().ToShortDateString()} price is {p}");
            return true;
        }


        // Method to change an existing reservation for a vehicle with the specified registration number
        public bool ChangeReservation(string Regno, Schedule old, Schedule New)
        {
            // Initialise a boolean variable for tracking reservation change
            bool change = false;
            if (!VehicleList.ContainsKey(Regno))
            {
                Console.WriteLine($"The Vehicle with Registration No{Regno} not found!");
                return false;
            }

            foreach (KeyValuePair<string, Vehicle> kvp in VehicleList)
            {
                if (kvp.Key == Regno)
                {
                    // Check if the provided old schedule overlaps with other existing schedules for the vehicle

                    if (!kvp.Value.ScheduleOverlaps(kvp.Value.GEtList(), old, New))
                    {
                        Driver D = new Driver();
                        old.SetDriver(D);
                        kvp.Value.GEtList().Remove(old);
                       
                        kvp.Value.GEtList().Add(New);
                        DateOnly date = new DateOnly(2023, 12, 12);

                        // Create a new driver for the schedule
                        Driver DNew = new Driver("PAul", "Smith", date, "LC123");
                        New.SetDriver(DNew);
                        change = true;
                        break;


                    }


                }

            }
            // Display a message based on whether the schedule is changed or not
            if (!change)
            {
                Console.WriteLine("Schedule not changed");
                return false;
            }
            else

            {
                // Return true if the schedule is successfully changed
                Console.WriteLine("Schedule Changed");
                return true;
            }
            

        }

        // Method to delete a reservation for a vehicle with the specified registration number and schedule

        public bool DeleteReservation(string number, Schedule S)
        {
            if (!VehicleList.ContainsKey(number))
            {
                Console.WriteLine($"The Vehicle with Registration No{number} not found!");
                return false;
            }
            
            
            foreach (KeyValuePair<string, Vehicle> kvp in VehicleList)
            {
                if (kvp.Key == number)
                {
                    foreach (Schedule s in kvp.Value.GEtList())
                    {
                        if (s.GetPickUpDate() == S.GetPickUpDate() && s.GetDropDate() == S.GetDropDate())
                        {
                            // Create a new driver will null values to reset the driver information for the schedule as null
                            Driver D = new Driver();
                            S.SetDriver(D);

                            // Remove the schedule from the vehicle's schedule list

                            kvp.Value.GEtList().Remove(S);
                            return true;
                            
                        }
                     
                    }
                    }

                }

            // Return false if the schedule is not found
            return false;
            }
        

        public void VehicleInfo()
        {
            Console.WriteLine("Displaying info");
            foreach (KeyValuePair<string, Vehicle> kvp in VehicleList) {
                
                kvp.Value.Display();
                 
            }
        }

    
        public DateTime DateChecker(string DateInput)
        {
            
            
            string[] Date = DateInput.Split("/");
            DateTime userDate = DateTime.MinValue;
            


            if (Date.Length == 3)
            {
                if (int.TryParse(Date[0], out int month) &&
                    int.TryParse(Date[1], out int day) &&
                    int.TryParse(Date[2], out int year))
                {
                    try
                    {
                        userDate = new DateTime(year, month, day);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Invalid date. Please enter a valid date.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date.");
                }
            }
            else
            {
                Console.WriteLine("Possible null Values here");
            }

            return userDate;
            
            
        }




    
    


    }
}
