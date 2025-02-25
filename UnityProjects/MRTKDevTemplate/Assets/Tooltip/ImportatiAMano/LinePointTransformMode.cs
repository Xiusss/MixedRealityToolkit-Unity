public enum LinePointTransformMode
{
    /// <summary>
    /// Use the local line transform. More reliable but with a performance cost.
    /// </summary>
    UseTransform,
    /// <summary>
    /// Use a matrix. Lines that are not active and enabled will not update point positions.
    /// </summary>
    UseMatrix,
}
