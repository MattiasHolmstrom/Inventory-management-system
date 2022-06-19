using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OOP2projekt
{
    /// <summary>
    /// Detta är en lagringsklass som precis som catalogue och customerlist ärver från interfacet Istorage
    /// </summary>
    class Orderlist:IStorage
    {
        string file = @"U:\OOP2projekt\OOP2projekt\orders.json";
        string dispatchedfile = @"U:\OOP2projekt\OOP2projekt\dispatched.json";
        
        public List<Orders> orderlist = new List<Orders>();
        public List<Orders> dispatched = new List<Orders>();
        Catalogue catalogue = new Catalogue();
      

        public Orderlist()
        {
           
            deserializejson();
            deserializedispatched();
            
        }
        /// <summary>
        /// Skriver till en fil i orders.json
        /// </summary>
        public void serializejson()
        {
            var prettyprint = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string products = JsonSerializer.Serialize(orderlist, prettyprint);
            File.WriteAllText(file, products);
        }
        /// <summary>
        /// Läser av filen oders.json, kollar även i products för att se att referensen till produkten är korrekt och ändrar om den inte är det.
        /// </summary>
        public void deserializejson()
        {
            if (File.Exists(file))
            {
                string readfile = File.ReadAllText(file);
                orderlist = JsonSerializer.Deserialize<List<Orders>>(readfile);
              
                foreach (Orders o in orderlist)
                {
                    
                    foreach (OrderLine orderl in o.Items)
                    {
                        try
                        {
                            orderl.Product = catalogue.AllProducts().First(a => a.Code == orderl.Product.Code);
                        }
                        catch
                        {
                            orderl.Product = orderl.Product;
                        }
                    }

                }
            }

            else orderlist = new List<Orders>();
        }
        /// <summary>
        /// Läser av filen dispatched.json
        /// </summary>
        public void deserializedispatched()
        {
            if (File.Exists(dispatchedfile))
            {
                string readfile = File.ReadAllText(dispatchedfile);
                dispatched = JsonSerializer.Deserialize<List<Orders>>(readfile);
            }
            else dispatched = new List<Orders>();
        }
        /// <summary>
        /// Skriver till en fil i dispatched.json
        /// </summary>
        public void serializedispatched()
        {
            var prettyprint = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string products = JsonSerializer.Serialize(dispatched, prettyprint);
            File.WriteAllText(dispatchedfile, products);
        }

        /// <summary>
        /// Triggar eventet
        /// </summary>
        public void RaiseOrdersChanged()
        {
            if (OrderChanged != null)
                OrderChanged();
        }
        public event ChangeHandler OrderChanged;
        /// <summary>
        /// Letar efter given number i orderlist
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Orders FindOrder(int number)
        {
            foreach (Orders o in orderlist)
                if (o.Number == number)
                    return o;
            return null;
        }
        /// <summary>
        /// Hittar alla orders av en specifik customer och lägger till det i orderlist listan
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public List<Orders> FindOrderByCustomer(Customers b)
        {
            List<Orders> byCustomer = new List<Orders>();
            
            


                foreach (Orders o in orderlist)
                {
                    Customers c = o.Customer;

                    if (c.Name == b.Name)
                    {
                        byCustomer.Add(o);
                    }
                    return byCustomer;
                }
            
            
            return null;
        }
        /// <summary>
        /// Adderar ett objekt av orders i listan orderlist
        /// </summary>
        /// <param name="o"></param>
        public void addtooderlist(Orders o)
        {
            orderlist.Add(o);
            serializejson();
            deserializejson();
            RaiseOrdersChanged();
        }
        /// <summary>
        /// Adderar ett objekt av orders i dispatched listan
        /// </summary>
        /// <param name="o"></param>
        public void addToDispatched(Orders o)
        {
            dispatched.Add(o);
            serializedispatched();
            RaiseOrdersChanged();
        }
        /// <summary>
        /// En bool som tar in en int och en Orders och retunerar true om count > 0 annars false.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool verify(int count, Orders o)
        {
            if (count > 0)
            {
                
                o.PaymentCompleted = true;
                o.Dispatched = true;
                
                serializejson();
                addToDispatched(o);
                RaiseOrdersChanged();
                return true;

            }
            else
                o.PaymentRefunded = true;
                return false;
        }


        /// <summary>
        /// tar emot en int för att hitta orderna som efterfrågas och sedan tar bort den från orderlist listan
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool RemoveOrder(int number)
        {
            Orders o = FindOrder(number);
            if (o == null)
                return false;
            if (orderlist.Remove(o))
            {
                serializejson();
                RaiseOrdersChanged();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Skapar ett unikt ID för objeket orders i orderlist listan
        /// </summary>
        /// <returns></returns>
        public int uniqueID()
        {
            int maxnumber = 0;
            if (orderlist.Count == 0)
            {
                maxnumber = 1;
                return maxnumber;
            }
            else
            {
                maxnumber = orderlist.Max<Orders>(o => o.Number);
                maxnumber++;
                return maxnumber;
            }
        }
        /// <summary>
        /// Retunerar orderlist
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Orders> AllOrders()
        {
            return orderlist;
        }
        /// <summary>
        /// Retunerar dispatched
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Orders> DispatchedOrders()
        {
            return dispatched;       
        }                      
    }
}

