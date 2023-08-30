using DataLayer.Repository;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateInvoice(InvoiceDTO invoicedto)
        {
            await _unitOfWork.InvoiceRepository.CreateInvoice(invoicedto);
            return true;
        }

        public async Task<Invoice> GetInvoiceById(int Id)
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetInvoiceByIdAsync(Id);

            return invoice;
        }
        public async Task<List<Invoice>> GetInvoice()
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetInvoice();
            return invoice;
        }
        public async Task<bool> DeleteInvoiceAsync(int Id)
        {
            var result = await _unitOfWork.InvoiceRepository.DeleteInvoice(Id);
            return result;
        }
        public async Task<bool> UpdateInvoiceAsync(Invoice invoice)
        {
            var result = await _unitOfWork.InvoiceRepository.UpdateInvoice(invoice);
            return result;
        }
    }
}
