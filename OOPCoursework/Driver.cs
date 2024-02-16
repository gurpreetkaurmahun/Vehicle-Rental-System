using System;
namespace OOPCoursework
{
	public class Driver
	{
		private string name;
		private string surname;
		private DateOnly Dob;
		private string LicenceNo;
		public Driver(string name,string surname,DateOnly Date,string Licence)
		{
			this.name = name;
			this.surname = surname;
			Dob = Date;
			LicenceNo = Licence;
		}


        public Driver() {
            name = "";
            surname = "";
            LicenceNo = "";

        }
        // Method to set the driver's first name.

        public void SetName(string n)
		{
			name = n;
		}

        // Method to get the driver's first name.
        public string Getname()
		{
			return name;
		}

        // Method to set the driver's surname.

        public void SetSurname(string n)
        {
            surname = n;
        }

        // Method to get the driver's surname.
        public string GetSurname()
        {
            return surname;
        }
        // Method to set the driver's date of birth.
        public void SetDob(DateOnly Date)
        {
            Dob=Date;
        }

        // Method to get the driver's date of birth.
        public DateOnly GetDob()
        {
            return Dob;
        }
        // Method to set the driver's license number.
        public void SetLicence(string l)
        {
            LicenceNo= l;
        }

        // Method to get the driver's license number.
        public string GetLicence()
        {
            return LicenceNo;
        }
        // Method to display the driver's information.
        public string DisplayDriverInfo()
        {
            return $"Driver Name {Getname()} Surname{GetSurname()} DOb {GetDob()} LicenceNo {GetLicence()} ";
        }
    }
}

