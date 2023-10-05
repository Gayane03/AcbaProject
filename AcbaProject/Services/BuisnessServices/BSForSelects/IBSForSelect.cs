using AcbaProject.Models.ForDatabaseModels;
using AcbaProject.Models.ForResponseModels;
using AcbaProject.Validations;

namespace AcbaProject.Services.BuisnessServices.BSForSelects
{
    public interface IBSForSelect
    {
        public List<ResponseDataModel> SearchAllData();

        public string SignInUserData(string username, string password, IJwtService _jwtService);

        public string SearchUserData(string name, string surname, out List<ResponseDataModel> responseDataModels);
        public string ReturnUserId(string email, out int userid);
        public ResponseGenderCounts GenderCounts();

    }
}
