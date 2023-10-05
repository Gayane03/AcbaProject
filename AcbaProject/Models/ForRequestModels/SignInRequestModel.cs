using System.ComponentModel.DataAnnotations;

namespace AcbaProject.Model
{
    public class SignInRequestModel
    {
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "UserName պետք է պարունակի միայն թվեր և լատինական տառեր։")]
        public string UserName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Գաղտնաբառը պետք է պարունակի միայն թվեր և լատինական տառեր։")]
        public string Password { get; set; }
    }
}
