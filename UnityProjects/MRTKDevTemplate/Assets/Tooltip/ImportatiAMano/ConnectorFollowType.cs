using System;

[Flags]
public enum ConnectorFollowType
{
    /// <summary>
    /// The anchor will follow the target - pivot remains unaffected
    /// </summary>
    AnchorOnly = 1 << 0,
    /// <summary>
    /// Anchor and pivot will follow target position, but not rotation
    /// </summary>
    Position = 1 << 1,
    /// <summary>
    /// Anchor and pivot will follow target like it's parented, but only on Y axis
    /// </summary>
    PositionAndYRotation = 1 << 2,
    /// <summary>
    /// Anchor and pivot will follow target like it's parented
    /// </summary>
    PositionAndXYRotation = 1 << 3,
}
