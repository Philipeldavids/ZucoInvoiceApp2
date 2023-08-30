using DataLayer.Database;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    
    public interface IInvoiceRepository
    {
        Task<Invoice> GetInvoiceByIdAsync(int Id);
        Task<bool> CreateInvoice(InvoiceDTO invoicedto);
        Task<List<Invoice>> GetInvoice();

        Task<bool> UpdateInvoice(Invoice invoice);
        Task<bool> DeleteInvoice(int Id);

    }
}
