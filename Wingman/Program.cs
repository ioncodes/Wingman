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
                string resp = wingman.Execute();
                var validations = wingman.Validate(resp);
                Console.WriteLine("Validation report:\n");
                foreach (var validation in validations)
                {
                    Console.WriteLine($"Type:   {validation.Item1}\n" +
                                      $"Value:  {validation.Item2}\n" +
                                      $"Result: {validation.Item3}\n");
                }
            }
            else
            {
                Console.WriteLine("Config not valid!");
            }
            Console.ReadLine();
        }
    }
}
