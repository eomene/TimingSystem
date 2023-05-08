
```csharp
using NUnit.Framework;
using System;
using TimingSystem.Runtime.TimingSystem.Scripts;
using UnityEngine;

namespace Tests.Runtime.TimingSystem.Tests
{
    public class TestAbstractTimer : AbstractTimer
    {
        public TestAbstractTimer(float duration) : base(duration) { }

        protected override void OnTimerComplete() { }
    }

    public class AbstractTimerTests
    {
        private TestAbstractTimer _timer;

        [SetUp]
        public void SetUp()
        {
            _timer = new TestAbstractTimer(3.0f);
        }

        [Test]
        public void InitializationTest()
        {
            Assert.AreEqual(3.0f, _timer.Duration);
            Assert.IsFalse(_timer.IsRunning);
            Assert.IsTrue(_timer.IsPaused);
            Assert.IsFalse(_timer.IsComplete);
        }

        [Test]
        public void StartTimerTest()
        {
            _timer.StartTimer();
            Assert.IsTrue(_timer.IsRunning);
            Assert.IsFalse(_timer.IsPaused);
        }

        [Test]
        public void PauseTimerTest()
        {
            _timer.StartTimer();
            _timer.PauseTimer();
            Assert.IsFalse(_timer.IsRunning);
            Assert.IsTrue(_timer.IsPaused);
        }

        [Test]
        public void UpdateElapsedTimeTest()
        {
            _timer.StartTimer();
            _timer.UpdateElapsedTime(1.5f);
            Assert.AreEqual(1.5f, _timer.ElapsedTime);
        }

        [Test]
        public void TimerCompleteTest()
        {
            _timer.StartTimer();
            _timer.UpdateElapsedTime(3.0f);
            Assert.IsFalse(_timer.IsRunning);
            Assert.IsFalse(_timer.IsPaused);
            Assert.IsTrue(_timer.IsComplete);
        }

        [Test]
        public void ResetTimerTest()
        {
            _timer.StartTimer();
            _timer.UpdateElapsedTime(1.5f);
            _timer.ResetTimer();

            Assert.AreEqual(0.0f, _timer.ElapsedTime);
            Assert.IsFalse(_timer.IsRunning);
            Assert.IsTrue(_timer.IsPaused);
            Assert.IsFalse(_timer.IsComplete);
        }

        [Test]
        public void TimeRemainingTest()
        {
            _timer.StartTimer();
            _timer.UpdateElapsedTime(1.5f);
            Assert.AreEqual(1.5f, _timer.TimeRemaining);
        }
    }
}
```
