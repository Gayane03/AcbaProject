using System.ComponentModel.DataAnnotations;

namespace AcbaProject.Models.ForRequestModels
{
    public class DocumentsRequestModel
    {

        [RegularExpression(@"^[a-zA-Z0-9]+$",ErrorMessage = "Գաղտնաբառը կարող է պարունակել միայն թվանշաններ և լատինական տառեր")]
        public string PassportId { get; set; }  
    }
}
