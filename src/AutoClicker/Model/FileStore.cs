using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoClicker.Model.Abstraction.Interface;
using Newtonsoft.Json;

namespace AutoClicker.Model
{
    public class FileStore : IFileStore
    {
        private string _autoClickerProjectFileName = "project.json";

        public Bitmap LoadImageFromFile(string name)
        {
            return (Bitmap)Image.FromFile(name);
        }

        public void SaveImageToFile(Bitmap bitmap, string name)
        {
            bitmap.Save(name);
        }

        public bool FileExist(string path)
        {
            return File.Exists(path);
        }

        public bool FolderExist(string path)
        {
            return Directory.Exists(path);
        }

        public Project LoadProjectFromFile(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                return null;
            }

            var projectFilePath = Path.Combine(path, _autoClickerProjectFileName);
            var fileContent = File.ReadAllText(projectFilePath);

            var project = JsonConvert.DeserializeObject<Project>(fileContent);
            project.ProjectRootDirectory = path;

            return project;
        }

        public void SaveProjectToFile(Project project, string path)
        {
            project.ProjectRootDirectory = path;

            var imageFolder = Path.Combine(project.ProjectRootDirectory, project.ImageFolder);
            var logsFolder = Path.Combine(project.ProjectRootDirectory, project.LogsFolder);
            var resultsFolder = Path.Combine(project.ProjectRootDirectory, project.ResultsFolder);

            var projectFilePath = Path.Combine(project.ProjectRootDirectory, _autoClickerProjectFileName);

            CreateFolderIfNotExists(imageFolder);
            CreateFolderIfNotExists(logsFolder);
            CreateFolderIfNotExists(resultsFolder);


            var content = JsonConvert.SerializeObject(project);
            File.WriteAllText(projectFilePath, content);
        }

        private void CreateFolderIfNotExists(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}