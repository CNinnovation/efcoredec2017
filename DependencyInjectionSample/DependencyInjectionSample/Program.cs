using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run();
            ConfigureServices();
            RunWithDIContainer();
        }



        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IHelloService, HelloService>();
            services.AddTransient<HomeController>();
            ApplicationServices = services.BuildServiceProvider();
        }

        public static IServiceProvider ApplicationServices { get; set; }

        private static void RunWithDIContainer()
        {
            var controller = ApplicationServices.GetService<HomeController>();
            string message = controller.Greeting("Katharina");
            Console.WriteLine(message);
        }

        private static void Run()
        {
            IHelloService helloService = new HelloService();
            var controller = new HomeController(helloService);
            string message = controller.Greeting("Stephanie");
            Console.WriteLine(message);
        }
    }
}
