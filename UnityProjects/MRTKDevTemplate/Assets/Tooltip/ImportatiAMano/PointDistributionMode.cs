public enum PointDistributionMode
{
    /// <summary>
    /// Don't adjust placement
    /// </summary>
    None = 0,
    /// <summary>
    /// Adjust placement automatically (default)
    /// </summary>
    Auto,
    /// <summary>
    /// Place based on distance
    /// </summary>
    DistanceSingleValue,
    /// <summary>
    /// Place based on curve
    /// </summary>
    DistanceCurveValue,
}
