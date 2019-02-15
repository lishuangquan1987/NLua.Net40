using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLua.Test
{
    class ImportTest1 : ITest
    {
        public void Test()
        {
            using (var lua = new NLua.Lua())
            {
                lua.State.Encoding = Encoding.Default;
                lua.LoadCLRPackage();
                #region 方式一

                //lua.DoString("import 'System.Windows.Forms'");

                //lua.DoString("MessageBox.Show('lua脚本')");
                #endregion

                #region 方式二
                //lua.DoString("System={}");
                //lua.DoString("System.Windows={}");
                //lua.DoString("System.Windows.Forms=import 'System.Windows.Forms'");
                //lua.DoString("System.Windows.Forms.MessageBox.Show('lua脚本','提示')");
                #endregion

                #region 方式三
               
                lua.DoString("package.path=package.path..';'..'./Script/?.lua'");
                lua.DoString("json= require 'json'");
                lua.DoString("System={}");

               

                lua.DoString("System.Windows={}");
                lua.DoString("System.Windows.Forms=import 'System.Windows.Forms'");
                lua.DoString("print(json.encode(System))");
                LuaTable table = lua["_G"] as LuaTable;
                lua.DoString("System.Windows.Forms.MessageBox.Show('lua脚本','提示')");
                #endregion

                Console.Read();
            }
        }
    }
}
