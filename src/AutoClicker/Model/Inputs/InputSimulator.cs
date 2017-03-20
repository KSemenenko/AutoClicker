using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoClicker.Inputs
{
    class InputSimulator : IInputSimulator
    {
        //https://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx
        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        private const int MOUSEEVENTF_RIGHTUP = 0x0010; /* right button UP */

        [DllImport("user32")]
        private static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public void MouseLeftButtonClick(int x, int y)
        {
            MoveMouseTo(x, y);

            Thread.Sleep(100);

            MouseLeftButtonDown();
            MouseLeftButtonUp();
        }

        public void MouseLeftButtonDoubleClick(int x, int y)
        {
            MoveMouseTo(x, y);

            Thread.Sleep(100);

            MouseLeftButtonDown();
            MouseLeftButtonUp();
            MouseLeftButtonDown();
            MouseLeftButtonUp();
        }

        public void MoveMouseTo(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public void MouseLeftButtonDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        public void MouseLeftButtonUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void TypeText(string text)
        {
            throw new NotImplementedException();
        }
    }
}