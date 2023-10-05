namespace AcbaProject.Services.DatabaseServices.DeleteServices
{
    public interface IDeleteService
    {
        public bool IsDeleteUserData(string username);
        public bool IsGetUserIdUsedUserName(string username, out int userId);
        public bool IsDeleteContactDatas(int userid);
        public bool IsDeleteDocumentDatas(int userid);
    }
}
