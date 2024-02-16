using System;


namespace OOPCoursework
{
    //Electric car is a type of car Hence it is a subclass of car.
    public class ElectricCar:Cars
    {
        // List to store the schedules associated with the electric car.
        private List<Schedule> schedules;
        private int NoOfPersons;
        private double BatteryCapacity;
       
        public ElectricCar(string regno,  string model,  double price, double battery ,string make,int persons)
        : base(regno,model,price,make,persons)
        {
            
            SetMake(make);
            schedules = base.GEtList();
            NoOfPersons = persons;
            BatteryCapacity = battery;
            SetRegNo(regno);
            SetModel(model);
            SetPrice(price);

        }


        // Override method to display information about the electric car, including booked schedules.
        public override void Display()
        {
            // Display  information about the electric car.
            Console.Write($"Registration {GetRegNo()} Make :{GetMake()} Model: {GetModel()} Price/Day {GetPrice()} PersonCapacity is{GetPersonCapacity()} Battery Capacity: {GetBattery}mhz");
            Console.WriteLine();
            Console.Write("Booked Schedules:");

            int count = schedules.Count();
            Console.WriteLine(count);
            //Looping through List Of Schedules And displaying Information
            for (int i = 1; i < count; i++)
            {
                schedules[i].DisplaySchedule();
                schedules[i].GetDriver();
            }


        }

        public double GetBattery()
        {
            return BatteryCapacity;
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

