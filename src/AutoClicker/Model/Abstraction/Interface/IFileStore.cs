using System.Drawing;

namespace AutoClicker.Model.Abstraction.Interface
{
    public interface IFileStore
    {
        Bitmap LoadImageFromFile(string path);
        void SaveImageToFile(Bitmap bitmap, string name);
        Project LoadProjectFromFile(string name);
        void SaveProjectToFile(Project project, string path);
        bool FileExist(string path);
        bool FolderExist(string path);
    }
}