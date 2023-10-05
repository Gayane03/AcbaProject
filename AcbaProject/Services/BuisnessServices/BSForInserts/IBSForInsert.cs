using AcbaProject.Model;
using AcbaProject.Models.ForRequestModels;
using AcbaProject.Validations;

namespace AcbaProject.Services.BuisnessServices.BSForInserts
{
    public interface IBSForInsert
    {
        public string AddClientData(SignUpRequestUserModel requestModel);
        public string AddAdminData(SignUpRequestUserModel requestModel);
        public string AddContact(ContactsRequestModel contactsRequestModel,string username);
        public string AddDocument(DocumentsRequestModel documentsRequestModel,string username);
    }
}
