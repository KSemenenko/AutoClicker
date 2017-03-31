using System;
using System.Runtime.InteropServices;
using System.Threading;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.Inputs
{
    internal class InputSimulator : IInputSimulator
    {
        //https://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx
        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        private const int MOUSEEVENTF_RIGHTUP = 0x0010; /* right button UP */
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; /* right button UP */
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040; /* right button UP */
        

        public void MouseButtonClick(MuseKey key, uint count = 1)
        {
            Thread.Sleep(100);
            while(true)
            {
                MouseButtonDown(key);
                MouseButtonUp(key);
                count--;
            }
        
        }

      

        public void MoveMouseTo(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public void MouseButtonDown(MuseKey key)
        {
            int inputKey;
            switch(key)
            {
                case MuseKey.Left:
                    inputKey = MOUSEEVENTF_LEFTDOWN;
                    break;
                case MuseKey.Right:
                    inputKey = MOUSEEVENTF_RIGHTDOWN;
                    break;
                case MuseKey.Middle:
                    inputKey = MOUSEEVENTF_MIDDLEDOWN;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, null);
            }
            mouse_event(inputKey, 0, 0, 0, 0);
        }

        public void MouseButtonUp(MuseKey key)
        {
            int inputKey;
            switch (key)
            {
                case MuseKey.Left:
                    inputKey = MOUSEEVENTF_LEFTUP;
                    break;
                case MuseKey.Right:
                    inputKey = MOUSEEVENTF_RIGHTUP;
                    break;
                case MuseKey.Middle:
                    inputKey = MOUSEEVENTF_MIDDLEUP;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(key), key, null);
            }
            mouse_event(inputKey, 0, 0, 0, 0);
        }

        public void MouseScroll(float wheelDelta)
        {
            throw new NotImplementedException();
        }
        public void TypeText(string text)
        {
            throw new NotImplementedException();
        }

        [DllImport("user32")]
        private static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo); 
    }
}