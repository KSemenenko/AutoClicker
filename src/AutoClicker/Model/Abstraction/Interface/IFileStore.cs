using System.Drawing;

namespace AutoClicker.Model.Abstraction.Interface
{
    public interface IFileStore
    {
        Bitmap LoadImageFromFile(string name);
        void SaveImageToFile(Bitmap bitmap, string name);
        Project LoadProjectFromFile(string name);
        void SaveProjectToFile(Project project, string name);
        bool FileExist(string name);
    }
}