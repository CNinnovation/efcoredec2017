using System;
using System.Collections.Generic;
using System.Text;

namespace YieldSample
{
    public class HelloWorld
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Hello";
            yield return "World";
        }
    }
}
