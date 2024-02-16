using System;
using static System.Net.Mime.MediaTypeNames;

namespace OOPCoursework
{
    public abstract class Vehicle : IOverlappable
    {
        private string registrationNo;
        private string make;
        private string model;
        private double price;
      
        private List<Schedule> schedules;

        public Vehicle(string r, string make)
        {
            registrationNo = r;
            schedules = new List<Schedule>();
            this.make = make;
            model = "";
            price = 1;
            

        }

        protected void SetRegNo(string r)
        {
            registrationNo = r;
        }

        public string GetRegNo()
        {
            return registrationNo;
        }
        // Protected method to set the make of the vehicle.
       
        protected void SetMake(string m)
        {
            make = m;
        }
        public string GetMake()
        {
            return make;
        }
        // Protected method to set the model of the vehicle.


        protected void SetModel(string m)
        {
            model = m;
        }


        public string GetModel()
        {
            return model;
        }

        // Protected method to set the price per day of the vehicle.
        public void SetPrice(double p)
        {
            //Exception to check if the price added is less than 0.
            if (p <= 0)
            {
                throw new ArgumentException("Rental price cannot be less than 0");
            }
            price = p;
        }
        public double GetPrice()
        {
            return price;
        }
       

        public List<Schedule> GEtList()
        {
            return schedules;
        }


        // Abstract method to display information about the vehicle.To be  Implemented by derived classes.
        public abstract void Display();

        // Method to check if a new schedule overlaps with existing schedule to be used by subclasses of Vehicle.

        public bool ScheduleOverlaps(List<Schedule> schedules,Schedule old, Schedule New)
        {
            Console.WriteLine(schedules.Count);
            int len = schedules.Count;
           
            if (len ==0|| len==1)
            {
                Console.WriteLine("Schedule Changeable");
                return false;
            }

            for (int i = 0; i < len; i++)
            {
                if (schedules[i].GetPickUpDate() == old.GetPickUpDate() && schedules[i].GetDropDate() == old.GetDropDate())
                {
                    Console.WriteLine("Schedule found");
                    int index = i;
                    if (index == 0 && index+1 < len  && New.GetPickUpDate() < schedules[index ].GetPickUpDate()&& New.GetDropDate() < schedules[index+1].GetPickUpDate())
                    {
                        Console.WriteLine($"Schedule Changeable and cna be added at index{i}");
                        
                        return false;
                    }
                    else if (index > 0 && index+1<len  && schedules[index - 1].GetDropDate() < New.GetPickUpDate() && New.GetDropDate() < schedules[index + 1].GetPickUpDate())
                    {

                        Console.WriteLine($"Schedule Changeable and cna be added at index{i}");
                        
                        return false;

                    }
                    else if ( index + 1 == len && schedules[index-1].GetDropDate() < New.GetPickUpDate())
                    {
                        Console.WriteLine($"Schedule Changeable and cna be added at index{i}");
                       
                        return false;
                    }
                  

                }
            }
            Console.WriteLine ("Schedule not found or Overlapping");
            return true;
            
            
        }



        // Method to check if a new schedule overlaps with existing schedules.:This method will be inherited by the subclasses of Vehicle.
        public bool Overlaps(List<Schedule> schedules, Schedule S)
        {
            Console.WriteLine(schedules.Count);
            int len = schedules.Count;
            if (len == 0 )
            {
               
                return false;
            }
            for (int i = 0; i < len; i++)
            {

                if (i == 0 && schedules[i].GetPickUpDate() > S.GetPickUpDate() && schedules[i].GetPickUpDate() > S.GetDropDate())
                {

                  
                    return false;

                }
                else
                if (i > 0 && schedules[i - 1].GetDropDate() < S.GetPickUpDate() && schedules[i].GetPickUpDate() > S.GetDropDate())
                {

                
                    return false;

                }
                else if (i + 1 < len && schedules[i].GetDropDate() < S.GetPickUpDate() && schedules[i + 1].GetPickUpDate() > S.GetDropDate())
                {

                  
                    return false;
                }

                else if (i + 1 >= len && schedules[i].GetDropDate() < S.GetPickUpDate())
                {
                    
                    return false;
                }




            }
            //Console.WriteLine("overlapping");
            return true;
        }


    }
    // Custom comparer class to compare vehicles based on their make.

    public class MyComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle X, Vehicle Y)
        {

            return string.Compare(X.GetMake(), Y.GetMake());

        }

    }

    // Custom comparer class to compare bookings based on their pickup dates.
    public class DateComparer : IComparer<(string, string, string, double, Schedule,double)>
    {
        public int Compare((string, string, string, double, Schedule,double)booking1, (string, string, string, double, Schedule,double)booking2)
        {
            return booking1.Item5.GetPickUpDate().CompareTo(booking2.Item5.GetPickUpDate());
          
        }
    }

}
