using AcbaProject.Model;
using System.Text;
using System.Text.RegularExpressions;
namespace AcbaProject.Validations
{
    public  class Validation
    {
        private static StringBuilder _validLine;
       
        public static string FirstName(string firstname)
        {
            if (!Regex.IsMatch(firstname, @"^[Ա-Ֆ][ա-ֆ]*$"))
                return "Խնդրում ենք անունը սկսեք մեծատառով";
            return null;
        }
        public static string LastName(string lastname)
        {
            if (!Regex.IsMatch(lastname, @"^[Ա-Ֆ][ա-ֆ]*$"))
                return "Խնդրում ենք ազգանունը սկսեք մեծատառով";
            else return null;
        }
        public static string Gender(string gender)
        {
            if (gender.ToLower()=="արական" || gender.ToLower()=="իգական")
                return null;
            return "Խնդրում ենք ներմուծել արական կամ իգական։";
        }
        
        private static string phoneNumber(string phone)
        {
            if (!Regex.IsMatch(phone, @"^\+374\d{8}$"))
                return "Խնդրում ենք հեռախոսահամարը ներմուծեք հետևյալ տեսքով։Օրինակ՝ +37411223344";
            return null;
        }
        public static string Email(string email)
        {
            if (!Regex.IsMatch(email, @"^[a-z][a-z0-9]*@(mail\.ru|gmail\.com)$"))
                return "Ուղղեք Ձեր mail-ի տվյալները,դրանք պետք լինեն լատինատառ և վերջանան @mail.ru  կամ @gmail.com";
            return null;
        }
        public static string ValidUserName(string username)
        {
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
                return "UserName-ը կարող է պարունակել միայն թվանշաններ և լատինական տառեր։";
            return null;
        }
        public static bool IsValidRequestModel(SignUpRequestUserModel model,ref string answerError)
        {
            _validLine = new StringBuilder();
           _validLine.Append(FirstName(model.FirstName));
            _validLine.Append(LastName(model.LastName));
            _validLine.Append(Gender(model.Gender));
         //   _validLine.Append(ssn(model.SSN));
            _validLine.Append(ValidUserName(model.Password));
           // _validLine.AppendLine(dateOfBirth(model.DateOfBirth.ToString()));

            if (_validLine.Length > 0)
            {
                answerError = _validLine.ToString();
                return false;
            }
            return true;
        }
        public static bool IsValidLogin(string mail, string pass, ref string answerError)
        {
            _validLine = new StringBuilder();
            _validLine.Append(Email(mail));
            _validLine.Append(ValidUserName(pass));

            if (_validLine.Length > 0)
            {
                answerError = _validLine.ToString();
                return false;
            }
            return true;
        }
    }
}
