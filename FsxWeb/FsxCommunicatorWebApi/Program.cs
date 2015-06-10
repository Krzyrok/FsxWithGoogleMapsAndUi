namespace FsxCommunicatorWebApi
{
    using System.Web.Http.SelfHost;
    using Application;

    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new HttpSelfHostConfiguration(Constants.Uri);
            WebApiConfig.Register(configuration);
            WebApiStarter.StartServer(configuration);
        }
    }
}
