using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace RepositoryLayer.Interface
{
    public interface IAddressBookRL
    {
        Task<IEnumerable<AddressBookEntity>> GetAllContacts();
        Task<AddressBookEntity?> GetContactById(int id);
        Task<AddressBookEntity> AddContact(AddressBookEntity contact);
        Task<AddressBookEntity?> UpdateContact(int id, AddressBookEntity contact);
        Task<bool> DeleteContact(int id);
    }
}