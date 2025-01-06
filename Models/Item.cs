using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
       
        public string Description { get; set; }
       
        public int Quantity { get; set; }
        public float Discount { get; set; }
        //private decimal unitPrice;
        public float UnitPrice { get; set; }
       
        public float Amount { get; set; } 


    }
}
