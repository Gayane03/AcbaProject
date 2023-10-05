using AcbaProject.Models.ForDatabaseModels;
using AcbaProject.Models.ForResponseModels;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace AcbaProject.Services.DatabaseServices.DQLCommandsServices
{
    public class SelectService : ISelectService
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private ResponseDataModel _model;
        private bool _answer;
        public SelectService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool IsSignInData(string username, string password, out string role)
        {
            role = null;
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand())
                {
                    _command.Connection = _connection;
                    _command.CommandText = $"SELECT Role FROM UserData WHERE UserName='{username}' AND Password='{password}'";
                    try
                    {
                        _reader = _command.ExecuteReader();
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                role = _reader["Role"].ToString();
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
        public bool IsFoundData(string firstname, string lastname, out List<ResponseDataModel> userDataModels)
        {
            Console.OutputEncoding = Encoding.UTF8;
            userDataModels = new List<ResponseDataModel>();
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand())
                {
                    _command.Connection = _connection;
                    _command.CommandText = $"SELECT u.FirstName firstname,u.LastName lastname,c.Email email,c.Phone phone FROM UserData u INNER JOIN Contacts c ON u.UserId=c.UserId WHERE u.FirstName LIKE N'{firstname}%' AND u.LastName LIKE N'{lastname}%'";
                    try
                    {
                        _reader = _command.ExecuteReader();
                        while (_reader.Read())
                        {
                            _model = new ResponseDataModel
                            {
                                FirstName = _reader["firstname"].ToString(),
                                LastName = _reader["lastname"].ToString(),
                                Email = _reader["email"].ToString(),
                                Phone = _reader["phone"].ToString()
                            };
                            userDataModels.Add(_model);
                            _answer = true;
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
        public bool IsFoundAllData(out List<ResponseDataModel> responseDataModel)
        {
            responseDataModel = new List<ResponseDataModel>();
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand())
                {
                    _command.Connection = _connection;
                    _command.CommandText = $"SELECT u.FirstName firstname,u.LastName lastname,c.Email email,c.Phone phone FROM UserData u INNER JOIN Contacts c ON u.UserId=c.UserId ";
                    try
                    {
                        _reader = _command.ExecuteReader();
                        while (_reader.Read())
                        {
                            _model = new ResponseDataModel
                            {
                                FirstName = _reader["firstname"].ToString(),
                                LastName = _reader["lastname"].ToString(),
                                Email = _reader["email"].ToString(),
                                Phone = _reader["phone"].ToString()
                            };
                            responseDataModel.Add(_model);
                        }
                        _answer = true;
                    }
                    finally
                    {
                        _reader.Close();
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
                    { _reader.Close(); }
                }
            }
            return _answer;
        }
        public bool IsGenderCounts(out DataGenderCounts genderCounts)
        {
            genderCounts = new DataGenderCounts();
            _answer = false;
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (_command = new SqlCommand())
                {
                    _command.Connection = _connection;
                    _command.CommandText = $"Select Count(N'իգական') female,count(N'արական') male from UserData Group by Gender;";
                    try
                    {
                        _reader = _command.ExecuteReader();
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                genderCounts.FemaleCount = Convert.ToInt32(_reader["female"].ToString());
                                genderCounts.MaleCount = Convert.ToInt32(_reader["male"].ToString());
                                _answer = true;
                            }
                        }
                    }
                    finally
                    { _reader.Close(); }
                }
            }
            return _answer;
        }
    }
}
