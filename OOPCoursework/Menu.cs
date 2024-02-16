using System;
namespace OOPCoursework
{
	public class Menu
	{
        public  int user_menu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**              Please choose from options below:                       **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    1. Admin                                                          **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    2. Customer                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    3. Exit                                                           **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");
            int Choice = Convert.ToInt32(Console.ReadLine());
            return Choice;

        }
        public int Customer_Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Enter your Name Customer");
            string? name= Console.ReadLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine($"           Hello {name} !How we May help you?                        ");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** Enter Options from 1-4                                               **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("** 1. List Available Vehicles, based on Schedule and Vehicle type.      **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 2. Make Reservations based on Schedule and RegistrationNo of Vehicle **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 3. Changed booked reservations                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 4. Delete Reservation                                                **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 5. Exit                                                              **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        // Method to display the admin menu for user selection
        public int AdminMenu()
        {
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("**----------------------------------------------------------------------**");
            Console.WriteLine("**                       Welcome Admin                                  **");
            Console.WriteLine("**----------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**  Please choose from the options below and enter values from 1-4      **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**  1. Add Vehicles, and Get the parking lot info.                      **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**  2. List All the Vehicles                                            **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**  3. List ordered Vehicles                                            **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**  4. Delete Vehicle                                                   **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**  5. Generate report Based on Bookings                                **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**  6. Exit                                                             **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**----------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        public void Display_menu()
		{
			
			Console.WriteLine("**************************************************************************");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                            WELCOME                                   **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**                               TO                                     **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**                 WESTMINSTER RENTAL VEHICLE SYSTEM                    **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**************************************************************************");


        }

        public void AdminOperations(int AdminChoice)
        {
            if (AdminChoice < 0 || AdminChoice > 6)
            {
                Console.WriteLine("Invalid option Entered");

            }
            WestminsterRentalVehice W = new WestminsterRentalVehice();
            Vehicle V = new Van("B23Der", "ER45", 11.00, "Honda",300);
            Vehicle V1 = new Van("E23Der", "ER45", 100.00, "Amaze",400);
            Vehicle V2 = new Van("A34ARM", "EZ55", 200.00, "BMX",500);
            Vehicle M = new Motorbike("MW234", "MODEL", 100.0, 2, "ZEMR");
            Vehicle M1 = new Motorbike("EW234", "MODEL", 100.0, 2, "CATTYMR");
            Vehicle EC = new ElectricCar("EC3456", "EC34", 35, 4, "TESLA", 4);
           
            Console.WriteLine(V.GetPrice());

            // Adding vehicles to the WestminsterRentalVehicle instance
            W.AddVehicle(V);
            W.AddVehicle(V1);
            W.AddVehicle(V2);

            W.AddVehicle(M);
            W.AddVehicle(M1);
            W.AddVehicle(EC);
            bool condition = true;
            while (condition)
            {

                switch (AdminChoice)
                {
                    case 1:
                        // Adding a vehicle to the system
                        Console.WriteLine("Enter type of vehicle to be added to the system!");
                        Console.WriteLine(" Choose Between Van, Cars, ElectricCar, Motorbike");
                        CreateVehicle NVehicle = new CreateVehicle();
                        string typee = Console.ReadLine()!;
                        Vehicle vehicle = NVehicle.NewVehicle(typee);
                        W.AddVehicle(vehicle);
                        W.ListVehicles();
                        condition = false;

                        break;
                    case 2:
                        //Listing Vehicles
                        W.ListVehicles();
                        condition = false;
                        break;
                    case 3:
                        // Admin chooses to list ordered vehicles based on their MAke
                        W.ListOrderedVehicles();

                        condition = false;
                        break;
                    case 4:
                        //Deletimg Vehicles
                        Console.WriteLine("Enter Registration Number if Vehicle to be deleted");
                        string? deleteVehicle = Console.ReadLine()!;
                        W.DeleteVehicle(deleteVehicle);
                        W.ListVehicles();
                        condition = false;
                        break;

                    case 5:
                        //Generating reports of the bookings made
                        W.GenerateReport();
                        condition = false;
                        break;
                    case 6:
                        //Back to the User Menu
                        user_menu();
                        break;
                }
                break;


            }
         

        }
        public void CustomerOperations(int choice)
        {
            if (choice < 0 || choice > 5)
            {
                Console.WriteLine("Invalid option Entered");

            }
            WestminsterRentalVehice W = new WestminsterRentalVehice();
            Vehicle V = new Van("B23Der", "ER45", 11.00, "Honda",300);
            Vehicle V1 = new Van("E23Der", "ER45", 100.00, "Amaze",400);
            Vehicle V2 = new Cars("A34ARM", "EZ55", 200.00, "BMX",5);
            Vehicle M = new Motorbike("MW234", "MODEL", 100.0, 2, "ZEMR");
            Vehicle M1 = new Motorbike("EW234", "MODEL", 100.0, 2, "CATTYMR");
            Vehicle EC = new ElectricCar("EC3456", "EC34", 35, 4, "TESLA", 4);


            // Adding vehicles to the WestminsterRentalVehicle instance
            W.AddVehicle(V);
            W.AddVehicle(V1);
            W.AddVehicle(V2);

            W.AddVehicle(M);
            W.AddVehicle(M1);
            W.AddVehicle(EC);
            switch (choice)
            {
                case 1:
                    // listing available vehicles based on schedule and vehicle type
                    Console.WriteLine("CHoose between Van,Electric Car, Motorbike, Car");
                    string? Vehicletype = Console.ReadLine();
                    //converting the string representation of the type to a Type object
                    Type? type = Type.GetType($"OOPCoursework.{ Vehicletype}");

                    if (type == null)
                    {
                        throw new ArgumentNullException($"Invalid vehicle type: {Vehicletype}");
                        
                    }
                    Console.WriteLine("Enter Pickup Date : Format MM/dd/yyyy)");
                    string? Date1 = Console.ReadLine();

                    Console.WriteLine("Enter Drop Date : Format MM/dd/yyyy");
                    string? Date2 = Console.ReadLine();
                    if (Date1 == null || Date2 == null)
                    {

                        throw new ArgumentNullException("Empty Date Values");
                    }

                    Schedule S = new(W.DateChecker(Date1), W.DateChecker(Date2));
                    W.ListAvailableVehicles(S, type);
                    break;

                case 2:
                    //Displaying Vehicle information and make reservations
                    W.VehicleInfo();
                    Console.WriteLine("Choose from vehicles Listed Above and make reservations based on Regno of Vehicle and suitable Schedule");
                    Console.WriteLine("Enter Pickup Date : Format MM/dd/yyyy)");
                    string dd1 = Console.ReadLine()!;
                    Console.WriteLine("Enter Drop Date : Format MM/dd/yyyy");
                    string d2 = Console.ReadLine()!;
                    Schedule S1 = new Schedule(W.DateChecker(dd1), W.DateChecker(d2));
                    if (dd1 == null || d2 == null)
                    {

                        throw new ArgumentNullException("Empty Date Values");
                    }
                    Console.WriteLine("Enter registration number of the chosen Vehicle from the list above");
                    string Regno = Console.ReadLine()!;

                    W.AddReservation(Regno, S1);



                    break;

                case 3:
                    // Changing a reservation schedule

                    Console.WriteLine("Enter registration number of the Vehicle where the Schedule is expected to be changed");

                    string RegNo = Console.ReadLine()!;
                    Console.WriteLine("Enter Old Pickup Date : Format MM/dd/yyyy)");
                    string OldPickup = Console.ReadLine()!;
                    Console.WriteLine("Enter Old  Drop Date : Format MM/dd/yyyy");
                    string OldDrop = Console.ReadLine()!;
                    Schedule OldSchedule = new Schedule(W.DateChecker(OldPickup), W.DateChecker(OldDrop));
                    Console.WriteLine("Enter New Pickup Date : Format MM/dd/yyyy)");

                    string NewPickup = Console.ReadLine()!;
                    Console.WriteLine("Enter New Drop Date : Format MM/dd/yyyy");
                    string NewDrop = Console.ReadLine()!;
                    Schedule NewSchedule = new Schedule(W.DateChecker(NewPickup), W.DateChecker(NewDrop));
                    W.ChangeReservation(RegNo, OldSchedule, NewSchedule);

                    W.ListVehicles();

                    break;

                case 4:
                    //Deleting a reservation schedule
                    W.VehicleInfo();
                    Console.WriteLine("Enter registration number of the Vehicle where the Schedule is to be deleted!");
                    string RegNum = Console.ReadLine()!;
                    Console.WriteLine("Enter Pickup Date : Format MM/dd/yyyy)");
                    string DatePickUp = Console.ReadLine()!;
                    Console.WriteLine("Enter Drop Date : Format MM/dd/yyyy");
                    string DateDrop = Console.ReadLine()!;
                    Schedule DeleteSchedule = new Schedule(W.DateChecker(DatePickUp), W.DateChecker(DateDrop));
                    W.DeleteReservation(RegNum, DeleteSchedule);
                    W.ListVehicles();
                    break;

                case 5:
                    break;


            }

        }

        public void StartOperations(int Choice)
        {

            switch (Choice)
            {
                case 1:

                    // If the user chose the Admin option

                    int AdminChoice = AdminMenu();
                    AdminOperations(AdminChoice);
                    // Validating the Admin's choice
                    break;


                case 2:

                    // Getting the customer's choice from the customer menu
                    int choice = Customer_Menu();

                    CustomerOperations(choice);


                    // Breaking from the main switch statement
                    break;
            }
        }
    }
}

