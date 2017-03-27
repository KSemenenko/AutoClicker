using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClicker.Model.Abstraction.Interface;
using Newtonsoft.Json;

namespace AutoClicker.Model
{
    public class FileStore : IFileStore
    {
        public Bitmap LoadImageFromFile(string name)
        {
            return (Bitmap)Image.FromFile(name);
        }

        public void SaveImageToFile(Bitmap bitmap, string name)
        {
            bitmap.Save(name);
        }

        public bool FileExist(string name)
        {
            return File.Exists(name);
        }

        public Project LoadProjectFromFile(string name)
        {
            return JsonConvert.DeserializeObject<Project>(name);
        }

        public void SaveProjectToFile(Project project, string name)
        {
            var content = JsonConvert.SerializeObject(project);
            File.WriteAllText(name, content);
        }
    }
}