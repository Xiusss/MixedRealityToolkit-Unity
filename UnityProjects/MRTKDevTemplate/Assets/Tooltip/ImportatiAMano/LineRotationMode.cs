public enum LineRotationMode
{
    /// <summary>
    /// Don't rotate
    /// </summary>
    None = 0,
    /// <summary>
    /// Use velocity to calculate the line's rotation
    /// </summary>
    Velocity,
    /// <summary>
    /// Rotate relative to direction from origin point
    /// </summary>
    RelativeToOrigin,
}
