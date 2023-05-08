

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TimingSystem.Runtime.TimingSystem.Scripts;

namespace TimingSystem.Tests.PlayMode
{
    public class TimingSystemTests_PlayMode
    {
        private GameObject _timingSystemGo;
        private AbstractTimer _abstractTimer;

        [SetUp]
        public void Setup()
        {
            _timingSystemGo = new GameObject();
            _abstractTimer = _timingSystemGo.AddComponent<AbstractTimer>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_timingSystemGo);
        }

        [UnityTest]
        public IEnumerator StartTimer_InitializesAndStartsTimer()
        {
            _abstractTimer.StartTimer();

            yield return null;

            Assert.IsTrue(_abstractTimer.IsTimerRunning);
            Assert.AreEqual(0, _abstractTimer.ElapsedTime);
        }

        [UnityTest]
        public IEnumerator StopTimer_StopsTimer()
        {
            _abstractTimer.StartTimer();
            yield return new WaitForSeconds(1);
            _abstractTimer.StopTimer();

            Assert.IsTrue(_abstractTimer.ElapsedTime > 0);
            Assert.IsFalse(_abstractTimer.IsTimerRunning);
        }

        [UnityTest]
        public IEnumerator ResetTimer_ResetsElapsedTime()
        {
            _abstractTimer.StartTimer();
            yield return new WaitForSeconds(1);
            _abstractTimer.ResetTimer();

            Assert.AreEqual(0, _abstractTimer.ElapsedTime);
        }
    }
}