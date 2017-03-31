namespace AutoClicker.Model.Abstraction.Interface
{
    public interface ISearchPictureModule
    {
        Rectangle SearchPicture(string name, double accuracy = 0.9);
    }
}
