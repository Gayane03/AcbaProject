using AcbaProject.Model;
using AcbaProject.Services.BuisnessServices.BSForInserts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcbaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IBSForInsert _bsForInsert;
        public SignUpController(IBSForInsert bsForInsert)
        {
            _bsForInsert = bsForInsert;
        }

        [HttpPost("signupforclient")]
        public JsonResult SignUpClient(SignUpRequestUserModel requestClientModel)
        {
            return new JsonResult(_bsForInsert.AddClientData(requestClientModel));
        }

        [HttpPost("signupforadmin")]
        public JsonResult SignUpAdmin(SignUpRequestUserModel requestClientModel)
        {
            return new JsonResult(_bsForInsert.AddAdminData(requestClientModel));
        }
    }
}
