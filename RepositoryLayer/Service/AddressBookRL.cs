using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class AddressBookRL : IAddressBookRL
    {
        private readonly AddressBookDBContext _context;

        public AddressBookRL(AddressBookDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressBookEntity>> GetAllContacts()
        {
            return await _context.AddressBookEntries.ToListAsync();
        }

        public async Task<AddressBookEntity?> GetContactById(int id)
        {
            return await _context.AddressBookEntries.FindAsync(id);
        }

        public async Task<AddressBookEntity> AddContact(AddressBookEntity contact)
        {
            _context.AddressBookEntries.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<AddressBookEntity?> UpdateContact(int id, AddressBookEntity contact)
        {
            var existingContact = await _context.AddressBookEntries.FindAsync(id);
            if (existingContact == null) return null;

            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Address = contact.Address;

            await _context.SaveChangesAsync();
            return existingContact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _context.AddressBookEntries.FindAsync(id);
            if (contact == null) return false;

            _context.AddressBookEntries.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}