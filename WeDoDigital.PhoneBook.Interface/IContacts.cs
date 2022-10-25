using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeDoDigital.PhoneBook.DTO;

namespace WeDoDigital.PhoneBook.Interface
{
    public interface IContacts
    {
        Task<bool> Delete(int Id);
        Task<bool> Update(PhoneBookDTO phoneBook);
        Task<bool> Insert(PhoneBookDTO phone);
        Task<IEnumerable<PhoneBookDTO>> Get();
        Task<PhoneBookDTO> Get(int Id);
    }
}
