using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class ItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal UnitPrice { get; set;}
        public decimal Amount { get; set; }
        
    }
}
