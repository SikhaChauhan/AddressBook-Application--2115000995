﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Service;

namespace BusinessLayer.Interface
{
    //Interface for AddressBook BL.
    public interface IAddressBookBL
    {
        Task<IEnumerable<AddressBookEntity>> GetAllContacts();
        Task<AddressBookEntity?> GetContactById(int id);
        Task AddContact(AddressBookEntity contact);
        Task<AddressBookEntity?> UpdateContact(int id, AddressBookEntity contact);
        Task<bool> DeleteContact(int id);
    }
}