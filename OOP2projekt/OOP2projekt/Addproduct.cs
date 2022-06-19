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
    /// Detta är en form klass där användare kan lägga till, visa och modifiera produkter i GUI.
    /// </summary>
    public partial class Addproduct : Form
    {
        Catalogue catalogue = new Catalogue();
        Products p = new Products();
        public delegate void ListAddHandler();
        /// <summary>
        /// Konstruktorn uppdaterar och sorterar efter event
        /// </summary>
        public Addproduct()
        {
            InitializeComponent();
            catalogue.CatalogueChanged += OutofStock;
            OutofStock();
            catalogue.CatalogueChanged += Refreshlistbox;
            catalogue.CatalogueChanged += sorttodate;
            sorttodate();
            Refreshlistbox();


        }
        /// <summary>
        /// Skapar en produkt och lägger till i listan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill in all boxes");
            }
            else
            {
                string name = textBox1.Text;
                double price = Convert.ToDouble(textBox2.Text);
                int stock = Int32.Parse(textBox3.Text);
                DateTime firstavailable = Convert.ToDateTime(textBox4.Text);
                Products newProduct = new Products(stock, name, price, firstavailable, catalogue.uniqueID());
                catalogue.addtocatalogue(newProduct);
                Refreshlistbox();
            }
        }
        /// <summary>
        /// Uppdaterar listboxen
        /// </summary>
        private void Refreshlistbox()
        {
           listBox1.Items.Clear();
           foreach (Products p in catalogue.AllProducts())
           {
              listBox1.Items.Add(p);
           }
        }
        /// <summary>
        /// Kollar vilka varor som inte finns i lager och lägger de i listbox2
        /// </summary>
        private void OutofStock()
        {
           listBox2.Items.Clear();
           var nostock = catalogue.catalogue.Where(p => p.Stock == 0);
           listBox2.Items.AddRange(nostock.Cast<object>().ToArray());

        }
        /// <summary>
        /// Sorterar efter datum
        /// </summary>
        private void sorttodate()
        {
           listBox3.Items.Clear();
           List<Products> sortedbydate = catalogue.catalogue;
           DateTime dtcurrent = DateTime.Now;
           //sortedbydate.Sort((p.Firstavailable) => DateTime.Compare(p.Firstavailable, dtcurrent));
           var orderedList = sortedbydate.OrderBy(p => DateTime.Parse(p.Firstavailable.ToString())).ToList(); // Sortera ifrån datum, närmaste först.
           var andIsStock = orderedList.Where(p => p.Stock > 0); // Filtrera bort varor som inte är i lager.
           listBox3.Items.AddRange(andIsStock.Cast<object>().ToArray()); //Skriv ut till lista 3.
         
        }
        /// <summary>
        /// Tar bort vald produkt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please choose something to remove");
            }
            else
            {
                Products p = listBox1.SelectedItem as Products;
                catalogue.RemoveProduct(p.Name);
            }
        }
        /// <summary>
        /// Uppdaterar vald produkt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBTN_Click(object sender, EventArgs e)
        {
            
                try
                {
                    Products p = listBox1.SelectedItem as Products;
                    string oldName = p.Name;
                    string newName = textBox1.Text;
                    double newPrice = double.Parse(textBox2.Text);
                    int newStock = int.Parse(textBox3.Text);
                    DateTime newFirst = Convert.ToDateTime(textBox4.Text);
                    DateTime newRestock = Convert.ToDateTime(price_text.Text);
                    catalogue.UpdateProductPrice(oldName, newName, newPrice, newStock, newFirst, newRestock);
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Fel vid uppdatering!\n\n" + ex.ToString());
                }
                catch (Exception ex) // Hantera andra generella fel
                {
                    MessageBox.Show("Kunde inte uppdatera produktpris! Är en produkt markerad? \n\nTeknisk Information för nördar:\n" + ex.ToString());
                }
            

        }
        /// <summary>
        /// Gör det möjligt att uppdatera vald produkt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Products p = (Products)listBox1.SelectedItem;
            try
            {
                textBox1.Text = p.Name;
                textBox2.Text = p.Price.ToString();
                textBox3.Text = p.Stock.ToString();
                textBox4.Text = p.Firstavailable.ToString();
                price_text.Text = p.NextStocking.ToString();
            }
            catch (NullReferenceException)
            {
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void price_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
