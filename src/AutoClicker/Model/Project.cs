using System.Collections.ObjectModel;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.ExecutableSteps;

namespace AutoClicker.Model
{
    public class Project
    {
        public string Name { get; set; }

        public ObservableCollection<IExecutableStep> Steps { get; set; } = new ObservableCollection<IExecutableStep>
        {
            new RootStep("root")
        };
    }
}