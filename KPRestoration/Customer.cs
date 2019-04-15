/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * PCustomer.cs - stores data related to buyers and      *
 *  sellers.                                             *
 *  Parent class of TitleHolder                          *
 * ******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRestoration
{
    class Customer
    {
        // Members
        private int id;
        private string firstName;
        private string lastName;
        private string address;
        private string state;
        private int zip;
        private string phone;
        private string email;

        // Getters and setters
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string State { get => state; set => state = value; }
        public int Zip { get => zip; set => zip = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
    }
}
