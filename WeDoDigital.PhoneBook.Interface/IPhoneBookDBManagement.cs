using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeDoDigital.PhoneBook.DTO;

namespace WeDoDigital.PhoneBook.Interface
{
    public interface IPhoneBookDBManagement
    {
        Task<bool> DeletePhoneBook(int Id);
        Task<bool> UpdatePhoneBook(PhoneBookDTO phoneBook);
        Task<bool> InsertPhoneBook(PhoneBookDTO phone);
        Task<IEnumerable<PhoneBookDTO>> GetPhoneBooks();
        Task<PhoneBookDTO> GetPhoneBook(int Id);
    }
}
