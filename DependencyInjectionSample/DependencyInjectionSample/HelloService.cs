using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionSample
{
    public class HelloService : IHelloService
    {
        public HelloService()
        {

        }

        public string Hello(string name) => $"Hello, {name}";
    }
}
