using Cradaptive.AbstractTimer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTimerExample : MonoBehaviour
{
    AbstractTimer abstractTimer;

    // Start is called before the first frame update
    void Awake()
    {
        abstractTimer = GetComponent<AbstractTimer>();
    }

    [ContextMenu("StartDownTimer")]
    public void StartTickDownTimer()
    {
        abstractTimer.StartTickDownTimer("jsdfs", "tickdowntest", 15, () =>
        {
            Debug.LogError("My Timer Ended...Yaay!");
        });
    }


    [ContextMenu("StartUpTimerStopCountTillManualStop")]
    public void StartTickUpTimerCountTillManualStop()
    {
        abstractTimer.StartTickUpTimer("hrrthrthr", "tickdowntest", () =>
        {
            Debug.LogError("My Timer Ended...Yaay!");
        });
    }

    [ContextMenu("StopUpTimerStopCountTillManualStop")]
    public void StopTickUpTimerCountTillManualStop()
    {
      Debug.LogError($"My timer ended in these seconds {abstractTimer.EndTimer("hrrthrthr")}");
    }

}
