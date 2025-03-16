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
    /// <summary>
    /// Provides implementation for CRUD operations on the Address Book.
    /// </summary>
    public class AddressBookRL : IAddressBookRL
    {
        private readonly AddressBookDBContext _context;

        /// <summary>
        /// Initializes a new instance of the AddressBookRL class with the database context.
        /// </summary>
        /// <param name="context">The database context for interacting with the address book.</param>
        public AddressBookRL(AddressBookDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all contacts from the address book.
        /// </summary>
        /// <returns>A list of all address book entries.</returns>
        public async Task<IEnumerable<AddressBookEntity>> GetAllContacts()
        {
            return await _context.AddressBookEntries.ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific contact by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact.</param>
        /// <returns>The contact entity if found; otherwise, null.</returns>
        public async Task<AddressBookEntity?> GetContactById(int id)
        {
            return await _context.AddressBookEntries.FindAsync(id);
        }

        /// <summary>
        /// Adds a new contact to the address book.
        /// </summary>
        /// <param name="contact">The contact entity to add.</param>
        /// <returns>The newly added contact entity.</returns>
        public async Task<AddressBookEntity> AddContact(AddressBookEntity contact)
        {
            _context.AddressBookEntries.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        /// <summary>
        /// Updates an existing contact in the address book.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to update.</param>
        /// <param name="contact">The updated contact details.</param>
        /// <returns>The updated contact entity if found; otherwise, null.</returns>
        public async Task<AddressBookEntity?> UpdateContact(int id, AddressBookEntity contact)
        {
            var existingContact = await _context.AddressBookEntries.FindAsync(id);
            if (existingContact == null) return null;

            // Update contact properties
            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Address = contact.Address;

            await _context.SaveChangesAsync();
            return existingContact;
        }

        /// <summary>
        /// Deletes a contact from the address book.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to delete.</param>
        /// <returns>True if the contact was deleted; otherwise, false.</returns>
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