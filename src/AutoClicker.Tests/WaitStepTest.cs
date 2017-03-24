using System;
using System.Diagnostics;
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
    public class WaiSteptTest
    {
        [Test]
        public void WaitStepExeptionTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var step = new WaitStep("wait", 5);

            step.Execuite();
            sw.Stop();

            var value  = sw.Elapsed.Seconds == 5;
            
            value.ShouldBeEquivalentTo(true);
        }

      
    }
}