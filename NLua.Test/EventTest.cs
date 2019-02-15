using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLua.Test
{
    public class EventTest : ITest
    {
        public void Test()
        {
            using (var lua =new NLua.Lua())
            {
                lua.State.Encoding = Encoding.UTF8;
                lua.LoadCLRPackage();
                lua.DoString(@"
                import 'System.Windows.Forms';
                frm=Form();
                frm.Text='new form';

                frm.Load:Add(function(sender,e)
                    MessageBox.Show('窗体加载');
                end)
                frm:ShowDialog();
");
                Console.Read();
            }
        }
    }
}
