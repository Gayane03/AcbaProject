using AcbaProject.Model;
using AcbaProject.Models.ForDatabaseModels;
using AcbaProject.Models.ForRequestModels;
using AcbaProject.Models.ForResponseModels;
using AcbaProject.Services.DatabaseServices.DQLCommandsServices;
using AcbaProject.Services.HelperServices;
using AcbaProject.Validations;

namespace AcbaProject.Services.BuisnessServices.BSForSelects
{
    public class BSForSelect : IBSForSelect
    {
        private readonly ISelectService _selectService;
        private List<ResponseDataModel> _responseModels;
        private string _role;
        public BSForSelect(ISelectService selectService)
        {
            _selectService = selectService;
        }
        public string SignInUserData(string username, string password, IJwtService _jwtService)
        {
            if (_selectService.IsSignInData(username, SecurityService.CalculateSHA256Hash(password), out _role))
                return _jwtService.GenerateToken(username, _role);
            return "Նման տվյալներով մարդ համակարգում գույություն չունի։";
        }

        public string SearchUserData(string name, string surname,out List<ResponseDataModel> responseDataModels)
        {
            
            if (_selectService.IsFoundData(name, surname, out _responseModels))
            {
                responseDataModels = _responseModels;
                return "Տվյալները գտնված են։";
            }
            responseDataModels= _responseModels ;
            return "Տվյալները գտնավծ չեն։";
        }
        public List<ResponseDataModel> SearchAllData()
        {
            if (_selectService.IsFoundAllData(out _responseModels))
                return _responseModels;
            return null;
        }
        public string ReturnUserId(string email, out int userId)
        {
            if (_selectService.IsGetUserIdUsedUserName(email, out userId))
                return null;
            return "Կատարվում են կարգավորումներ;";
        }

        public ResponseGenderCounts GenderCounts()
        {
            ResponseGenderCounts responseGenderCounts;
            DataGenderCounts genderCounts = new();
            if (!_selectService.IsGenderCounts(out genderCounts))
                return null;

            responseGenderCounts = new ResponseGenderCounts
            {
                MaleCount = genderCounts.MaleCount,
                FemaleCount = genderCounts.FemaleCount,
            };
            return responseGenderCounts;

        }    
    }
}