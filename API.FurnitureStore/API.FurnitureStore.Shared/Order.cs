using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.FurnitureStore.Shared
{
    public class Order
    {
        public int ID { get; set; }

        public int orderNumber {  get; set; }  

        public int clientID { get; set; }

        public DateTime orderDate { get; set; }

        public DateTime deliveryDate { get; set; }

    }
}
