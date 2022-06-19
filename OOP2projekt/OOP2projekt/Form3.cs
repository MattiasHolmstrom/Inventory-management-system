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
    /// Denna formklassen tillåter använder att granska samt pending/dispatched orders samt dispatcha valda orders om möjligt.
    /// </summary>
    public partial class Form3 : Form
    {
        Orderlist orderlist = new Orderlist();
        Catalogue catalogue = new Catalogue();
        CustomerList customerList = new CustomerList();
        /// <summary>
        /// Kosntruktorn uppdaterar listorna.
        /// </summary>
        public Form3()
        {
            InitializeComponent();
            orderlist.OrderChanged += Refreshlistbox;
            orderlist.OrderChanged += RefreshDispatched;
            Refreshlistbox();
            RefreshDispatched();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Uppdaterar listbox1
        /// </summary>
        private void Refreshlistbox()
        {
            listBox1.Items.Clear();
            foreach (Orders o in orderlist.AllOrders())
            {
                if (o.Dispatched == false)
                {
                    listBox1.Items.Add(o);
                }
            }
        }
        /// <summary>
        /// Uppdaterar listbox2
        /// </summary>
        private void RefreshDispatched()
        {
            listBox2.Items.Clear();

            foreach (Orders o in orderlist.DispatchedOrders())
            {
                listBox2.Items.Add(o);
            }
        }
        /// <summary>
        /// Visar produkter samt customer av vald order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewPendingBTN_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please choose an order");
            }
            else
            {
                Orders chosen;
                chosen = listBox1.SelectedItem as Orders;
                List<OrderLine> Ordered = chosen.Items;
                Customers current;
                current = chosen.Customer;
                listBox3.Items.Clear();

                foreach (OrderLine selected in Ordered)
                {

                    //selected.Name
                    listBox3.Items.Add(selected);
                    listBox3.Items.Add(current);
                }
            }

        }
        /// <summary>
        /// Uppdaterar dispatched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewDispatchedBTN_Click(object sender, EventArgs e)
        {
            //RefreshDispatched();
            try
            {
                Orders chosen;
                chosen = listBox2.SelectedItem as Orders;
                List<OrderLine> Ordered = chosen.Items;
                Customers current;
                current = chosen.Customer;
                listBox4.Items.Clear();

                foreach (OrderLine selected in Ordered)
                {

                    //selected.Name
                    listBox4.Items.Add(selected);
                    listBox4.Items.Add(current);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please choose excisting order");
            }
        }
        /// <summary>
        /// Kollar om en order kan dispatchas och lägger därefter till i listbox om möjligt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 

            int count = 0;
            Orders chosen;
            //chosen = listBox1.SelectedItem as Orders;
            //List<OrderLine> Ordered = chosen.Items;
            //listBox2.Items.Clear();

            //var result = Ordered.Where(a => catalogue.catalogue.Any(b => a.Product.Name == b.Name));
            //foreach (var result in )
            //{

            //}
            //try
            //{
            chosen = listBox1.SelectedItem as Orders;
            //listBox2.Items.Add(chosen);
            List<OrderLine> Ordered = chosen.Items;

            foreach (OrderLine selected in Ordered)
            {
                int compare;

                Products p = selected.Product;

                foreach (Products a in catalogue.catalogue)
                {

                    if (p.Name == a.Name)
                    {
                        compare = a.Stock;
                        if (compare >= selected.Count && chosen.OrderDate < a.Firstavailable)
                        {
                            count++;

                            orderlist.verify(count, chosen);
                            catalogue.UpdateStock(a, selected.Count);

                            listBox2.Items.Add(chosen);
                            RefreshDispatched();
                            listBox1.Items.Remove(chosen);
                            //orderlist.RemoveOrder(chosen.Number);


                        }
                        else
                        {
                           MessageBox.Show("Produkten finns inte i lager");
                        }
                    }

                }

            }
            //}
            //catch (NullReferenceException)
            //{
            //    MessageBox.Show("Please choose excisting order");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Måste välja något");
            }
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
