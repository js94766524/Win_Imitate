using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImitateLib
{
    public static class Keyboard
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public static void Press(params Keys[] inputs)
        {
            foreach (Keys key in inputs)
            {
                keybd_event(key, 0, 0, 0);
            }
        }

        public static void Ctrl(params Keys[] keys)
        {
            keybd_event(Keys.ControlKey, 0, 0, 0);
            Press(keys);
            keybd_event(Keys.ControlKey, 0, 2, 0);
        }

        public static void Alt(params Keys[] keys)
        {
            keybd_event(Keys.Alt, 0, 0, 0);
            Press(keys);
            keybd_event(Keys.Alt, 0, 2, 0);
        }

        public static void Shift(params Keys[] keys)
        {
            keybd_event(Keys.ShiftKey, 0, 0, 0);
            Press(keys);
            keybd_event(Keys.ShiftKey, 0, 2, 0);
        }

        public static void InputByClipboard(string data)
        {
            Clipboard.SetDataObject(data,false);
            Ctrl(Keys.V);
        }
    }
}
