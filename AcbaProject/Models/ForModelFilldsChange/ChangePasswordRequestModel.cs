using System.ComponentModel.DataAnnotations;

namespace AcbaProject.Model
{
    public class ChangePasswordRequestModel
    {
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Գաղտնաբառը պետք է պարունակի միայն թվեր և լատինական տառեր։")]
        public string OldPassword { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Գաղտնաբառը պետք է պարունակի միայն թվեր և լատինական տառեր։")]
        public string NewPassword { get; set; } 
    }
}
