using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2projekt
{
    /// <summary>
    /// Denna klass innehåller metoder och konstruktor som används för objekt av klassen, Orders.
    /// </summary>
    class Orders
    {
        private int _number;
        private Customers _customer;
        private DateTime _orderdate;
        private string _deliveryadress;
        private bool _paymentcompleted;
        private bool _paymentrefunded;
        private bool _dispatched;
        private List<OrderLine> _items;
        public int Number //Non-negative
        {
            get { return _number; }
            set
            {
                if (value < 0)
                    throw new CodeNotValidException("Order number cannot be negative!");
                else
                    _number = value;
            }
        }
        public Customers Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        public DateTime OrderDate
        {
            get { return _orderdate; }
            set { _orderdate = value; }
        }
        public string DeliveryAddress //Non-empty
        {
            get { return _deliveryadress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new NullValueException("Delivery adress cannot be null or empty!");
                else
                    _deliveryadress = value;
            }
        }
        public bool PaymentCompleted
        {
            get { return _paymentcompleted; }
            set { _paymentcompleted = value; }
        }
        public bool PaymentRefunded
        {
            get { return _paymentrefunded; }
            set { _paymentrefunded = value; }
        }
        public bool Dispatched
        {
            get { return _dispatched; }
            set { _dispatched = value; }
        }
        public List<OrderLine> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public Orders()
        {

        }
        public Orders(int number, Customers customer, DateTime orderDate, string deliveryAddress, List<OrderLine> items)
        {
            this.Number = number;
            this.Customer = customer;
            this.OrderDate = orderDate;
            this.DeliveryAddress = deliveryAddress;
            this.Items = items;

            
        }
        public override string ToString()
        {
            return Number + ", Kund: " + Customer + "Beställningsdatum:  " + OrderDate + "Adress: " + DeliveryAddress + " Beställda produkter: " + Items;
        }
    }
}
