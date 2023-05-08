
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TimingSystem.Runtime.TimingSystem.Scripts;

public class AbstractTimerTest
{
    private GameObject _testObject;
    private TestTimer _testTimer;

    [SetUp]
    public void Init()
    {
        _testObject = new GameObject();
        _testTimer = _testObject.AddComponent<TestTimer>();
    }

    [TearDown]
    public void Cleanup()
    {
        Object.Destroy(_testObject);
    }

    [UnityTest]
    public IEnumerator StartTimer_PlayModeTest()
    {
        _testTimer.StartTimer();

        yield return new WaitForSeconds(0.1f);

        Assert.Greater(_testTimer.TimeElapsed, 0f, "Time elapsed should be greater than 0 after starting the timer.");
    }

    [UnityTest]
    public IEnumerator PauseTimer_PlayModeTest()
    {
        _testTimer.StartTimer();
        yield return new WaitForSeconds(0.1f);
        _testTimer.PauseTimer();

        float pausedTime = _testTimer.TimeElapsed;

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(pausedTime, _testTimer.TimeElapsed, 0.001f, "Time should not progress when the timer is paused.");
    }

    [UnityTest]
    public IEnumerator ResumeTimer_PlayModeTest()
    {
        _testTimer.StartTimer();
        yield return new WaitForSeconds(0.1f);
        _testTimer.PauseTimer();

        float pausedTime = _testTimer.TimeElapsed;

        _testTimer.ResumeTimer();
        yield return new WaitForSeconds(0.1f);

        Assert.Greater(_testTimer.TimeElapsed, pausedTime, "Time should progress after resuming the timer.");
    }

    [UnityTest]
    public IEnumerator ResetTimer_PlayModeTest()
    {
        _testTimer.StartTimer();
        yield return new WaitForSeconds(0.1f);

        _testTimer.ResetTimer();

        Assert.AreEqual(0f, _testTimer.TimeElapsed, 0.001f, "Time should reset to 0.");
    }
}

