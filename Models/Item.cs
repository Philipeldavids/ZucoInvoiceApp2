using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        public int Quantity { get; set; }
        public int Discount { get; set; }
        //private decimal unitPrice;
        public decimal UnitPrice { get; set; }

        public decimal amount;
        public decimal Amount { get { return amount; } set { amount = value; amount = (Quantity * UnitPrice) - Discount; } } 


    }
}
