using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClicker.Model.Abstraction.Interface.Inputs;

namespace AutoClicker.Model.Abstraction.Interface
{
    public enum MouseEventType
    {
        Move, 
        LeftDown,
        LeftUp,
        RightDown,
        RightUp,
        LeftClick,
        RightClick 
    }

    public interface IMouseEventModule
    {
        IInputSimulator InputSimulator { get; }

        void Execuite(MouseEventType eventType, Point point);
    }
}
