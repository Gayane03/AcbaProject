using AcbaProject.Model;
using AcbaProject.Models.ForModelFilldsChange;

namespace AcbaProject.Services.BuisnessServices.BSForUpdates
{
    public interface IBSForUpdate
    {
        public string ChangePassword(ChangePasswordRequestModel passwordModel);
        public string ChangeUserName(ChangeUserNameRequestModel emailModel);
    }
}
