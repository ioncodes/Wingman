using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingman
{
    class Program
    {
        static void Main(string[] args)
        {
            var wingman = new Wingman(args[0]);
            if (wingman.CheckConfig())
            {
                wingman.LoadPlugins();
                wingman.ParseConfig();
                wingman.Execute();
            }
            else
            {
                Console.WriteLine("Config not valid!");
            }
            Console.ReadLine();
        }
    }
}
