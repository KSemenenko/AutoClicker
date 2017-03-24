using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using AutoClicker.Model;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.Abstraction.Interface.Inputs;
using AutoClicker.Model.ExecutableSteps;
using AutoClicker.Model.Inputs;
using AutoClicker.Tests.Properties;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AutoClicker.Tests
{
    [TestFixture]
    public class SearchPictureStepTests
    {
        [Test]
        public void PositiveTest()
        {
            var rect1  = new Model.Rectangle(0,0,100,100);

            IImageSearch imageSearch = NSubstitute.Substitute.For<IImageSearch>();
            imageSearch.Search(Arg.Any<Bitmap>(), Arg.Any<Bitmap>()).Returns(rect1);

            IScreenMaker screenMaker = NSubstitute.Substitute.For<IScreenMaker>();
            screenMaker.GetBitmapFromScreen().Returns(Resources.horse);


            var step = new SearchPictureStep("id", imageSearch, screenMaker, Resources.horse);

            step.SearchPicture().ShouldBeEquivalentTo(rect1);

            step.Execuite().Result.ShouldBeEquivalentTo(ResulType.Succeeded);
        }

        [Test]
        public void NegativeTest()
        {
            var rect1 = Model.Rectangle.Empty;

            IImageSearch imageSearch = NSubstitute.Substitute.For<IImageSearch>();
            imageSearch.Search(Arg.Any<Bitmap>(), Arg.Any<Bitmap>()).Returns(rect1);

            IScreenMaker screenMaker = NSubstitute.Substitute.For<IScreenMaker>();
            screenMaker.GetBitmapFromScreen().Returns(Resources.horse);
           

            var step = new SearchPictureStep("id", imageSearch, screenMaker, Resources.horse);

            step.SearchPicture().ShouldBeEquivalentTo(rect1);

            step.Execuite().Result.ShouldBeEquivalentTo(ResulType.Failed);
        }
    }
}
