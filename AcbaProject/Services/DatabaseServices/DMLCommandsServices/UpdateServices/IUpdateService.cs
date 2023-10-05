namespace AcbaProject.Services.DatabaseServices.DMLCommandsService.UpdateService
{
    public interface IUpdateService
    {
        public bool IsChangePassword(string oldpassword, string newpassword);
        public bool IsChangeUserName(string oldUserName,string newUserName);

    }
}
