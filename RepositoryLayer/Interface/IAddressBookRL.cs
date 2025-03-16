using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace RepositoryLayer.Interface
{
    /// <summary>
    /// Interface defining CRUD operations for Address Book management.
    /// </summary>
    public interface IAddressBookRL
    {
        /// <summary>
        /// Retrieves all contacts from the address book.
        /// </summary>
        /// <returns>A collection of AddressBookEntity objects.</returns>
        Task<IEnumerable<AddressBookEntity>> GetAllContacts();

        /// <summary>
        /// Retrieves a contact by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the contact.</param>
        /// <returns>An AddressBookEntity object if found, otherwise null.</returns>
        Task<AddressBookEntity?> GetContactById(int id);

        /// <summary>
        /// Adds a new contact to the address book.
        /// </summary>
        /// <param name="contact">The contact entity to be added.</param>
        /// <returns>The newly added AddressBookEntity object.</returns>
        Task<AddressBookEntity> AddContact(AddressBookEntity contact);

        /// <summary>
        /// Updates an existing contact in the address book.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to update.</param>
        /// <param name="contact">The updated contact information.</param>
        /// <returns>The updated AddressBookEntity object if successful, otherwise null.</returns>
        Task<AddressBookEntity?> UpdateContact(int id, AddressBookEntity contact);

        /// <summary>
        /// Deletes a contact from the address book.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        Task<bool> DeleteContact(int id);
    }
}
