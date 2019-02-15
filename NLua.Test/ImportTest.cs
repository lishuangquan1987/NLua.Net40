using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLua.Test
{
    public class ImportTest : ITest
    {
        public void Test()
        {
            using (NLua.Lua lua = new Lua())
            {
                lua.State.Encoding = Encoding.UTF8;
                lua.LoadCLRPackage();
                lua.DoString("import 'System.Windows.Forms'");
                lua.DoString("form=Form();form.Text='lua脚本';form:ShowDialog()");
                lua.DoString("MessageBox.Show('lua脚本')");
                Console.Read();
            }
        }
    }
}
