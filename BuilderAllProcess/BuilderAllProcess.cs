using Microsoft.AspNetCore.Builder;

namespace BuilderAllProcess
{
    public class BuilderAllProcess
    {
        public static void AddAllServices(WebApplicationBuilder build)
        {
            AddControllers(build);
            AddEndpointsApiExplorer(build);
            AddSwagerUI(build);
            BuilderAuthoServices.AddScopedAuthenticationServices(build);  
            BuilderAuthoServices.AddScopedAuthorizationServices(build);   
            BuilderLocalServices.AddScopedAllBuisnessServices(build);
            BuilderLocalServices.AddScopedAllDatebaseServices(build);
            AddSingletonConnection(build);
        }
    }
}