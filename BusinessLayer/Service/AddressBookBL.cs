using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

namespace BusinessLayer.Service
{
    /// <summary>
    /// Business Logic Layer (BL) for managing address book operations.
    /// Implements the IAddressBookBL interface and interacts with the Repository Layer.
    /// </summary>
    public class AddressBookBL : IAddressBookBL
    {
        // Private field to hold the repository instance
        private readonly IAddressBookRL _repository;

        /// <summary>
        /// Constructor to initialize the AddressBookBL with a repository instance.
        /// </summary>
        /// <param name="repository">The repository layer interface for address book operations.</param>
        public AddressBookBL(IAddressBookRL repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all contacts from the address book.
        /// </summary>
        /// <returns>An enumerable collection of AddressBookEntity objects.</returns>
        public async Task<IEnumerable<AddressBookEntity>> GetAllContacts() => await _repository.GetAllContacts();

        /// <summary>
        /// Retrieves a specific contact by its unique identifier (ID).
        /// </summary>
        /// <param name="id">The ID of the contact to retrieve.</param>
        /// <returns>The AddressBookEntity object if found, otherwise null.</returns>
        public async Task<AddressBookEntity?> GetContactById(int id) => await _repository.GetContactById(id);

        /// <summary>
        /// Adds a new contact to the address book.
        /// </summary>
        /// <param name="contact">The AddressBookEntity object representing the new contact.</param>
        /// <returns>The added AddressBookEntity object.</returns>
        public async Task<AddressBookEntity> AddContact(AddressBookEntity contact) => await _repository.AddContact(contact);

        /// <summary>
        /// Updates an existing contact in the address book.
        /// </summary>
        /// <param name="id">The ID of the contact to update.</param>
        /// <param name="contact">The updated AddressBookEntity object.</param>
        /// <returns>The updated AddressBookEntity object if successful, otherwise null.</returns>
        public async Task<AddressBookEntity?> UpdateContact(int id, AddressBookEntity contact) => await _repository.UpdateContact(id, contact);

        /// <summary>
        /// Deletes a contact from the address book by its ID.
        /// </summary>
        /// <param name="id">The ID of the contact to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        public async Task<bool> DeleteContact(int id) => await _repository.DeleteContact(id);
    }
}
