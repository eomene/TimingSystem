

/// <summary>
/// Abstract base class for timer functionality.
/// </summary>
public abstract class AbstractTimer
{
    /// <summary>
    /// Start or restart the timer.
    /// </summary>
    public abstract void StartTimer();

    /// <summary>
    /// Pause the timer.
    /// </summary>
    public abstract void PauseTimer();

    /// <summary>
    /// Check if the timer is running.
    /// </summary>
    /// <returns>True if the timer is running, false otherwise.</returns>
    public abstract bool IsRunning();

    /// <summary>
    /// Get the remaining time on the timer.
    /// </summary>
    /// <returns>Remaining time as a TimeSpan.</returns>
    public abstract TimeSpan GetRemainingTime();

    /// <summary>
    /// Get the elapsed time since the timer started.
    /// </summary>
    /// <returns>Elapsed time as a TimeSpan.</returns>
    public abstract TimeSpan GetElapsedTime();
}

