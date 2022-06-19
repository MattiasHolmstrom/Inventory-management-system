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
    public delegate void ChangeHandler();
    /// <summary>
    /// Klass där vi lagrar och modifierar listan av produkter, catalogue. Ärver från IStorage.
    /// </summary>
    class Catalogue: IStorage
    {
        string file = @"U:\OOP2projekt\OOP2projekt\products.json";
        public List<Products> catalogue = new List<Products>();
        Products p = new Products();
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Catalogue()
        {
            deserializejson();
        }
        /// <summary>
        /// Skriver till filen products.json
        /// </summary>
        public void serializejson()
        {
            var prettyprint = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string products = JsonSerializer.Serialize(catalogue, prettyprint);
            File.WriteAllText(file, products);
        }
        /// <summary>
        /// Läser av filen products.json
        /// </summary>
        public void deserializejson()
        {
            if (File.Exists(file))
            {
                string readfile = File.ReadAllText(file);
                catalogue = JsonSerializer.Deserialize<List<Products>>(readfile);
            }
            else catalogue = new List<Products>();
        }

        /// <summary>
        /// Kallar på eventet Cataloguechanged
        /// </summary>
        public void RaiseCatalogueChanged()
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
        }
        public event ChangeHandler CatalogueChanged;

        /// <summary>
        /// Letar efter angiven produkt i catalogue med hjälp av namnet
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Products FindProduct(string name)
        {
            foreach (Products p in catalogue)
                if (p.Name == name)
                    return p;
            return null;
        }
        /// <summary>
        /// Lägger till objekt av klassen product i catalogue listan
        /// </summary>
        /// <param name="p"></param>
        public void addtocatalogue(Products p)
        {
            catalogue.Add(p);
            serializejson();
            deserializejson();
            RaiseCatalogueChanged();

        }
        /// <summary>
        /// Tar bort objekt av kalssen product i catalogue listan 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool RemoveProduct(string name)
        {
            Products p = FindProduct(name);
            if (p == null)
                return false;
            if (catalogue.Remove(p))
            {
                serializejson();
                RaiseCatalogueChanged();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Ändrar och uppdaterar objekt av kalssen product i catalogue listan
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        /// <param name="first"></param>
        /// <param name="restock"></param>
        /// <returns></returns>
        public bool UpdateProductPrice(string oldName, string newName, double price, int stock, DateTime first, DateTime restock)
        {
            Products p = FindProduct(oldName);
            if (p == null)
                return false;
            p.Name = newName;
            p.Price = price;
            p.Stock = stock;
            p.Firstavailable = first;
            p.NextStocking = restock;
            serializejson();
            RaiseCatalogueChanged();
            return true;
        }
        /// <summary>
        /// Uppdaterar lagersaldo
        /// </summary>
        /// <param name="p"></param>
        /// <param name="quantity"></param>
        public void UpdateStock(Products p, int quantity)
        {
            p.Stock = p.Stock - quantity;
            serializejson();
            RaiseCatalogueChanged();


        }
        /// <summary>
        /// Skapar ett unikt ID för varje objekt av kalssen product i catalogue listan
        /// </summary>
        /// <returns></returns>
        public int uniqueID()
        {
            int maxnumber = 0;
            if(catalogue.Count == 0)
            {
                maxnumber = 1;
                return maxnumber;
            }
            else
            {
                maxnumber = catalogue.Max<Products>(p => p.Code);
                maxnumber++;
                return maxnumber;
            }

        }
        /// <summary>
        /// Retunerar catalogue listan
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Products> AllProducts()
        {
            return catalogue;
        }
    }
}
