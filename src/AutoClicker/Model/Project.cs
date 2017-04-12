using System.Collections.ObjectModel;
using System.IO;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.ExecutableSteps;
using Newtonsoft.Json;

namespace AutoClicker.Model
{
    public class Project
    {
        public string Name { get; set; }

        [JsonIgnore]
        public string ProjectRootDirectory { get; set; }

        public string ImageFolder { get; set; } = "images";
        public string LogsFolder { get; set; } = "logs";
        public string ResultsFolder { get; set; } = "Results";

        public ObservableCollection<IExecutableStep> Roots { get; set; } = new ObservableCollection<IExecutableStep>
        {
            new RootStep("root")
        };
    }
}