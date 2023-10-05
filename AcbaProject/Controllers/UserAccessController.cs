using AcbaProject.Model;
using AcbaProject.Models.ForModelFilldsChange;
using AcbaProject.Models.ForRequestModels;
using AcbaProject.Services.BuisnessServices.BSForDeletes;
using AcbaProject.Services.BuisnessServices.BSForInserts;
using AcbaProject.Services.BuisnessServices.BSForUpdates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcbaProject.Controllers
{
    [Route("useraccess")]
    [ApiController]
    [Authorize]
    public class UserAccessController : ControllerBase
    {
        private readonly IBSForUpdate _bsForUpdate;
        private readonly IBSForInsert _bsForInsert;
        private readonly IBSForDelete _bsForDelete;
        public UserAccessController(IBSForUpdate bsForUpdate, IBSForInsert bsForInsert, IBSForDelete bSForDelete)
        {
            _bsForUpdate = bsForUpdate;
            _bsForInsert = bsForInsert;
            _bsForDelete = bSForDelete;
        }

        [HttpPost("addcontacts")]     
        public JsonResult AddContacts(ContactsRequestModel contactsRequestModel)
        {
            var user = HttpContext.User;
            var userNameClaim = user.FindFirst("iat");
            return new JsonResult(_bsForInsert.AddContact(contactsRequestModel, userNameClaim.Value));
        }

        

        [HttpDelete("deleteuserdata")]
        public JsonResult DeleteUserData()
        {
            var user = HttpContext.User;
            var userNameClaim = user.FindFirst("iat");
            if (userNameClaim != null)
                return new JsonResult(_bsForDelete.DeleteUserData(userNameClaim.Value));

            return new JsonResult("Unauthorized");
        }

        [HttpPost("changepassword")]
        public JsonResult ChangePassword(ChangePasswordRequestModel passwordModel)
        {
            return new JsonResult(_bsForUpdate.ChangePassword(passwordModel));
        }

        [HttpPost("changeusername")]
        public JsonResult ChangeUserName(ChangeUserNameRequestModel userNameModel)
        {
            return new JsonResult(_bsForUpdate.ChangeUserName(userNameModel));
        }

    }
}
