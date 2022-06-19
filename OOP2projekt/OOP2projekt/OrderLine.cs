using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2projekt
{
    /// <summary>
    /// Klass som möjliggör skapande av objektet orderline.
    /// </summary>
    class OrderLine 
    {
        //private Products Product;
        //private int Count;

        public Products Product { get; set; }
        public int Count { get; set; }

        //public int count // Kan man handla varor negativt?
        //{
        //    get { return Count; }
        //    set
        //    {
        //        if (value < 0)
        //            throw new CodeNotValidException("OrderLine count cannot be negative!");
        //        else
        //            Count = value;
        //    }
        //}
        //public Products product { get { return Product; }
        //    set
        //    {
        //        if(value == null)
        //        {
        //            throw new ArgumentNullException("");
        //        }
        //        product = value;
        //    }
        //}


        public OrderLine()
        {

        }

        public OrderLine(Products product, int count)
        {
            this.Product = product;
            this.Count = count;
            //product = Product;
            //count = Count;
        }

        public override string ToString()
        {
            return Product.Name + ", Antal: " + Count;
        }
    }
}
