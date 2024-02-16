using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace OOPCoursework
{
    public class Motorbike : Vehicle
    {
        // List to store the schedules associated with the motorbike.

        private List<Schedule> schedules;
        // Variable to store the seating capacity of the motorbike.
        private int SeatingCapacity;

        
        public Motorbike(string regno, string model, double price,int seats,string make)
            : base(regno,make)
        {
         
            SeatingCapacity = seats;
            if(SeatingCapacity<=0 || SeatingCapacity > 2)
            {
                 throw new ArgumentException("Invalid Value entered for Seating Capacity");
            }
            SetMake(make);
            schedules = base.GEtList();
            SetRegNo(regno);
            //SetType("MotorBike");
            SetModel(model);
            SetPrice(price);

        }

        // Override method to display information about the motorbike, including booked schedules.
        public override void Display()
        {
            Console.Write($"Registration {GetRegNo()} Make :{GetMake()} Model: {GetModel()} Price/Day {GetPrice()}  Seats{GetSeatingCapacity()}");
            
            int count = schedules.Count;

            // Loop through the schedules and display details for each.
            for (int i = 1; i < count; i++)
            {
               schedules [i].DisplaySchedule();
                // Display the information about the associated driver.
                schedules[i].GetDriver();

            }
            Console.WriteLine();

        }

        public int GetSeatingCapacity()
        {
            return SeatingCapacity;
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