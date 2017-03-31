using AutoClicker.Model;
using AutoClicker.Model.Abstraction.Interface;
using FluentAssertions;
using NUnit.Framework;

namespace AutoClicker.Tests
{
    [TestFixture]
    public class TestResultTests
    {
        [Test]
        public void SetResultTest()
        {
            var result = new TestResult();

            result.Result = ResulType.Succeeded;
            result.Result.ShouldBeEquivalentTo(ResulType.Succeeded);

            result.Result = ResulType.Warning;
            result.Result = ResulType.Succeeded;
            result.Result.ShouldBeEquivalentTo(ResulType.Warning);

            result.Result = ResulType.Failed;
            result.Result = ResulType.Succeeded;
            result.Result.ShouldBeEquivalentTo(ResulType.Failed);
        }
    }
}