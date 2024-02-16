using System;
namespace OOPCoursework
{
    // This interface defines the contract for managing vehicle rentals and will be Accessible by the Admin
    public interface IRentalManager
	{
        // Method to add a new vehicle to the rental system by the Admin.
        public bool AddVehicle(Vehicle v);
        // Method to delete a vehicle from the rental system based on its identification number.
        public bool DeleteVehicle(string Number);

        // Method to list all vehicles in the rental system.
        public void ListVehicles();
        // Method to list vehicles in a sorted order based on their make.
        public void ListOrderedVehicles();

        // Method to generate a report of bookings of vehicle for the rental system.
        public void GenerateReport();

	}
}

