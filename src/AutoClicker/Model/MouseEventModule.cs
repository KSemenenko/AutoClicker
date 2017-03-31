using System;
using System.Drawing;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;
using AutoClicker.Model.Inputs;

namespace AutoClicker.Model
{
    class MouseEventModule : IMouseEventModule
    {
        private IInputSimulator _inputSimulator;

        public MouseEventModule()
        {
            _inputSimulator = new InputSimulator();
        }

        public void Execuite(MouseEventType eventType, Point point, float wheelDelta = 0, uint count = 1)
        {
            
            switch (eventType)
            {
                case MouseEventType.Move:
                    _inputSimulator.MoveMouseTo(point.X, point.Y);
                    break; 
                case MouseEventType.LeftDown: 
                    _inputSimulator.MouseButtonDown(MuseKey.Left);
                    break;
                case MouseEventType.LeftUp:
                    _inputSimulator.MouseButtonUp(MuseKey.Left);
                    break;
                case MouseEventType.RightDown:
                    _inputSimulator.MouseButtonDown(MuseKey.Right);
                    break;
                case MouseEventType.RightUp:
                    _inputSimulator.MouseButtonUp(MuseKey.Right);
                    break;
                case MouseEventType.LeftClick:
                    _inputSimulator.MouseButtonClick(MuseKey.Left, count);
                    break;
                case MouseEventType.RightClick:
                    _inputSimulator.MouseButtonClick(MuseKey.Right, count);
                    break;
                case MouseEventType.MiddleClick:
                    _inputSimulator.MouseButtonClick(MuseKey.Middle, count);
                    break;
                case MouseEventType.MiddleUp:
                    _inputSimulator.MouseButtonUp(MuseKey.Middle);
                    break;
                case MouseEventType.MiddleDown:
                    _inputSimulator.MouseButtonDown(MuseKey.Middle);
                    break;
                case MouseEventType.ScrollWheel:
                    _inputSimulator.MouseScroll(wheelDelta);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
            }

        } 
    }
}
