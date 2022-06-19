using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2projekt
{
    public partial class Form1 : Form
    {
        Orderlist orderlist2;
        List<Orders> jsonlist = new List<Orders>();
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Form1()
        {
            orderlist2 = new Orderlist();
            InitializeComponent();
            watchNewOrders();
        }

        /// <summary>
        /// Öppnar form Addproduct form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Addproduct openform = new Addproduct();
            openform.Show();
        }
        /// <summary>
        /// Öppnar Addcustomer form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newCustbutton_Click(object sender, EventArgs e)
        {
            Addcustomer openform = new Addcustomer();
            openform.Show();
        }
        /// <summary>
        /// Öppnar Form2 formen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderForm_Click(object sender, EventArgs e)
        {
            Form2 openform = new Form2();
            openform.Show();
        }       

        public void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Öppnar upp Form3 formen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pendingBTN_Click(object sender, EventArgs e)
        {
            Form3 openform = new Form3();
            openform.Show();
        }
        /// <summary>
        /// Öppnar upp filhanteraren så att användaren kan lägga in sin json fil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start(@"U:\OOP2projekt\newOrders");
           
        }
        /// <summary>
        /// Inklippt från projektanvisningen. Ej implementerad.
        /// </summary>
        private void watchNewOrders()
        {
            FileSystemWatcher fsw = new FileSystemWatcher(@"U:\OOP2projekt\newOrders\",
           "*. json ");
            fsw.SynchronizingObject = this;
            fsw.Created += Fsw_Created;
            fsw.EnableRaisingEvents = true;
        }

        private void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(500);
            string json = File.ReadAllText(e.FullPath);
            Orders o = JsonSerializer.Deserialize<Orders>(json);
            orderlist2.addtooderlist(o);
            jsonlist.Add(o);
            File.Delete(e.FullPath);
        }
    }
}
