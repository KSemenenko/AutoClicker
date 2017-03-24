namespace AutoClicker.Model.Abstraction.Interface.Inputs
{
    internal interface IInputSimulator
    {
        void MouseLeftButtonClick(int x, int y);
        void MouseLeftButtonDoubleClick(int x, int y);
        void MoveMouseTo(int x, int y);
        void MouseLeftButtonDown();
        void MouseLeftButtonUp();
        void TypeText(string text);
    }
}