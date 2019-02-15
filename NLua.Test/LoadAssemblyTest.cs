using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLua.Test
{
    class LoadAssemblyTest : ITest
    {
        public void Test()
        {
            using (var lua = new NLua.Lua())
            {
                lua.LoadCLRPackage();
                lua.DoString("luanet.load_assembly('mscorlib')");
                lua.DoString("luanet.load_assembly('System.Windows.Forms')");
                lua.DoString("a=luanet.import_type('System.Window.Forms.MessageBox')");
                lua.DoString("a.Show('lua')");
                Console.Read();
            }
        }
    }
}
