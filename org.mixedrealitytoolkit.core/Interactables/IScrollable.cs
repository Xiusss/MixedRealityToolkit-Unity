// Copyright (c) Mixed Reality Toolkit Contributors
// Licensed under the BSD 3-Clause

using UnityEngine;


namespace MixedReality.Toolkit
{
    /// <summary>
    /// A Unity <see href="https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit%402.3/api/UnityEngine.XR.Interaction.Toolkit.IXRInteractable.html">IXRInteractable</see>
    /// that is capable of being scrolled by a Unity <see href="https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit%402.3/api/UnityEngine.XR.Interaction.Toolkit.IXRInteractor.html">IXRInteractor</see>.
    /// </summary>
    public interface IScrollable : UnityEngine.XR.Interaction.Toolkit.Interactables.IXRInteractable
    {
        /// <summary>
        /// Get the transform that is backing this scrollable region.
        /// </summary>
        Transform ScrollableTransform { get; }

        /// <summary>
        /// Get if the <see cref="ScrollableTransform"/> is currently being scrolled or moved.
        /// </summary>
        bool IsScrolling { get; }

        /// <summary>
        /// Get the Unity <see href="https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit%402.0/api/UnityEngine.XR.Interaction.Toolkit.IXRInteractor.html">IXRInteractor</see>
        /// that is scrolling or will scroll the specified <see cref="ScrollableTransform"/>.
        /// </summary>
        UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor ScrollingInteractor { get; }

        /// <summary>
        /// Get the local position of <see cref="ScrollingInteractor"/> at the start of the scroll operation.
        /// </summary>
        Vector3 ScrollingLocalAnchorPosition { get; }
    }
}
