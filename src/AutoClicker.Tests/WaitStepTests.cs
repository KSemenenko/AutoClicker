using System;
using System.Diagnostics; 
using AutoClicker.Model.ExecutableSteps;
using FluentAssertions; 
using NUnit.Framework;

namespace AutoClicker.Tests
{
    [TestFixture]
    public class WaiSteptTests
    {
        [Test]
        public void WaitStepExeptionTest()
        {
            TimeSpan ts = TimeSpan.FromSeconds(2);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var step = new WaitStep("wait", ts);

            step.Execuite();
            sw.Stop();

            sw.Elapsed.Should().BeGreaterThan(ts);
            
        }

      
    }
}