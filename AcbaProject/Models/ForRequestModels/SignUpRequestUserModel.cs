
using System.ComponentModel.DataAnnotations;

namespace AcbaProject.Model
{
    public class SignUpRequestUserModel
    {
        [RegularExpression(@"^[Ա-Ֆ][ա-ֆ]*$", ErrorMessage = "Խնրում ենք անունը սկսեք մեծատառով։")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[Ա-Ֆ][ա-ֆ]*$", ErrorMessage = "Խնրում ենք ազգանունը սկսեք մեծատառով։")]
        public string LastName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "UserName պետք է պարունակի միայն թվեր և լատինական տառեր։")]
        public string UserName { get; set; }    

        [RegularExpression(@"իգական|արական", ErrorMessage = "Խնրում ենք ներմուծեք իգական կամ արական։")]
        public string Gender { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Գաղտնաբառը պետք է պարունակի միայն թվեր և լատինական տառեր։")]
        public string Password { get; set; }
 
    }
}
