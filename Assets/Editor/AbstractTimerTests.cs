
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class AbstractTimerTests : MonoBehaviour
    {
        private GameObject _testTimerObj;

        [SetUp]
        public void Setup()
        {
            _testTimerObj = new GameObject();
            _testTimerObj.AddComponent<TestTimer>();
        }

        [TearDown]
        public void TearDown()
        {
            Destroy(_testTimerObj);
        }

        // Test cases go here
        [UnityTest]
        public IEnumerator Test_StartTimer()
        {
            var testTimer = _testTimerObj.GetComponent<TestTimer>();

            Assert.IsFalse(testTimer.IsRunning);
            
            testTimer.StartTimer();

            Assert.IsTrue(testTimer.IsRunning);

            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_StopTimer()
        {
            var testTimer = _testTimerObj.GetComponent<TestTimer>();

            testTimer.StartTimer();
            Assert.IsTrue(testTimer.IsRunning);

            testTimer.StopTimer();
            Assert.IsFalse(testTimer.IsRunning);

            yield return null;
        }

        [UnityTest]
        public IEnumerator Test_ResetTimer()
        {
            var testTimer = _testTimerObj.GetComponent<TestTimer>();

            testTimer.StartTimer();
            yield return new WaitForSeconds(2.0f); // Wait for 2 seconds

            testTimer.ResetTimer();
            Assert.AreEqual(0, testTimer.TimePassed);

            yield return null;
        }
    }

    public class TestTimer : AbstractTimer
    {
        protected override IEnumerator TimerCoroutine()
        {
            while (IsRunning)
            {
                TimePassed += Time.deltaTime;
                yield return null;
            }
        }
    }
}