using Microsoft.Data.SqlClient;

namespace AcbaProject.Services.DatabaseServices.DeleteServices
{
    public class DeleteService : IDeleteService
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlTransaction _transaction;
        private SqlDataReader _reader;
        private bool _answer;
        
        public DeleteService(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public bool IsDeleteUserData(string username)
        {
            int userId;
            _answer = false;
            if (IsGetUserIdUsedUserName(username,out userId))
            {
                if (IsDeleteDocumentDatas(userId) && IsDeleteContactDatas(userId))
                {          
                    using (_connection = new SqlConnection(_connectionString))
                    {
                        _connection.Open();
                        _transaction = _connection.BeginTransaction();
                        
                        using (_command = new SqlCommand())
                        {
                            _command.Connection = _connection;
                            _command.Transaction = _transaction;
                            try
                            {
                                _command.CommandText = $"DELETE FROM UserData WHERE UserId = {userId}";
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
                }
            }
            return _answer;
        }
        public bool IsDeleteDocumentDatas(int userid)
        {
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
                using (_command = new SqlCommand())
                {
                    _command.Connection = _connection;
                    _command.Transaction = _transaction; 
                    try
                    {
                        _command.CommandText = $"DELETE FROM Documents WHERE UserId = {userid}";
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
        public bool IsDeleteContactDatas(int userid)
        {
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
                using (_command = new SqlCommand())
                {
                    _command.Connection = _connection;
                    _command.Transaction = _transaction;
                    try
                    {
                        _command.CommandText = $"DELETE FROM Contacts WHERE UserId = {userid}";
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
        public bool IsGetUserIdUsedUserName(string username, out int userId)
        {
            userId = 0;
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand())
                {
                    _command.Connection = _connection;
                    _command.CommandText = $"SELECT UserId FROM UserData WHERE UserName='{username}'";                  
                    try
                    {
                        _reader = _command.ExecuteReader();
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                userId = Convert.ToInt32(_reader["UserId"].ToString());
                                _answer = true;
                            }
                        }
                    }
                    finally
                    {
                        _reader.Close();
                    }
                }
            }
            return _answer;
        }
    }
}
