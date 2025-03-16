using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Service;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// Interface defining the contract for the Address Book Business Layer.
    /// Provides methods to perform CRUD operations on contact information.
    /// </summary>
    public interface IAddressBookBL
    {
        /// <summary>
        /// Retrieves all contacts from the address book.
        /// </summary>
        /// <returns>A collection of AddressBookEntity representing all contacts.</returns>
        Task<IEnumerable<AddressBookEntity>> GetAllContacts();

        /// <summary>
        /// Retrieves a specific contact by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact.</param>
        /// <returns>The AddressBookEntity if found, otherwise null.</returns>
        Task<AddressBookEntity?> GetContactById(int id);

        /// <summary>
        /// Adds a new contact to the address book.
        /// </summary>
        /// <param name="contact">The contact information to add.</param>
        /// <returns>The added AddressBookEntity with its assigned identifier.</returns>
        Task<AddressBookEntity> AddContact(AddressBookEntity contact);

        /// <summary>
        /// Updates an existing contact in the address book.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to update.</param>
        /// <param name="contact">The updated contact information.</param>
        /// <returns>The updated AddressBookEntity if successful, otherwise null.</returns>
        Task<AddressBookEntity?> UpdateContact(int id, AddressBookEntity contact);

        /// <summary>
        /// Deletes a contact from the address book by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        Task<bool> DeleteContact(int id);
    }
}
