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
    public class AddressBookBL : IAddressBookBL
    {
        IAddressBookRL _repository;

        public AddressBookBL(IAddressBookRL repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AddressBookEntity>> GetAllContacts() => await _repository.GetAllContacts();
        public async Task<AddressBookEntity?> GetContactById(int id) => await _repository.GetContactById(id);
        public async Task<AddressBookEntity> AddContact(AddressBookEntity contact) => await _repository.AddContact(contact);
        public async Task<AddressBookEntity?> UpdateContact(int id, AddressBookEntity contact) => await _repository.UpdateContact(id, contact);
        public async Task<bool> DeleteContact(int id) => await _repository.DeleteContact(id);
    }
}