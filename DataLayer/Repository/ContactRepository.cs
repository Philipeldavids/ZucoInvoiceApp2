using DataLayer.Database;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var contacts = _context.Contacts.ToList();
            return contacts;
        }
        public async Task<List<Contact>> GetContactByUser(string UserId)
        {
            var contact =  _context.Contacts.Where(x => x.UserId == UserId).OrderBy(x=> x.CustomerName).ToList();

            return contact;
        }

        public async Task<bool> AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            var result = _context.SaveChanges();
            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
