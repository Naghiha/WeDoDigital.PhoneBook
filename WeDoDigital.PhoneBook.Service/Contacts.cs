using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeDoDigital.PhoneBook.DTO;
using WeDoDigital.PhoneBook.Interface;

namespace WeDoDigital.PhoneBook.Service
{
    public class Contacts : IContacts
    {
        private readonly IPhoneBookDBManagement _phoneBookDB;

        public Contacts(IPhoneBookDBManagement phoneBookDB)
        {
            _phoneBookDB = phoneBookDB;
        }

        public async Task<bool> Delete(int Id)
        {
            if (Id == 0)
            {
                return false;

            }
            return await _phoneBookDB.DeletePhoneBook(Id);
            
        }

        public async Task<IEnumerable<PhoneBookDTO>> Get()
        {
            return await _phoneBookDB.GetPhoneBooks();
        }

        public async Task<PhoneBookDTO> Get(int Id)
        {
            return await _phoneBookDB.GetPhoneBook(Id);
        }

        public async Task<bool> Insert(PhoneBookDTO phone)
        {
            if (!CheckContactData(phone))
            {
                return false;
            }
            return await _phoneBookDB.InsertPhoneBook(phone);
        }

        public async Task<bool> Update(PhoneBookDTO phoneBook)
        {
            if (!CheckContactData(phoneBook))
            {
                return false;
            }
            if (phoneBook.ID == 0)
            {
                return false;
            }
            return await _phoneBookDB.UpdatePhoneBook(phoneBook);
        }

        private bool CheckContactData(PhoneBookDTO phone)
        {
            if (string.IsNullOrEmpty(phone.FName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(phone.LName))
            {
                return false;
            }
            if (phone.PhoneNumber.Length != 11)
            {
                return false;
            }
            return true;
        }
    }
}
