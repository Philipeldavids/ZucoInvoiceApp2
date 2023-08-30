using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IInvoiceService
    {
        Task<bool> CreateInvoice(InvoiceDTO invoicedto);
        Task<Invoice> GetInvoiceById(int Id);
        Task<bool> UpdateInvoiceAsync(Invoice invoice);
        Task<bool> DeleteInvoiceAsync(int Id);
        Task<List<Invoice>> GetInvoice();
    }
}
