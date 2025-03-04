// Copyright (c) Mixed Reality Toolkit Contributors
// Licensed under the BSD 3-Clause

using System.Collections.Generic;
using UnityEngine;


namespace MixedReality.Toolkit.SpatialManipulation
{
    /// <summary>
    /// Abstract class defining all logics that define the logic by which an object
    /// is manipulated by a <see cref="ObjectManipulator"/> object.
    /// </summary>
    /// <remarks>
    /// When a manipulation starts, call <see cref="Setup"/>. Then call <see cref="Update"/>
    /// any time to update the move logic and get a new target value for the object.
    /// </remarks>
    public abstract class ManipulationLogic<T>
    {
        /// <summary>
        /// The number of <see cref="IXRSelectInteractor"/> objects currently selecting this object.
        /// </summary>
        protected int NumInteractors { get; private set; }

        /// <summary>
        /// Whether the object is selected by a singular <see cref="XRSocketInteractor"/>.
        /// </summary>
        protected bool SelectedBySocket { get; private set; }

        /// <summary>
        /// Whether the object is force grabbed by a singular <see cref="XRRayInteractor"/>.
        /// </summary>
        protected bool ForceGrabbed { get; private set; }

        /// <summary>
        /// Setup the manipulation logic. Called automatically by Update if the number of interactor points has changed.
        /// </summary>
        /// <param name="interactors">
        /// List of all <see cref="IXRSelectInteractor"/> objects selecting this object.
        ///</param>
        /// <param name= "interactable">
        /// The <see cref="IXRSelectInteractable"/> that is being manipulated.
        /// </param>
        /// <param name= "currentTarget">
        /// The current manipulation target position/rotation/scale. This is the shared target that each ManipulationLogic modifies.
        /// The result from Update will be applied to this transform by the ObjectManipulator, in the order of Scale, Rotate, Move.
        /// </param>
        public virtual void Setup(List<UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor> interactors, UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable, MixedRealityTransform currentTarget)
        {
            NumInteractors = interactors.Count;
            SelectedBySocket = NumInteractors == 1 && interactors[0] is UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor;
            ForceGrabbed = NumInteractors == 1 && interactors[0] is UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor && rayInteractor.useForceGrab;
        }

        /// <summary>
        /// Calculate the new manipulation result, of type T, based on input. If the number of interactor points is
        /// different than the last time Update was called, Setup will be called automatically to re-initialize the manipulation.
        /// </summary>
        /// <param name="interactors">
        /// List of all <see cref="IXRSelectInteractor"/> objects selecting this object.
        ///</param>
        /// <param name= "interactable">
        /// The <see cref="IXRSelectInteractable"/> that is being manipulated.
        /// </param>
        /// <param name= "currentTarget">
        /// The current manipulation target position/rotation/scale. This is the shared target that each ManipulationLogic modifies.
        /// The result from Update will be applied to this transform by the ObjectManipulator, in the order of Scale, Rotate, Move.
        /// </param>
        /// <param name= "centeredAnchor">
        /// Should the manipulationLogic anchor the object around its center, or around the manipulation?
        /// </param>
        public virtual T Update(List<UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor> interactors, UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable, MixedRealityTransform currentTarget, bool centeredAnchor)
        {
            Debug.Assert(interactors.Count != 0, "ManipulationLogic.Update called with zero interactors.");

            if (interactors.Count != NumInteractors)
            {
                Setup(interactors, interactable, currentTarget);
            }

            return default;
        }
    }
}
