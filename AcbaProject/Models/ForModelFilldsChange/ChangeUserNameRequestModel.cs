using System.ComponentModel.DataAnnotations;

namespace AcbaProject.Models.ForModelFilldsChange
{
    public class ChangeUserNameRequestModel
    {
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "UserName պետք է պարունակի միայն թվեր և լատինական տառեր։")]
        public string OldUserName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "UserName պետք է պարունակի միայն թվեր և լատինական տառեր։")]
        public string NewUserName { get; set; }
    }
}
