

/// <summary>
/// Interface representing the functions of a Cradaptive timer.
/// </summary>
public interface ICradaptiveTimer
{
    /// <summary>
    /// Initialize the timer with the given parameters.
    /// </summary>
    /// <param name="timerData">CradaptiveTimerData object to set up the base duration and duration modifier.</param>
    /// <param name="onTimerComplete">Action to perform when the timer completes.</param>
    void Initialize(CradaptiveTimerData timerData, Action onTimerComplete);

    /// <summary>
    /// Modify the duration of the timer using a specified factor.
    /// </summary>
    /// <param name="factor">Factor by which the duration will be modified.</param>
    void ModifyDuration(float factor);
}

/// <summary>
/// Interface representing the functions of a Cradaptive timer provider.
/// </summary>
public interface ICradaptiveTimerProvider
{
    /// <summary>
    /// Get a Cradaptive timer with the specified timer data.
    /// </summary>
    /// <param name="timerData">CradaptiveTimerData object to create timer from.</param>
    /// <returns>New instance of a Cradaptive timer with the given timer data.</returns>
    ICradaptiveTimer GetCradaptiveTimer(CradaptiveTimerData timerData);
}