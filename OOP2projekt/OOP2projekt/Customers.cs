using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2projekt
{
    /// <summary>
    /// Denna klass innehåller metoder och konstruktor som används för objekt av klassen, Customers.
    /// </summary>
    class Customers
    {
        private int _number;
        private string _name;
        private string _phone;
        private string _email;
        public int Number //Non-negative
        {
            get { return _number; }
            set
            {
                if (value < 0)
                    throw new CodeNotValidException("Customer number cannot be negative!");
                else
                    _number = value;
            }
        }
        public string Name //Non-empty
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new NullValueException("Customer name cannot be null or empty!");
                else
                    _name = value;
            }
        }
        public string Phone //Non-empty
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Email //Non-empty
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new NullValueException("Customer email cannot be null or empty!");
                else
                    _email = value;
            }
        }
        public Customers()
        {

        }
        public Customers(string name, string phone, string email, int number)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Number = number;
        }
        public override string ToString()
        {
            return Name + ", telefon: " + Phone + ", epost: " + Email + " ID: " + Number;
        }
    }
}
