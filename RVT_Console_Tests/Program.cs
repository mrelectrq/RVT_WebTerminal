using RVT_Block_lib;
using System;

namespace RVT_Console_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var chooser = new Chooser();
            chooser.Name = "Ionas";
            chooser.Surname = "Cristian";
            chooser.Region = 1;
            chooser.IDNP = 123453425;
            chooser.UserName = "Sosi";
            Chain chain = new Chain();
            chain.Add(chooser);

            Console.WriteLine("Hello World!");
        }
    }
}
