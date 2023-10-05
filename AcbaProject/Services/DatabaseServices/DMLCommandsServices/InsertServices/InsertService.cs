using AcbaProject.Model;
using AcbaProject.Models.ForDatabaseModels;
using AcbaProject.Models.ForResponseModels;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Transactions;
using System.Windows.Input;

namespace AcbaProject.Services.DatabaseServices.DMLCommandsService.InsertServices
{
    public class InsertService : IInsertService
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlTransaction _transaction;

        private bool _answer;
        public InsertService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool IsSignUpUserData(UserDataModel userData)
        {
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
                using (_command = new SqlCommand())
                {
                    _command.Transaction = _transaction;
                    _command.Connection = _connection;
                    _command.CommandText = "INSERT INTO UserData VALUES(@UserName,@FirstName,@LastName,@Gender,@Password,@Role)";
                    _command.Parameters.AddWithValue("@UserName", userData.UserName);
                    _command.Parameters.AddWithValue("@FirstName", userData.FirstName);
                    _command.Parameters.AddWithValue("@LastName", userData.LastName);                
                    _command.Parameters.AddWithValue("@Gender", userData.Gender);
                    _command.Parameters.AddWithValue("@Password", userData.Password);
                    _command.Parameters.AddWithValue("@Role", userData.Role);

                    try
                    {
                        _command.ExecuteNonQuery();
                        _transaction.Commit();
                        _answer = true;
                    }
                    catch (SqlException ex)
                    {
                        _transaction.Rollback();
                    }
                }
            }
            return _answer;
        }
        public bool IsGetUserId(string ssn, out int id)
        {
            id = 0;
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand())
                {
                    _command.Connection = _connection;
                    _command.CommandText = $"SELECT UserId FROM UserData WHERE SSN='{ssn}'";
                    SqlDataReader reader = _command.ExecuteReader();
                    try
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["UserId"].ToString());
                                id = Convert.ToInt32(reader["UserId"].ToString());
                                _answer = true;
                            }
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }                
                }
            }
            return _answer;
        }      
        public bool IsAddContactsData(ContactsDataModel contactsDataModel)
        { 
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
                using (_command = new SqlCommand())
                {
                    _command.Transaction = _transaction;
                    _command.Connection = _connection;
                    _command.CommandText = "INSERT INTO Contacts VALUES(@UserId,@Email,@Phone)";
                    _command.Parameters.AddWithValue("@UserId", contactsDataModel.UserId);
                    _command.Parameters.AddWithValue("@Email", contactsDataModel.Email);
                    _command.Parameters.AddWithValue("@Phone", contactsDataModel.Phone);

                    try
                    {
                        _command.ExecuteNonQuery();
                        _transaction.Commit();
                        _answer = true;
                    }
                    catch (SqlException ex)
                    {
                        _transaction.Rollback();
                    }
                }
            }
            return _answer;
        }

        public bool IsAddDocumentData(DocumentsDataModel documentsDataMmodel)
        {
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
                using (_command = new SqlCommand())
                {
                    _command.Transaction = _transaction;
                    _command.Connection = _connection;
                    _command.CommandText = "INSERT INTO Documents VALUES(@UserId,@PassportId)";
                    _command.Parameters.AddWithValue("@UserId", documentsDataMmodel.UserId);
                    _command.Parameters.AddWithValue("@PassportId", documentsDataMmodel.PassportId);

                    try
                    {
                        _command.ExecuteNonQuery();
                        _transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        _transaction.Rollback();
                    }
                }
            }
            return _answer;
        }
    }
}
