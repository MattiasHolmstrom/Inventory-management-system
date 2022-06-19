using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2projekt
{
    /// <summary>
    /// Denna klass innehåller metoder och konstruktor som används för objekt av klassen, Products.
    /// </summary>
    class Products
    {
        //skapa ytterligare kod för att lägga till id(code) samt resterande variabler som inte sätts i konstruktorn.
        private int _code;
        private string _name;
        private double _price;
        private int _stock;
        private DateTime _firstAvailable;
        private DateTime _nextStocking;
        public int Code //Non-negative
        {
            get { return _code; }
            set
            {
                if (value < 0)
                    throw new CodeNotValidException("Product ID cannot be negative!");
                else
                    _code = value;
            }
        }
        public string Name //Non-empty
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new NullValueException("Product name cannot be null or empty!");
                else
                    _name = value;
            }
        }
        public double Price //Non-negative
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new CodeNotValidException("Product price cannot be negative!");
                else
                    _price = value;
            }
        }
        public int Stock //Non-negative
        {
            get { return _stock; }
            set
            {
                if (value < 0)
                    throw new CodeNotValidException("Product stock cannot be negative!");
                else
                    _stock = value;
            }
        }
        public DateTime Firstavailable
        {
            get { return _firstAvailable; }
            set { _firstAvailable = value; }
        }
        public DateTime NextStocking
        {
            get { return _nextStocking; }
            set { _nextStocking = value; }
        }
        public Products()
        {

        }
        public Products(int stock, string name, double price, DateTime firstavailable, int code)
        {
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Firstavailable = firstavailable;
            this.Code = code;
            DateTime temp = firstavailable.AddDays(30);
            this.NextStocking = temp;

            
        }
        public override string ToString()
        {
            return Name + ", " + Price + "kr, i lager: " + Stock + "Id: " + Code + " Utgivningsdatum:" + Firstavailable + " Nästa leverans: " + NextStocking;
        }

    }
}
