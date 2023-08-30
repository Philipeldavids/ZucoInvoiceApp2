using DataLayer.Database;
using DataLayer.Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DataLayer.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public InvoiceRepository(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<Invoice> GetInvoiceByIdAsync(int Id)
        {
            var invoice = await _applicationDbContext.Invoices
                         .Where(x => x.InvoiceID == Id)
                         .FirstOrDefaultAsync();

            return invoice;
        }
        public async Task<List<Invoice>> GetInvoice()
        {
            List<Invoice> items = new List<Invoice>();

            var data = from item in _applicationDbContext.Invoices
                       select new Invoice()
                       {
                           InvoiceID = item.InvoiceID,
                           CustomerName = item.CustomerName,
                           CustomerEmail = item.CustomerEmail,
                           CustomerPhoneNumber = item.CustomerPhoneNumber,
                           CustomerAddress = item.CustomerAddress,
                           CreatedDate = item.CreatedDate,
                           Status = item.Status,
                           Tax = item.Tax,
                           FootNote = item.FootNote,
                           TotalPrice = item.TotalPrice,
                           Items = item.Items,
                       };
            return data.ToList();
        }
        public async Task<bool> CreateInvoice(InvoiceDTO invoicedto)
        {
            Invoice invoice = new Invoice();


            invoice.CustomerName = invoicedto.CustomerName;
            invoice.CustomerEmail = invoicedto.CustomerEmail;
            invoice.CustomerPhoneNumber = invoicedto.CustomerPhoneNumber;
            invoice.CustomerAddress = invoicedto.CustomerAddress;
            invoice.CreatedDate = invoicedto.CreatedDate;
            invoice.Status = invoicedto.Status;
            invoice.TotalPrice = invoicedto.Items.Sum(item => item.Amount);
            invoice.Items = invoicedto.Items;
            invoice.FootNote = invoicedto.FootNote;
            invoice.Tax = invoicedto.Tax;
               
            

            await _applicationDbContext.AddAsync(invoice);
            var result = await _applicationDbContext.SaveChangesAsync();
            
            return result > 0;
        }

        public async Task<bool> DeleteInvoice(int Id)
        {
            var invoice = await _applicationDbContext.Invoices.FirstOrDefaultAsync(invoice => invoice.InvoiceID == Id);
            if (invoice == null)
            {
                return false;
            }
            _applicationDbContext.Remove(invoice);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateInvoice(Invoice invoice)
        {
            var nvoice = await _applicationDbContext.Invoices.FirstOrDefaultAsync(invoic => invoic.InvoiceID == invoice.InvoiceID);
            if (nvoice == null){
                return false;
            }
            _applicationDbContext.Invoices.Update(nvoice);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result > 0;
        }

    }
}
