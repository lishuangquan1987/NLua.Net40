using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLua.Test
{
    class ref_Test : ITest
    {
        public void Test()
        {
            using (var lua = new NLua.Lua())
            {
                lua.LoadCLRPackage();
                lua.RegisterFunction("Calc", null, typeof(ref_Test).GetMethod("Calc"));
                lua.DoString("a=1;b=2;c=3;d=4;e=nil;");
                lua.DoString("result,c,d,e=Calc(a,b,c,d,e)");
                double a = (double)lua["a"];
                double b = (double)lua["b"];
                double c = (double)lua["c"];
                double d = (double)lua["d"];
                string e = (string)lua["e"];
                lua.DoString("print('this is from lua print')");
                Console.WriteLine("a:{0},b:{1},c:{2},d:{3},e:{4}", a, b, c, d, e);
                Console.WriteLine(lua["result"]);
                Console.Read();
            }
           
        }
        public static int Calc(int a, int b, ref double c, ref double d, ref string e)
        {
            a = 11;
            b = 12;
            c = 13;
            d = 14;
            e = "this is a string changed by Calc function";
            return a + b;
        }
    }
}
