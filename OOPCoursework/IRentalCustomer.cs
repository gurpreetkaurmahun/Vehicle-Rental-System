using System;
namespace OOPCoursework
{
	public interface IRentalCustomer
	{
        // Method to list available vehicles based on a provided schedule and vehicle type.
        // Parameters:
        //   - S: Schedule object representing the time frame for availability.
        //   - type: Type of vehicle to filter the availability list.

        public void ListAvailableVehicles(Schedule S,Type type);

        // Method to add a new reservation for a vehicle.
        // Parameters:
        //   - number: Vehicle number for which the reservation is made.
        //   - S: Schedule object representing the reservation time frame.
        public bool AddReservation(string number,Schedule S);

        // Method to change an existing reservation.
        // Parameters:
        //   - number: Vehicle number for which the reservation is being changed.
        //   - old: Schedule object representing the old reservation time frame.
        //   - New: Schedule object representing the new reservation time frame.
        public bool ChangeReservation(string number, Schedule old,Schedule New);

        // Method to delete a reservation for a vehicle based on a given schedule.
        // Parameters:
        // Regiostration number: Vehicle number for which the reservation is to be deleted.
        //  S: Schedule object representing the reservation time frame.
        public bool DeleteReservation(string number, Schedule S);

		/// Method to display information about vehicles(e.g., details, availability, etc.).
		public void VehicleInfo();
	}
}

