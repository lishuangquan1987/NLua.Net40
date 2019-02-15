using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLua.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest test = new LoadAssemblyTest();
            test.Test();
        }
    }
}
