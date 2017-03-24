using System;
using System.Linq;
using AutoClicker.Model.Abstraction.Interface;
using AutoClicker.Model.ExecutableSteps;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace AutoClicker.Tests
{
    [TestFixture]
    public class RootStepTest
    {
        [Test]
        public void NullRefExeptionTest()
        {
            var child1 = Substitute.For<IExecutableStep>();
            var result = Substitute.For<ITestResult>();
            var result2 = Substitute.For<ITestResult>();

            result.Result.Returns(ResulType.Warning);
            result2.Result.Returns(ResulType.Failed);

            child1.Execuite().Returns(result);

            var child2 = Substitute.For<IExecutableStep>();
            child2.Execuite().Returns(result2);

            child1.FindExecutableStepById(Arg.Any<string>()).ReturnsNull();
            child2.FindExecutableStepById(Arg.Any<string>()).ReturnsNull();
            child1.TryGetStepById(Arg.Any<string>()).ReturnsNull();
            child2.TryGetStepById(Arg.Any<string>()).ReturnsNull();

            child1.GetValidateException().Returns(new AggregateException());
            child2.GetValidateException().Returns(new AggregateException());

            var rst = new RootStep("root");
            rst.TryAddChild(child1);
            rst.TryAddChild(child2);

            child2.GetValidateException().Returns(new AggregateException(new Exception()));
            var aggregate = rst.GetValidateException();

            aggregate.InnerExceptions.Count.ShouldBeEquivalentTo(1);
        }

        [Test]
        public void SucceededResult()
        {
            var child1 = Substitute.For<IExecutableStep>();
            var result = Substitute.For<ITestResult>();

            result.Result.Returns(ResulType.Succeeded);

            child1.Execuite().Returns(result);

            var child2 = Substitute.For<IExecutableStep>();
            child2.Execuite().Returns(result);

            var rst = new RootStep("root");
            rst.TryAddChild(child1);
            rst.TryAddChild(child2);

            var resultEx = rst.Execuite();

            resultEx.Result.ShouldBeEquivalentTo(ResulType.Succeeded);
        }

        [Test]
        public void TryAdd()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            var child2 = new ClickStep("2");
            var child3 = new ClickStep("3");
            rst.TryAddChild(rst2);
            rst.TryAddChild(child1, "innerRoot");
            rst.TryAddChild(child2, "innerRoot");
            rst.TryAddChild(child3, "innerRoot");

            rst.Childs.Count().ShouldBeEquivalentTo(1);
            rst2.Childs.Count().ShouldBeEquivalentTo(3);
        }

        [Test]
        public void TryAddByFailedId()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            rst.TryAddChild(rst2);
            var result = rst.TryAddChild(child1, "2");
            result.ShouldBeEquivalentTo(false);
        }

        [Test]
        public void TryGetStepById()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            var child2 = new ClickStep("2");
            var child3 = new ClickStep("3");

            rst.TryAddChild(rst2);
            rst.TryAddChild(child1, "innerRoot");
            rst.TryAddChild(child2, "innerRoot");
            rst.TryAddChild(child3, "innerRoot");

            var result = rst.TryGetStepById("3");

            result.ShouldBeEquivalentTo(child3);
        }

        [Test]
        public void TryRemoveFailed()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            var child2 = new ClickStep("2");
            var child3 = new ClickStep("3");

            rst.TryAddChild(rst2);
            rst.TryAddChild(child1, "innerRoot");
            rst.TryAddChild(child2, "innerRoot");
            rst.TryAddChild(child3, "innerRoot");

            var result = rst.TryRemoveChild("4");

            result.ShouldBeEquivalentTo(false);
        }

        [Test]
        public void TryRemoveSucceessed()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            var child2 = new ClickStep("2");
            var child3 = new ClickStep("3");
            rst.TryAddChild(rst2);
            rst.TryAddChild(child1, "innerRoot");
            rst.TryAddChild(child2, "innerRoot");
            rst.TryAddChild(child3, "innerRoot");

            var result = rst.TryRemoveChild("3");

            result.ShouldBeEquivalentTo(true);
        }

        [Test]
        public void TryRemoveSucceessedByItem()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            var child2 = new ClickStep("2");
            var child3 = new ClickStep("3");
            rst.TryAddChild(rst2);
            rst.TryAddChild(child1, "innerRoot");
            rst.TryAddChild(child2, "innerRoot");
            rst.TryAddChild(child3, "innerRoot");

            var result = rst.TryRemoveChild(child3);

            result.ShouldBeEquivalentTo(true);
        }

        [Test]
        public void TryResetFailed()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            var child2 = new ClickStep("2");
            var child3 = new ClickStep("3");
            var child4 = new RootStep("4");
            rst.TryAddChild(rst2);
            rst.TryAddChild(child1, "innerRoot");
            rst.TryAddChild(child2, "innerRoot");
            rst.TryAddChild(child3, "innerRoot");

            var result = rst.TryResetChild(child4);

            result.ShouldBeEquivalentTo(false);
        }

        [Test]
        public void TryResetSuccessed()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            var child2 = new ClickStep("2");
            var child3 = new ClickStep("3");
            var child4 = new RootStep("3");
            rst.TryAddChild(rst2);
            rst.TryAddChild(child1, "innerRoot");
            rst.TryAddChild(child2, "innerRoot");
            rst.TryAddChild(child3, "innerRoot");

            var result = rst.TryResetChild(child4);

            result.ShouldBeEquivalentTo(true);
        }

        [Test]
        public void TryResetSuccessedById()
        {
            var rst = new RootStep("root");
            var rst2 = new RootStep("innerRoot");

            var child1 = new ClickStep("1");
            var child2 = new ClickStep("2");
            var child3 = new ClickStep("3");
            var child4 = new RootStep("3");
            rst.TryAddChild(rst2);
            rst.TryAddChild(child1, "innerRoot");
            rst.TryAddChild(child2, "innerRoot");
            rst.TryAddChild(child3, "innerRoot");

            var result = rst.TryResetChild(child4, "innerRoot");

            result.ShouldBeEquivalentTo(true);
        }

        [Test]
        public void WarningFailed()
        {
            var child1 = Substitute.For<IExecutableStep>();
            var result = Substitute.For<ITestResult>();
            var result2 = Substitute.For<ITestResult>();
            var result3 = Substitute.For<ITestResult>();

            result.Result.Returns(ResulType.Warning);
            result2.Result.Returns(ResulType.Failed);
            result3.Result.Returns(ResulType.Warning);

            child1.Execuite().Returns(result);

            var child2 = Substitute.For<IExecutableStep>();
            child2.Execuite().Returns(result2);

            var child3 = Substitute.For<IExecutableStep>();
            child3.Execuite().Returns(result3);

            child1.FindExecutableStepById(Arg.Any<string>()).ReturnsNull();
            child2.FindExecutableStepById(Arg.Any<string>()).ReturnsNull();
            child3.FindExecutableStepById(Arg.Any<string>()).ReturnsNull();
            child1.TryGetStepById(Arg.Any<string>()).ReturnsNull();
            child2.TryGetStepById(Arg.Any<string>()).ReturnsNull();
            child3.TryGetStepById(Arg.Any<string>()).ReturnsNull();

            var rst = new RootStep("root");
            rst.TryAddChild(child1);
            rst.TryAddChild(child2);
            rst.TryAddChild(child3);

            var resultEx = rst.Execuite();

            resultEx.Result.ShouldBeEquivalentTo(ResulType.Failed);
            child1.Received().Execuite();
            child2.Received().Execuite();
            child3.DidNotReceive().Execuite();
        }

        [Test]
        public void WarningResult()
        {
            var result = Substitute.For<ITestResult>();
            var result2 = Substitute.For<ITestResult>();
            var child1 = Substitute.For<IExecutableStep>();
            var child2 = Substitute.For<IExecutableStep>();

            result.Result.Returns(ResulType.Succeeded);
            result2.Result.Returns(ResulType.Warning);

            child1.Id.Returns("1");
            child2.Id.Returns("2");

            child1.FindExecutableStepById(Arg.Any<string>()).ReturnsNull();
            child2.FindExecutableStepById(Arg.Any<string>()).ReturnsNull();
            child1.TryGetStepById(Arg.Any<string>()).ReturnsNull();
            child2.TryGetStepById(Arg.Any<string>()).ReturnsNull();
            child1.Execuite().Returns(result);
            child2.Execuite().Returns(result2);

            var rst = new RootStep("root");
            rst.TryAddChild(child1);
            rst.TryAddChild(child2);

            var resultEx = rst.Execuite();

            resultEx.Result.ShouldBeEquivalentTo(ResulType.Warning);
        }
    }
}