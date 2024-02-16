using System;
namespace OOPCoursework
{
	public class Cars:Vehicle
	{
        
        private List<Schedule> schedules;
        private int PersonCapacity;
        
       
        public Cars(string regno,  string model, double p,string make,int Person)
           : base(regno,make)
        {
            if (Person<0 || Person > 8)
            {
                throw new ArgumentException("Ivalid Options Entered for the No of Person Capacity");
            }
            PersonCapacity = Person;
            SetMake(make);
            schedules = base.GEtList();
            SetRegNo(regno);
          
            SetModel(model);
            SetPrice(p);
        }

        // Override method to display information about the car, including booked schedules.
        public override void Display()
        {
            Console.Write($"Registration {GetRegNo()} Make :{GetMake()} Model: {GetModel()} Price/Day {GetPrice()}  Person Capacity is {GetPersonCapacity()}");

            int count = schedules.Count;

            for (int i = 0; i < count; i++)
            {
                // Display schedule details.
                schedules[i].DisplaySchedule();
                // Display the associated driver.
                schedules[i].GetDriver();

            }

        }

        // Method to get the person capacity of the car.
        // Returns the person capacity.
        public int GetPersonCapacity()
        {
            return PersonCapacity;
        }

        // Method to calculate the total price for a given schedule based on the van's price per day.
        // Parameters:
        //   - S: Schedule for which the price is calculated.
        //   - p: Price per day for renting the van.
        // Returns the total price for the schedule booked
        // 
        public double scheduleprice(Schedule S, double p)
        {
            int days = S.GetDropDate().Subtract(S.GetPickUpDate()).Days + 1;
            double price = days * p;
            return price;
        }

    }
}

