using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class InvoiceDTO
    {

       
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
        public int Tax { get; set; }

        public string FootNote { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Item> Items { get; set; }

    }
}
