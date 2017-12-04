using System;

namespace YieldSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 1, 4, 5, 42 };
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            var enumerator = data.GetEnumerator();
            while (enumerator.MoveNext())
            {
                int item = (int)enumerator.Current;
                Console.WriteLine(item);
            }

            var helloWorld = new HelloWorld();
            foreach (string s in helloWorld)
            {
                Console.WriteLine(s);
            }
        }
    }
}
