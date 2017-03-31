namespace AutoClicker.Model.Abstraction.Interface.Inputs
{
    public enum MuseKey
    {
        Left,
        Right,
        Middle
    }

    public interface IInputSimulator
    { 
        void MouseButtonClick(MuseKey key, uint count = 1);
        void MoveMouseTo(int x, int y);
        void MouseButtonDown(MuseKey key);
        void MouseButtonUp(MuseKey key);
        void MouseScroll(float wheelDelta);
        void TypeText(string text);
    }
}