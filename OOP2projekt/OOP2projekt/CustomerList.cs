using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OOP2projekt
{
    /// <summary>
    /// Klassen lagrar och modifierar listan på customers.
    /// </summary>
    class CustomerList: IStorage
    {
        string file = @"U:\OOP2projekt\OOP2projekt\customers.json";
        string dispatched = @"";
        List<Customers> customerlist = new List<Customers>();
        Customers c = new Customers();
        public CustomerList()
        {
            deserializejson();
        }
        /// <summary>
        /// Triggar eventet
        /// </summary>
        private void RaiseCustomersChanged()
        {
            if (CustomersChanged != null)
                CustomersChanged();
        }
        /// <summary>
        /// Skriver till i filen Customers.json
        /// </summary>
        public void serializejson()
        {
            var prettyprint = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string customers = JsonSerializer.Serialize(customerlist, prettyprint);
            File.WriteAllText(file, customers);
        }
        /// <summary>
        /// Läser av filen Customers.json
        /// </summary>
        public void deserializejson()
        {
            if (File.Exists(file))
            {
                string readfile = File.ReadAllText(file);
                customerlist = JsonSerializer.Deserialize<List<Customers>>(readfile);
            }
            else customerlist = new List<Customers>();
        }
        public event ChangeHandler CustomersChanged;
        /// <summary>
        ///   Letar efter angiven costumer i customerlist med hjälp av namnet
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customers findCustomer(string name)
        {
            foreach (Customers c in customerlist)
                if (c.Name == name)
                    return c;
            return null;
        }
        /// <summary>
        /// Adderar ett objekt av customers i customerlist
        /// </summary>
        /// <param name="c"></param>
        public void addtocustomers(Customers c)
        {
            customerlist.Add(c);
            RaiseCustomersChanged();
            serializejson();
        }
        /// <summary>
        /// Tar bort ett objekt av customers i customerlist listan
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool RemoveCustomer(string name)
        {
            Customers c = findCustomer(name);
            if (c == null)
                return false;
            if (customerlist.Remove(c))
            {
                serializejson();
                RaiseCustomersChanged();
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Uppdaterar angiven parameter i customerlist listan
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <param name="phonenumber"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool UpdCustomer(string oldName, string newName, string phonenumber, string email)
        {
            Customers c = findCustomer(oldName);
            if (c == null)
                return false;
            c.Name = newName;
            c.Phone = phonenumber;
            c.Email = email;
            RaiseCustomersChanged();
            serializejson();
            return true;
        }
        /// <summary>
        /// Skapar ett unikt ID för ett objekt av customers i customerlist listan
        /// </summary>
        /// <returns></returns>
        public int uniqueID()
        {
            int maxnumber = 0;
            if (customerlist.Count == 0)
            {
                maxnumber = 1;
                return maxnumber;
            }
            else
            {
                maxnumber = customerlist.Max<Customers>(c => c.Number);
                maxnumber++;
                return maxnumber;
            }

        }
        /// <summary>
        /// Retunerar listan customerlist
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customers> AllCustomers()
        {
            return customerlist;
        }
    }
}
