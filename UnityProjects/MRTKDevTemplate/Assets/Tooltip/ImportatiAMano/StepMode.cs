public enum StepMode
{
    /// <summary>
    /// Draw points based on LineStepCount
    /// </summary>
    Interpolated = 0,
    /// <summary>
    /// Draw only the points available in the source - use this for hard edges
    /// </summary>
    FromSource,
}
