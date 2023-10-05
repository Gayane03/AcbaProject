using AcbaProject.Model;
using AcbaProject.Models.ForRequestModels;
using AcbaProject.Models.ForResponseModels;
using AcbaProject.Services.BuisnessServices.BSForSelects;
using AcbaProject.Services.HelperServices;
using AcbaProject.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcbaProject.Controllers
{
    [Route("adminaccess")]
    [ApiController]
   [Authorize(Policy = "admin")]
    public class AdminAccessController : ControllerBase
    {
        private readonly IBSForSelect _bSForSelect;
        public AdminAccessController(IBSForSelect bSForSelect)
        {
           _bSForSelect = bSForSelect;  
        }

        [HttpPost("getdata")]     
        public JsonResult GetData(string name, string surname)
        {
            List<ResponseDataModel> result;
            _bSForSelect.SearchUserData(name, surname, out result);
            if(result==null)
               return new JsonResult(_bSForSelect.SearchUserData(name, surname,out result));
            
           return new JsonResult(result);   
        }

        [HttpPost("getalldata")]
        public JsonResult GetAllData()
        {
            if(_bSForSelect.SearchAllData()!=null)
            return new JsonResult(_bSForSelect.SearchAllData());

            throw new ExceptionNonDataService();
        }

        [HttpGet("getgendercount")]
        public JsonResult GetGenderCount()
        {
            return new JsonResult(_bSForSelect.GenderCounts());
        }

    }
}

