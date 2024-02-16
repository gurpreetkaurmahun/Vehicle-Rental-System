using System;
namespace OOPCoursework
{
    public class Van : Vehicle
    {


        // List to store the schedules associated with the instance of  van.
        private List<Schedule> schedules;
        private double CargoCapacity;
        
        // Constructor for initializing a Van object.
        // Parameters:
        //   - regno: Registration number of the van.
        //   - model: Model of the van.
        //   - price: Price per day for renting the van.
        //   - make: Make of the van.

        public Van(string regno, string model,  double Dailyprice,string make,double Cargo)
            :base(regno,make)
        {

          
            schedules = base.GEtList();
            CargoCapacity = Cargo;
            // Set properties of the van and it inherits attributes like make, regno model and price from Superclass Vehicle.
            SetMake(make);
            SetRegNo(regno);
            SetModel(model);
            SetPrice(Dailyprice);
           
        }

        // Override method to display information about the van, including booked schedules.
        public override void Display()
        {
            
            Console.Write($"Registration {GetRegNo()} Make :{GetMake()} Model: {GetModel()} Price/Day {GetPrice()} Cargo Capacity{getCargocapacity()}");



            Console.WriteLine();
            Console.Write("Booked Schedules:");

            int count = schedules.Count;

            List<Schedule> S = base.GEtList();
 
            for (int i = 0; i < count; i++)
            {
                // Loop through the schedules and display details for each.
                S[i].DisplaySchedule();
                // Display the associated driver.
                S[i].GetDriver();
                // Display the calculated price for the schedule.

                Console.WriteLine(scheduleprice(schedules[i], base.GetPrice()));
               

            }
            Console.WriteLine();

        }
        public double getCargocapacity()
        {
            return CargoCapacity;
        }
        // Method to calculate the total price for a given schedule based on the van's price per day.
        // Parameters:
        //   - S: Schedule for which the price is calculated.
        //   - p: Price per day for renting the van.
        // Returns the total price for the schedule booked.
        public double scheduleprice(Schedule S, double p)
        {
            int days = S.GetDropDate().Subtract(S.GetPickUpDate()).Days + 1;
            double price = days * p;
            return price;
        }

    }
   
}