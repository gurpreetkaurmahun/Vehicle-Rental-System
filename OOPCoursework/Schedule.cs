using System;
using System.Diagnostics;

namespace OOPCoursework
{
	public class Schedule
	{
        // Attributes to store pickup and drop dates, and the associated driver.
        private DateTime pickup;
        private DateTime drop;
        private Driver ScheduleDriver;

        public Schedule(DateTime pick, DateTime dropDate)
		{
            if (dropDate < pick)
            {
                throw new ArgumentException("Drop date cannot be before pickup date.");
            }

            pickup = pick;
            drop = dropDate;
            ScheduleDriver = new Driver();
            
		}


        // Method to set the driver for the schedule.
        // Parameters:
        //   - D: Driver object to be associated with the schedule.
        public void SetDriver(Driver D)
        {
            ScheduleDriver = D;

        }
        // Method to get the details of the associated driver.
        // inherits  DisplayDriverInfo method defined in Driver class and Returns a string containing driver information.

        public string GetDriver()
        {
            return ScheduleDriver.DisplayDriverInfo();
        }

        // Method to set the pickup date of the schedule.
        public void setPickup(DateTime d)
		{
            
            pickup = d;
		}

        // Method to set the drop date of the schedule.
        public void setDropDate(DateTime d)
        {
            

            drop = d;
        }

        // Method to get the pickup date of the schedule.
        // Returns the pickup date.

        public DateTime GetPickUpDate()
        {
            return pickup;
        }

        // Method to get the drop date of the schedule.
        // Returns the drop date.
        public DateTime GetDropDate()
        {
            return drop;
        }


        // Method to display the schedule details, including pickup and drop dates, and driver information.

        public void DisplaySchedule()
        {
            Console.Write($"Pickup Date: {pickup.ToShortDateString()} DropDate: {drop.ToShortDateString()}  Driver details are{GetDriver()}");
           
        }

        
    }
}

