using AcbaProject.Model;
using AcbaProject.Models.ForDatabaseModels;

namespace AcbaProject.Services.DatabaseServices.DMLCommandsService.InsertServices
{
    public interface IInsertService
    {
        public bool IsSignUpUserData(UserDataModel clientData);
        public bool IsAddContactsData(ContactsDataModel contactsDataModel);
        public bool IsAddDocumentData(DocumentsDataModel documentsDataMmodel);
    }
}
