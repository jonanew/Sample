using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public decimal Amount { get; set; }

        public string DOB { get; set; }

        public User( int id, string fname, string lname, string dob, string address, string city, decimal amount )
        {
            this.UserId = id;
            this.FirstName = fname;
            this.LastName = lname;
            this.DOB = dob;
            this.Address = address;
            this.City = city;
            this.Amount = amount;

        }

    }
}
