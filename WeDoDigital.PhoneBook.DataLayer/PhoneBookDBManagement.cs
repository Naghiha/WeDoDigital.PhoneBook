using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WeDoDigital.PhoneBook.DTO;
using WeDoDigital.PhoneBook.Interface;

namespace WeDoDigital.PhoneBook.DataLayer
{
    public class PhoneBookDBManagement : IPhoneBookDBManagement
    {
        private readonly string _connectionString;

        public PhoneBookDBManagement(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public async Task<IEnumerable<PhoneBookDTO>> GetPhoneBooks()
        {
            try
            {
                using (SqlConnection sqlConnection=new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Contacts";
                    return await sqlConnection.QueryAsync<PhoneBookDTO>(query, commandType: System.Data.CommandType.Text);

                }
            }
            catch (Exception e)
            {

                throw new Exception("Error while selecting Contacts" + e.Message);
            }
        }
        public async Task<PhoneBookDTO> GetPhoneBook(int Id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Contacts WHERE ID = @Id";
                    var param = new { Id = Id };
                    return await sqlConnection.QuerySingleAsync<PhoneBookDTO>(query, param, commandType: System.Data.CommandType.Text);

                }
            }
            catch (Exception e)
            {

                throw new Exception("Error while selecting Contacts" + e.Message);
            }
        }

        public async Task<bool> InsertPhoneBook(PhoneBookDTO phone)
        {
            try
            {
                string query = "SpInsertContacts";
                var Params = new
                {
                    Fname = phone.FName,
                    LName = phone.LName,
                    PhoneNumber = phone.PhoneNumber
                };
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    await sqlConnection.QueryAsync<PhoneBookDTO>(query, Params, commandType: System.Data.CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
                //LogError("Error while inserting a new PhoneBook" + e.Message);
            }
        }

        public async Task<bool> UpdatePhoneBook(PhoneBookDTO phoneBook)
        {
            try
            {
                string query = "SpUpdateContacts";
                var Params = new
                {
                    Fname = phoneBook.FName,
                    LName = phoneBook.LName,
                    PhoneNumber = phoneBook.PhoneNumber,
                    ContactID = phoneBook.ID
                };
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    await sqlConnection.QueryAsync<PhoneBookDTO>(query, Params, commandType: System.Data.CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
                //LogError("Error while Updating a new PhoneBook" + e.Message);
            }
        }
        public async Task<bool> DeletePhoneBook(int Id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Contacts WHERE ID = @ID";
                    var parameters =new { ID = Id };
                     await sqlConnection.QueryAsync<PhoneBookDTO>(query,parameters, commandType: System.Data.CommandType.Text);

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
                //LogError("Error while Deteting PhoneBooks" + e.Message);
            }
        }
    }
}
