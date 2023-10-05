namespace AcbaProject.Services.HelperServices
{
    public class ExceptionNonDataService:Exception
    {
        public override string Message => "Տվյալները բացակայում են։";
    }
}
