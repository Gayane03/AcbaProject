namespace AcbaProject.BuilderAllProcess
{
    public static class BuilderAllProcess
    {
        public static void AddAllServices(WebApplicationBuilder build)
        {
            BuilderUIServices.AddScopedControllersServices(build);
            BuilderUIServices.AddScopedEndpointsApiExplorerServices(build);
            BuilderUIServices.AddScopedSwagerUIServices(build);
            BuilderAuthoServices.AddScopedAuthenticationServices(build);
            BuilderAuthoServices.AddScopedAuthorizationServices(build);
            BuilderLocalServices.AddScopedAllBuisnessServices(build);
            BuilderLocalServices.AddScopedAllDatebaseServices(build);
            BuilderLocalServices.AddScopedSingletonConnection(build);
        }
    }
}