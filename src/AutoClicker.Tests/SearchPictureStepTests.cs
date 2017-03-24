using System.Drawing;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;
using AutoClicker.Model.ExecutableSteps;
using AutoClicker.Tests.Properties;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Rectangle = AutoClicker.Model.Rectangle;

namespace AutoClicker.Tests
{
    [TestFixture]
    public class SearchPictureStepTests
    {
        [Test]
        public void NegativeTest()
        {
            var rect1 = Rectangle.Empty;

            var imageSearch = Substitute.For<IImageSearch>();
            imageSearch.Search(Arg.Any<Bitmap>(), Arg.Any<Bitmap>(), Arg.Any<double>()).Returns(rect1);

            var screenMaker = Substitute.For<IScreenMaker>();
            screenMaker.GetBitmapFromScreen().Returns(Resources.horse);

            var step = new SearchPictureStep("id", imageSearch, screenMaker, Resources.horse);

            step.Execuite().Result.ShouldBeEquivalentTo(ResulType.Failed);
        }

        [Test]
        public void PositiveTest()
        {
            var rect1 = new Rectangle(0, 0, 100, 100);

            var imageSearch = Substitute.For<IImageSearch>();
            imageSearch.Search(Arg.Any<Bitmap>(), Arg.Any<Bitmap>(), Arg.Any<double>()).Returns(rect1);

            var screenMaker = Substitute.For<IScreenMaker>();
            screenMaker.GetBitmapFromScreen().Returns(Resources.horse);

            var step = new SearchPictureStep("id", imageSearch, screenMaker, Resources.horse);
            
            step.Execuite().Result.ShouldBeEquivalentTo(ResulType.Succeeded);
        }

        [Test]
        public void WarningTest()
        {
            var rect1 = new Rectangle(0, 0, 100, 100);

            var imageSearch = Substitute.For<IImageSearch>();
            imageSearch.Search(Arg.Any<Bitmap>(), Arg.Any<Bitmap>(), 1).Returns(Rectangle.Empty);
            imageSearch.Search(Arg.Any<Bitmap>(), Arg.Any<Bitmap>(), 0.8).Returns(rect1);
            var screenMaker = Substitute.For<IScreenMaker>();
            screenMaker.GetBitmapFromScreen().Returns(Resources.horse);

            var step = new SearchPictureStep("id", imageSearch, screenMaker, Resources.horse);

            step.Execuite().Result.ShouldBeEquivalentTo(ResulType.Warning);
        }
    }
}