using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HomeController
    {
        private readonly IHelloService _helloService;
        public HomeController(IHelloService helloService)
        {
            _helloService = helloService;
        }

        public string Greeting(string name)
        {
            //var service = new HelloService();
            //return service.Hello(name);
            return _helloService.Hello(name);
        }
    }
}
