using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2projekt
{
    /// <summary>
    /// Denna formklass används för att skapa orders.
    /// </summary>
    public partial class Form2 : Form
    {
        Orderlist orderlist = new Orderlist();
        Customers c = new Customers();
        Products p = new Products();
        Catalogue productlist = new Catalogue();
        CustomerList customerlist = new CustomerList();
        Addcustomer addcustomerform = new Addcustomer();
        Addproduct addproductform = new Addproduct();
        List<OrderLine> Items = new List<OrderLine>();
        OrderLine orderline = new OrderLine();
        /// <summary>
        /// Konstruktor där listor uppdateras genom event samt metoder.
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            customerlist.CustomersChanged += RefreshCustomers;
            productlist.CatalogueChanged += RefreshProducts;

            RefreshProducts();
            RefreshCustomers();
        }
        /// <summary>
        /// Uppdaterar customerlist
        /// </summary>
        private void RefreshCustomers()
        {
            comboBox1.Items.Clear();
            foreach (Customers c in customerlist.AllCustomers())
            {
                comboBox1.Items.Add(c);
            }
        }
        /// <summary>
        /// Uppdaterar Produkter
        /// </summary>
        private void RefreshProducts()
        {
            //listBox1.Items.Clear();
            //foreach (Products p in productlist.AllProducts())
            //{
            //    listBox1.Items.Add(p);
            ////}
            listBox1.DataSource = null;
            listBox1.DataSource = productlist.AllProducts();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Lägger till produkter i kundvagnen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void addtocartBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    
                    MessageBox.Show("Quantity can not be empty");
        
                }
                else
                {

                    listBox3.Items.Add(listBox1.SelectedItem);
                    int quantity = Int32.Parse(textBox1.Text);
                    Products toOrder;
                    toOrder = listBox1.SelectedItem as Products;
                    if (productlist.FindProduct(toOrder.Name) == null)
                    {
                        MessageBox.Show("Product does not exist");
                    }
                    else
                    {
                        OrderLine orderline = new OrderLine(toOrder, quantity);
                        Items.Add(orderline);
                    }
                }
            
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please choose a product.");
            }
        }
        
        /// <summary>
        /// Skapar en ny order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null || textBox2.Text == "")
                {
                    MessageBox.Show("Välj en order och fyll i adress");
                }
                else
                {
                    Customers selectedCustomer;
                    selectedCustomer = comboBox1.SelectedItem as Customers;
                    DateTime orderdate = DateTime.Today;
                    String DeliveryAddress = textBox2.Text;
                    Orders neworder = new Orders(orderlist.uniqueID(), selectedCustomer, orderdate, DeliveryAddress, Items);
                    orderlist.addtooderlist(neworder);
                    MessageBox.Show("Order added, go to pending order to dispatch it.");
                }
                
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please choose an order.");
            }
           

        }
        /// <summary>
        /// Returnerar senaste orderline listan.
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderLine> Orderedproducts()
        {
            return Items;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
