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
    /// Detta är en formklass med knappar, listboxes, textboxes och labels så att användaren kan visa, lägga till och modifiera customers i GUI.
    /// </summary>
    public partial class Addcustomer : Form
    {
        CustomerList customerlist = new CustomerList();
        Orderlist orderlist = new Orderlist();
        /// <summary>
        /// Konstruktor, som kör metod enligt event
        /// </summary>
        public Addcustomer()
        {
            InitializeComponent();
            customerlist.CustomersChanged += Refreshlistbox;
            Refreshlistbox();
        }
        /// <summary>
        /// Skapar en ny customer och skickar vidare den till metod i customerlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
      
                if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Please fill in all values");
                }
                else
                {
                    string name = textBox1.Text;
                    string phone = textBox3.Text;
                    string email = textBox4.Text;
                    Customers newCustomer = new Customers(name, phone, email, customerlist.uniqueID());
                    customerlist.addtocustomers(newCustomer);
                    Refreshlistbox();
                }

        }
        /// <summary>
        /// Lägger till den uppdataderade customerlistan i listboxen.
        /// </summary>
        private void Refreshlistbox()
        {
            listBox1.Items.Clear();
            foreach (Customers c in customerlist.AllCustomers())
            {
                listBox1.Items.Add(c);
                
            }
        }
        /// <summary>
        /// Hittar och visar upp ordar lagda av en viss customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Customers a = listBox1.SelectedItem as Customers;
            if (orderlist.FindOrderByCustomer(a) != null)
            {
                listBox1.Items.Clear();
                foreach(Orders b in orderlist.FindOrderByCustomer(a))
                {

                    listBox1.Items.Add(b);
                }

            }
            else
                MessageBox.Show("The chose customer has no orders");
        }

        private void newNumber_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Tar bort vald customer från listan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeBTN_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Choose an item to remove");
            }
            else
            {
                Customers c = listBox1.SelectedItem as Customers;
                customerlist.RemoveCustomer(c.Name);
            }

        }
        /// <summary>
        /// Uppdaterar informationen av customers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                Customers c = listBox1.SelectedItem as Customers;
                string oldName = c.Name;
                string newName = textBox1.Text;
                string newphone = textBox3.Text;
                string newEmail = textBox4.Text;
                customerlist.UpdCustomer(oldName, newName, newphone, newEmail);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Ändrar tillbaka till att visa customers efter att man kollat upp customers ordrar(onclick).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Customers c in customerlist.AllCustomers())
            {
                listBox1.Items.Add(c);

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Gör det möjligt att ändra customer information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customers c = (Customers)listBox1.SelectedItem;
            try
            {
                textBox1.Text = c.Name;
                textBox3.Text = c.Phone;
                textBox4.Text = c.Email;
            }
            catch (NullReferenceException)
            {
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

    }
}
