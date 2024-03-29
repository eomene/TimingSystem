using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Cradaptive.AbstractTimer
{
    /// <summary>
    /// Attach this to any gameobject as a component. Call start timer and pass in required info to identify timer, and then you can end timer to stop timer at any time
    /// Note timer counts up not down
    /// </summary>
    public class AbstractTimer : MonoBehaviour
    {
        [SerializeField] List<CradaptiveTimerClass> timerLog = new List<CradaptiveTimerClass>();
        [SerializeField] bool showDebugMessages;
        bool isPaused;
        [SerializeField] IAbstractTimerConsumer[] abstractTimerConsumers;

        private void Awake()
        {
            abstractTimerConsumers = GetComponents<IAbstractTimerConsumer>();
        }

        private void Update()
        {
            if (!isPaused)
            {
                for (int i = 0; i < timerLog.Count; i++)
                {
                    if (timerLog[i].tick)
                    {
                        if (timerLog[i].timerType == TimerType.TickUp)
                        {
                            timerLog[i].timer += Time.deltaTime;
                            timerLog[i]?.onTimerUpdated?.Invoke(timerLog[i].key,timerLog[i].timer);
                            UpdateCurrentDisplays(timerLog[i]);
                        }
                        else
                        {
                            timerLog[i].timer -= Time.deltaTime;
                            timerLog[i]?.onTimerUpdated?.Invoke(timerLog[i].key,timerLog[i].timer > 0 ? timerLog[i].timer : 0);
                            UpdateCurrentDisplays(timerLog[i]);
                            if (timerLog[i].timer < 0)
                            {
                                EndTimer(timerLog[i], i);
                                UpdateDisplaysOnEnded();
                            }
                        }
                    }
                    else
                    {
                        EndTimer(timerLog[i], i);
                    }
                }
            }
        }

        public void UpdateCurrentDisplays(CradaptiveTimerClass value)
        {
            for (int i = 0; i < abstractTimerConsumers.Length; i++)
                abstractTimerConsumers[i]?.onTimerUpdated(value);
        }

        public void UpdateDisplaysOnEnded()
        {
            for (int i = 0; i < abstractTimerConsumers.Length; i++)
                abstractTimerConsumers[i]?.onTimerEnded();
        }

        void EndTimer(CradaptiveTimerClass timerLog, int i)
        {
            if (showDebugMessages)
            {
                float finalTimer = timerLog.timerType == TimerType.TickDown ? timerLog.maxTime : timerLog.timer;
                Debug.LogError($"Timer ended for timer {timerLog.name} with key {timerLog.key} in {finalTimer} seconds");
            }
            timerLog?.onTimerCompleted?.Invoke(timerLog.key);
            this.timerLog.RemoveAt(i);
        }

        public float EndTimer(string key)
        {
            CradaptiveTimerClass log = timerLog.FirstOrDefault(x => x.key == key);
            if (log != null)
            {
                log.tick = false;
                return log.timer;
            }
            return 0;
        }

        public bool IsTimerRunning(string key)
        {
            CradaptiveTimerClass log = timerLog.FirstOrDefault(x => x.key == key);
            return (log != null);
        }

        public float GetTimeLeft(string key)
        {
            CradaptiveTimerClass log = timerLog.FirstOrDefault(x => x.key == key);
            return log != null ? log.timer : 0;
        }

        public void StartTickUpTimer(string key, string name, Action<string> onTimerCompleted, Action<string,float> onTimerUpdated = null)
        {
            CradaptiveTimerClass timerClass = new CradaptiveTimerClass();

            timerClass.key = key;
            timerClass.tick = true;
            timerClass.name = name;
            timerClass.onTimerCompleted = onTimerCompleted;
            timerClass.timerType = TimerType.TickUp;
            timerClass.onTimerUpdated = onTimerUpdated;

            if (showDebugMessages)
                Debug.LogError($"Started Timer for timer {name} with key {key}");

            timerLog.Add(timerClass);
        }

        public void StartTickDownTimer(string key, string name, float startTimeInSeconds, Action<string> onTimerCompleted, Action<string,float> onTimerUpdated = null)
        {
            CradaptiveTimerClass timerClass = new CradaptiveTimerClass();

            timerClass.key = key;
            timerClass.tick = true;
            timerClass.name = name;
            timerClass.onTimerCompleted = onTimerCompleted;
            timerClass.timer = startTimeInSeconds;
            timerClass.maxTime = startTimeInSeconds;
            timerClass.timerType = TimerType.TickDown;
            timerClass.onTimerUpdated = onTimerUpdated;

            if (showDebugMessages)
                Debug.LogError($"Started Timer for timer {name} with key {key} for {startTimeInSeconds} seconds");

            timerLog.Add(timerClass);
        }

        public void TogglePause(bool pause)
        {
            isPaused = pause;
        }

        private void OnApplicationPause(bool pause)
        {
            TogglePause(pause);
        }

        public void EndAllTimers()
        {
            UpdateDisplaysOnEnded();
            timerLog.Clear();
        }


    }
}