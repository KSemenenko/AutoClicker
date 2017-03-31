using System;
using System.Diagnostics;
using AutoClicker.Model;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;
using AutoClicker.Model.ExecutableSteps;
using AutoClicker.Tests.Properties;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AutoClicker.Tests
{
    [TestFixture]
    public class WaitPictureStepTest
    {
        [Test]
        public void WaitPictureStepNegativeTest()
        {
            TimeSpan ts = TimeSpan.FromSeconds(5);

            var searchPictureModule = Substitute.For<ISearchPictureModule>();
            searchPictureModule.SearchPicture("horse", Arg.Any<double>()).Returns(Rectangle.Empty);
            var fileStore = Substitute.For<IFileStore>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var step = new WaitPictureStep("id", 5, TimeSpan.FromSeconds(1), searchPictureModule, fileStore, "horse");

            step.Execuite().Result.ShouldBeEquivalentTo(ResulType.Failed);
            sw.Stop();

            sw.Elapsed.Should().BeGreaterThan(ts);
        }

        [Test]
        public void WaitPictureStepPositiveTest()
        {
            var searchPictureModule = Substitute.For<ISearchPictureModule>();
            searchPictureModule.SearchPicture("horse", Arg.Any<double>()).Returns(new Rectangle(1, 2, 3, 4));

            var fileStore = Substitute.For<IFileStore>();
            var step = new WaitPictureStep("id", 5, TimeSpan.FromSeconds(1), searchPictureModule, fileStore, "horse");

            step.Execuite().Result.ShouldBeEquivalentTo(ResulType.Succeeded);

            searchPictureModule.Received().SearchPicture(Arg.Any<string>(), Arg.Any<double>());
        }
    }
}