using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsweringMashine2.Core;

namespace AnsweringMashine
{
    class Program
    {
        static void Main(string[] args)
        {
            var mashine = new InMemoryAnsweringMachine();

            try
            {
                Console.WriteLine("Registering introuction with value ::introduction:: returns it.");
                var registeredIntro = mashine.AddIntroduction("::introduction::");
                if (registeredIntro.Value == "::introduction::") Console.WriteLine("Success!");
                else Console.WriteLine("Failure, value was " + registeredIntro.Value);
            }
            catch(Exception e)
            {
                Console.WriteLine("Threw exception: " + e.StackTrace);
            }
            
            
        }
    }
}
