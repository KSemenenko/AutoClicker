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
        MiddleDown,
        MiddleUp,
        LeftClick,
        RightClick,
        MiddleClick,
        ScrollWheel
    }

    public interface IMouseEventModule
    {  
        void Execuite(MouseEventType eventType, Point point = default(Point), float wheelDelta = 0, uint count = 1);
    }
}
