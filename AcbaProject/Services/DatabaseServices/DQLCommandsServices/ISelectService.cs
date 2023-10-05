using AcbaProject.Models.ForDatabaseModels;
using AcbaProject.Models.ForResponseModels;

namespace AcbaProject.Services.DatabaseServices.DQLCommandsServices
{
    public interface ISelectService
    {
        public bool IsSignInData(string username, string password, out string role);
        public bool IsFoundData(string firstname, string lastname, out List<ResponseDataModel> responseDataModels);
        public bool IsFoundAllData(out List<ResponseDataModel> responseDataModel);
        public bool IsGetUserIdUsedUserName(string username, out int userid);
        public bool IsGenderCounts(out DataGenderCounts genderCounts);
    }
}
