/* File GrabbableObject C# implementation of class GrabbableObject */



// global declaration start

using System.Collections.Generic;
using System;
using System.Collections;
using MixedReality.Toolkit;
using UnityEngine;
using MixedReality.Toolkit.SpatialManipulation;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Animations;


// global declaration end

public class GrabbableObject : MonoBehaviour, INodeObject
{
    protected readonly float TRANSFORMATIONS_LERP_TIME = 0.001f;

    public event EventHandler OnGrabbed;
    public event EventHandler OnDropped;

    [SerializeField] private bool twoHandedScaling=false;

    internal bool isGrabbed =  false;

    protected bool farInteraction =  false;
    protected bool physicsEnabled = false;

    protected ObjectManipulator objectManipulator;
    protected ConstraintManager constraintManager;
    protected XRGrabInteractable xrGrabInteractable;
    protected MinMaxScaleConstraint minMaxScaleConstraint;
    protected Rigidbody rigidbody;

    protected Dictionary<ClipId, AudioClip> clips = new Dictionary<ClipId, AudioClip>();
    //protected ToolTip tooltip;
    protected bool isReactive = false;

    public bool FarInteraction
    {
        get => farInteraction;
        set => farInteraction = value;
    }

    public bool PhysicsEnabled
    {
        get => physicsEnabled;
        set
        {
            physicsEnabled = value;
            if (rigidbody == null)
            {
                rigidbody = GetComponent<Rigidbody>();
                if(rigidbody == null)
                    rigidbody = gameObject.AddComponent<Rigidbody>();
            }

            rigidbody.isKinematic = !physicsEnabled;
        }
    }


    protected virtual void Awake()
    {
        objectManipulator = gameObject.AddComponent<ObjectManipulator>();
        Assert.IsNotNull(objectManipulator);

        xrGrabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        Assert.IsNotNull(xrGrabInteractable);

        minMaxScaleConstraint = gameObject.AddComponent<MinMaxScaleConstraint>();
        Assert.IsNotNull(minMaxScaleConstraint);

        constraintManager = GetComponent<ConstraintManager>();
        Assert.IsNotNull(constraintManager);

       TwoHandedScaling(twoHandedScaling);
        UpdateFarInteraction(farInteraction);
        objectManipulator.selectEntered.AddListener(OnManipulationStart);
        objectManipulator.selectExited.AddListener(OnManipulationEnd);


        //tooltip = gameObject.GetComponentInChildren<ToolTip>(true);
        //if (tooltip == null)
        //    Debug.LogWarning("Found draggable " + name + " without a tooltip");

        //EnableTooltip(false);
        SetLerpedTransformations(false);

    }
    private void TwoHandedScaling(bool twoHandedScaling)
    {

        ScaleConstraint scaleConstraint=null;

        scaleConstraint = GetComponent<ScaleConstraint>();
        if (scaleConstraint == null)
        {
            scaleConstraint = gameObject.AddComponent<ScaleConstraint>();
        }

        scaleConstraint.locked = twoHandedScaling;
    }

     public void UpdateFarInteraction(bool enable)
     {
            if (enable)
            {
                xrGrabInteractable.interactionLayers = InteractionLayerMask.NameToLayer("FarInteractable");
            }
            else
            {
                xrGrabInteractable.interactionLayers = 0;
            }
     }
    protected virtual void Start()
    {
        IsReactive = true;
    }

    protected virtual void HandleOnGrabbed()
    {
        OnGrabbed?.Invoke(this, EventArgs.Empty);
        isGrabbed = true;
    }

    protected virtual void HandleOnDropped()
    {
        OnDropped?.Invoke(this, EventArgs.Empty);
        isGrabbed = false;
    }

    protected void OnManipulationStart(SelectEnterEventArgs eventData)
    {
        if (!IsReactive || isGrabbed)
            return;

        HandleOnGrabbed();
    }

    protected void OnManipulationEnd(SelectExitEventArgs eventData)
    {
        if (!IsReactive || !isGrabbed)
            return;

        HandleOnDropped();
    }

    public void DisablePhysicsNextFrame()
    {
        StartCoroutine(DisablePhysics());
    }
    private IEnumerator DisablePhysics()
    {
        yield return new WaitForEndOfFrame();
        PhysicsEnabled = false;
        rigidbody.linearVelocity = Vector3.zero;
        rigidbody.angularDamping = 0f;
    }
    public void SetLerpedTransformations(bool enable)
    {
        float lerpTime = enable ? TRANSFORMATIONS_LERP_TIME : 0f;

        objectManipulator.MoveLerpTime = lerpTime;
        objectManipulator.RotateLerpTime = lerpTime;
        objectManipulator.ScaleLerpTime = lerpTime;
    }
    //TOOLTIP DA IMPORTARE DA MRTK2

    //public void SetTooltip(ObjectTextId objectTextId)
    //{
    //    if(tooltip == null) return;

    //    tooltip.ToolTipText =
    //        LocaleManager.Instance.GetObjectText(GetType().ToString(), objectTextId);
    //}

    public bool IsReactive
    {
        get
        {
            return isReactive;
        }
        set
        {
            isReactive = value;

            objectManipulator.enabled = isReactive;
            constraintManager.enabled = isReactive;
            xrGrabInteractable.enabled = isReactive;
            minMaxScaleConstraint.enabled = isReactive;
        }
    }

    public virtual void EnableTooltip(bool enable)
    {
        //if (tooltip != null)
        //    tooltip.gameObject.SetActive(enable);
        //else
            Debug.LogWarning("no tooltip in draggable " + name);
    }

    public void EnableGraphicalHelpers(bool enable)
    {
        //Nothing to do for this Grabbable
    }
}
