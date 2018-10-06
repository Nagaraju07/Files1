using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace IDeserializationCallbackDemo
{
    [Serializable]
    public class Product : IDeserializationCallback
    {
        int id;
        public int ProdID
        {   get { return id; } set { id = value; }  }

        int price;
        public int Price
        {   get { return price; } set { price = value; }  }

        int qty;
        public int Quantity
        {   get { return qty; } set { qty = value; }  }

        [NonSerialized]
        int total;
        public int Total
        {   get { return total; }   }

        public Product(int id, int price, int qty)
        {
            this.id = id;
            this.price = price;
            this.qty = qty;
            total = this.price * this.qty;
        }

        //public void CalculateTotal()
        //{
        //    this.total = this.qty * this.price;
        //}

        public void OnDeserialization(object sender)
        {
            this.total = this.qty * this.price;
        }
    }
}
