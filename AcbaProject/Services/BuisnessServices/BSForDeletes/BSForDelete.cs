using AcbaProject.Services.DatabaseServices.DeleteServices;
using AcbaProject.Validations;

namespace AcbaProject.Services.BuisnessServices.BSForDeletes
{
    public class BSForDelete:IBSForDelete
    {
        private readonly IDeleteService _deleteService; 
        public BSForDelete(IDeleteService deleteService)
        {
                _deleteService = deleteService;
        }
    
        public string DeleteUserData(string username)
        {
            if (Validation.ValidUserName(username) is not null)
                return Validation.ValidUserName(username);

            if (_deleteService.IsDeleteUserData(username))
                return "Տվյալները հեռացվեցին";

            return "Խնդրում ենք կրկին փորձել։";
        }
      
    }
}
