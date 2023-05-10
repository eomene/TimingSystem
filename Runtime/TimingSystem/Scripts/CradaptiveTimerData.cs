

/// <summary>
/// Represents data for Cradaptive timers.
/// </summary>
[Serializable]
public class CradaptiveTimerData
{
    [SerializeField]
    private float _baseDuration;
    [SerializeField]
    private float _durationModifier;

    /// <summary>
    /// Create a new CradaptiveTimerData instance with the specified base duration and duration modifier.
    /// </summary>
    /// <param name="baseDuration">Base duration of the timer.</param>
    /// <param name="durationModifier">Duration modifier applied to the base duration.</param>
    public CradaptiveTimerData(float baseDuration, float durationModifier)
    {
        _baseDuration = baseDuration;
        _durationModifier = durationModifier;
    }

    /// <summary>
    /// Get or set the base duration of the timer.
    /// </summary>
    public float BaseDuration
    {
        get => _baseDuration;
        set => _baseDuration = value;
    }

    /// <summary>
    /// Get or set the duration modifier applied to the base duration.
    /// </summary>
    public float DurationModifier
    {
        get => _durationModifier;
        set => _durationModifier = value;
    }
}

