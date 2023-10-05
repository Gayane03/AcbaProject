using AcbaProject.Model;
using AcbaProject.Models.ForDatabaseModels;
using AcbaProject.Models.ForRequestModels;
using AcbaProject.Services.DatabaseServices.DMLCommandsService.InsertServices;
using AcbaProject.Services.DatabaseServices.DQLCommandsServices;
using AcbaProject.Services.HelperServices;

namespace AcbaProject.Services.BuisnessServices.BSForInserts
{
    public class BSForInsert : IBSForInsert
    {
        private readonly IInsertService _insertService;
        private readonly ISelectService _selectService;
        private string _answerError;
        public BSForInsert(IInsertService insertService, ISelectService selectionService)
        {
            _selectService = selectionService;
            _insertService = insertService;
        }
        
        public string AddClientData(SignUpRequestUserModel requestModel)
        {
            //if (!Validation.IsValidRequestModel(requestModel, ref _answerError))
            //    return _answerError;

            requestModel.Password = SecurityService.CalculateSHA256Hash(requestModel.Password);
            UserDataModel dbModel = new UserDataModel
            {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                UserName = requestModel.UserName,
                Gender = requestModel.Gender,
                Password = requestModel.Password,
                Role = "client"
            };

            if (_insertService.IsSignUpUserData(dbModel))
                return "Շնորհակալություն Դուք գրանվեցիք";
            else
                return "Դուք ունեք սխալ մուտքագրած տվյալ։Խնդրում ենք ստուգեք անձնագրի և սոցիալական քարտի տվյալները";
        }
        public string AddAdminData(SignUpRequestUserModel requestModel)
        {
            requestModel.Password = SecurityService.CalculateSHA256Hash(requestModel.Password);
            UserDataModel dbModel = new UserDataModel
            {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                UserName = requestModel.UserName,
                Gender = requestModel.Gender,
                Password = requestModel.Password,
                Role = "admin"
            };

            if (_insertService.IsSignUpUserData(dbModel))
                return "Շնորհակալություն Դուք գրանվեցիք";

            return "Դուք ունեք սխալ մուտքագրած տվյալ։Խնդրում ենք ստուգեք անձնագրի և սոցիալական քարտի տվյալները";
        }

        public string AddContact(ContactsRequestModel contactsRequestModel, string username)
        {
            if (username == null)
                return "կրկին փորձեք։";

            int userid;
            if (!_selectService.IsGetUserIdUsedUserName(username, out userid))
                return "կրկին փորձեք։";

            ContactsDataModel contactsData = new ContactsDataModel
            {
                UserId = userid,
                Email = contactsRequestModel.Email,
                Phone = contactsRequestModel.Phone,
            };

            if (_insertService.IsAddContactsData(contactsData))
                return "Շնորհակալություն Դուք գրանվեցիք";

            return "Դուք ունեք սխալ մուտքագրած տվյալ։Խնդրում ենք ստուգեք անձնագրի և սոցիալական քարտի տվյալները";
        }

        public string AddDocument(DocumentsRequestModel documentsRequestModel, string username)
        {
            if (username == null)
                return "կրկին փորձեք։";

            int userid;
            if (!_selectService.IsGetUserIdUsedUserName(username, out userid))
                return "կրկին փորձեք։";

            DocumentsDataModel documentsData = new DocumentsDataModel
            {
                UserId = userid,
                PassportId = documentsRequestModel.PassportId, 
            };

            if (_insertService.IsAddDocumentData(documentsData))
                return "Շնորհակալություն Դուք գրանվեցիք";

            return "Դուք ունեք սխալ մուտքագրած տվյալ։Խնդրում ենք ստուգեք անձնագրի և սոցիալական քարտի տվյալները";
        }
    }
}
