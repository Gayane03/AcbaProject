using AcbaProject.Model;
using AcbaProject.Models.ForDatabaseModels;
using AcbaProject.Models.ForModelFilldsChange;
using AcbaProject.Services.DatabaseServices.DMLCommandsService.UpdateService;
using AcbaProject.Services.HelperServices;
using AcbaProject.Validations;

namespace AcbaProject.Services.BuisnessServices.BSForUpdates
{
    public class BSForUpdate:IBSForUpdate
    {
        private readonly IUpdateService _updateService;
        public BSForUpdate(IUpdateService updateService)
        {
            _updateService = updateService;
        }
        public string ChangePassword(ChangePasswordRequestModel passwordModel)
        {
            passwordModel.OldPassword = SecurityService.CalculateSHA256Hash(passwordModel.OldPassword);
            passwordModel.NewPassword = SecurityService.CalculateSHA256Hash(passwordModel.NewPassword);
            ChangePasswordData changeData=new ChangePasswordData
            {
                OldPassword= passwordModel.OldPassword,
                NewPassword= passwordModel.NewPassword  
            };

            if (_updateService.IsChangePassword(changeData.OldPassword, changeData.NewPassword))
                return "Փոփոխությունը կատարված է։";

            return "Կրկին փորձեք փոփոխել";
        }
        public string ChangeUserName(ChangeUserNameRequestModel userNameRequestModel)
        {
            ChangeUserNameData changeData = new ChangeUserNameData
            {
                OldUserName = userNameRequestModel.OldUserName,
                NewUserName = userNameRequestModel.NewUserName
            };
            if (_updateService.IsChangeUserName(changeData.OldUserName, changeData.NewUserName))
                return "Փոփոխությունը կատարված է։";

            return "Կրկին փորձեք փոփոխել";
        }
    }
}
