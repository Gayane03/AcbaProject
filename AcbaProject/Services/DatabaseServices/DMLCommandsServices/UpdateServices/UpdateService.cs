using AcbaProject.Model;
using AcbaProject.Services.DatabaseServices.DMLCommandsService.UpdateService;
using Microsoft.Data.SqlClient;
namespace AcbaProject.Services.DatabaseServices.DMLCommandsService.UpdateServices
{
    public class UpdateService : IUpdateService
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlTransaction _transaction;   
        private bool _answer;
        public UpdateService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool IsChangeUserName(string oldUserName, string newUserName)
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
                    _command.CommandText = $"UPDATE UserData SET UserName='{newUserName}' WHERE UserName='{oldUserName}'";
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
        public bool IsChangePassword(string oldpassword, string newpassword)
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
                    _command.CommandText = $"UPDATE UserData SET Password='{newpassword}' WHERE Password='{oldpassword}'";
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
    }
}
