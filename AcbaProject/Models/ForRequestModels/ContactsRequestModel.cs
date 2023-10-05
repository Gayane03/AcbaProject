using AcbaProject.Model;
using System.ComponentModel.DataAnnotations;

namespace AcbaProject.Models.ForRequestModels
{
    public class ContactsRequestModel
    {
        [RegularExpression(@"^[a-z][a-z0-9]*@(mail\.ru|gmail\.com)$", ErrorMessage = "Ուղղեք Ձեր mail-ի տվյալները,դրանք պետք լինեն լատինատառ և վերջանան @mail.ru  կամ @gmail.com:")]
        public string Email { get; set; }

        [RegularExpression(@"^\+374\d{8}$",ErrorMessage = "Խնդրում ենք հեռախոսահամարը ներմուծեք հետևյալ տեսքով։Օրինակ՝ +37411223344:")]
        public string Phone { get; set; }

    }
}
