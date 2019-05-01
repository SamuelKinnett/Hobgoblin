using System;
using Hobgoblin;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Hob hob = new Hob(800, 600);
            hob.Scenes.AddScene("MAIN", new TestScene());
            hob.Initialise();
            hob.Run();
        }
    }
}
