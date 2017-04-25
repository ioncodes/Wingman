using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingman.Plugin
{
    public interface IPlugin
    {
        string Name { get; }
        string[] Keys { get; }
        (string, string) GetData(string key);
    }
}
