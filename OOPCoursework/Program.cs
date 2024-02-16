using System;

namespace OOPCoursework;

class Program
{
   
   static void Main(string[] args)
    {
        //Vehicle V = new ElectricCar("sr7890", "VN45", 30.00, 10, "honda", 10);
        //Type Vtype = V.GetType();
        //Console.WriteLine(Vtype);
        //OOPCoursework.ElectricCar



        Menu m = new Menu();
        m.Display_menu();
        // Getting the user's choice from the user menu

        int Choice = m.user_menu();

        m.StartOperations(Choice);
    }
}