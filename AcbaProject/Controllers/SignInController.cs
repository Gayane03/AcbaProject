using AcbaProject.Model;
using AcbaProject.Services.BuisnessServices.BSForSelects;
using AcbaProject.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcbaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IBSForSelect _bsForSelect;
        public SignInController(IJwtService jwtService, IBSForSelect bSForSelect)
        {
           _bsForSelect = bSForSelect;
            _jwtService = jwtService;
        }

        [HttpPost("signin")]
        public JsonResult SignIn(SignInRequestModel model)
        {
            return new JsonResult(_bsForSelect.SignInUserData(model.UserName, model.Password, _jwtService));
        }
    }
}
