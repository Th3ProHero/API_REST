using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.FurnitureStore.Shared
{
    public class Product
    {
        public int ID { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int productCategory {  get; set; }
    }
}
