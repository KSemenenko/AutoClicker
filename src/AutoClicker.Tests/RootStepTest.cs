using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using AutoClicker.Model.ExecutableSteps;
using FluentAssertions;
using NSubstitute;
using AutoClicker.Interface;
using NSubstitute.Core;
using NSubstitute.ReturnsExtensions;

namespace AutoClicker.Tests
{
    [TestFixture]
    public class RootStepTest
    {
        [Test]
        public void SucceededResult()
        {
            var child1 = Substitute.For<IExecutableStep>();
            var result = Substitute.For<ITestResult>();

            result.Result.Returns(ResulType.Succeeded);
             
            child1.Execuite().Returns(result);
      

            var child2 = Substitute.For<IExecutableStep>();
            child2.Execuite().Returns(result);

            RootStep rst = new RootStep("root");
            rst.TryAddChild("root", child1);
            rst.TryAddChild("root",child2);

            var  resultEx = rst.Execuite();

            resultEx.Result.ShouldBeEquivalentTo(ResulType.Succeeded);
 
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
            rst.TryAddChild("root", child1);
            rst.TryAddChild("root", child2);

            var resultEx = rst.Execuite();

            resultEx.Result.ShouldBeEquivalentTo(ResulType.Warning);

        }
/*
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

            RootStep rst = new RootStep("root");
            rst.TryAddChild("root", child1);
            rst.TryAddChild("root", child2);
            rst.TryAddChild("root", child3);

            var resultEx = rst.Execuite();

            resultEx.Result.ShouldBeEquivalentTo(ResulType.Failed);
            child1.Received().Execuite();
            child2.Received().Execuite();
            child3.DidNotReceive().Execuite();
        }
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
            child1.GetValidateException().Returns(new AggregateException());
            child2.GetValidateException().Returns(new AggregateException());

            StepBase rst = new StepBase("root");
            rst.TryAddChild(child1);
            rst.TryAddChild(child2);
            rst.TryAddChild(null);

            child2.GetValidateException().Returns(new AggregateException(new Exception()));
            var aggregate = rst.GetValidateException();

            aggregate.InnerExceptions.Count.ShouldBeEquivalentTo(2);
        }
        [Test]
        public void TryGetStepById()
        {
            StepBase rst = new StepBase("root");
            StepBase rst2 = new StepBase("innerRoot");

           
            var child1 = Substitute.For<IExecutableStep>();
            var child2 = Substitute.For<IExecutableStep>();
            var child3 = Substitute.For<IExecutableStep>();

            child1.Id.Returns("1");
            child2.Id.Returns("2");
            child3.Id.Returns("3");
            
            child1.GetValidateException().Returns(new AggregateException());
            child2.GetValidateException().Returns(new AggregateException());

            rst2.TryAddChild(child1);
            rst2.TryAddChild(child2);
            rst2.TryAddChild(child3);

            rst.TryAddChild(rst2);

            var result = rst.TryGetStepById("3");

            result.ShouldBeEquivalentTo(child3);
        }*/
    }
}
