using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLua.Test
{

    public class Out_Test : ITest
    {
        public void Test()
        {
            using (var lua = new NLua.Lua())
            {
                lua.LoadCLRPackage();
                lua.RegisterFunction("Calc",null,typeof(Out_Test).GetMethod("Calc"));
                lua.DoString("a,b,c,e=Calc(10,2)");
                double a = (double)lua["a"];
                double b = (double)lua["b"];
                double c = (double)lua["c"];
                string e = (string)lua["e"];
                lua.DoString("print('this is from lua print')");
                Console.WriteLine("a:{0},b:{1},c:{2},e:{3}",a,b,c,e);
                Console.Read();
            }
        }
        public static int Calc(int a, int b,out double c,out double d,out string e)
        {
            e = "lua return";
            c = a * b;
            d = a - b;
            return a + b;
        }
    }
}
