using System.Collections.Generic;
using System;
using System.Collections;
using MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;
using MixedReality.Toolkit.SpatialManipulation;
using MixedReality.Toolkit.UX;

public class GrabbableObject : MonoBehaviour, INodeObject
{
    [SerializeField] private bool twoHandedScaling=false;

    protected readonly float TRANSFORMATIONS_LERP_TIME = 0.001f;

    public event EventHandler OnGrabbed;
    public event EventHandler OnDropped;

    internal bool isGrabbed =  false;

    protected bool farInteraction =  false;
    protected bool physicsEnabled = false;

    protected ObjectManipulator objectManipulator;
    protected ConstraintManager constraintManager;
    //protected XRGrabInteractable xrGrabInteractable;
    protected MinMaxScaleConstraint minMaxScaleConstraint;
    protected UGUIInputAdapterDraggable uGUIInputAdapterDraggable;
    protected Rigidbody rigidbody;

    protected Dictionary<ClipId, AudioClip> clips = new Dictionary<ClipId, AudioClip>();
    //TODO [Tooltip]
    protected ToolTip tooltip;
    protected bool isReactive = false;

    public bool FarInteraction
    {
        get => farInteraction;
        set
        {
            if (objectManipulator == null)
            {
                Debug.LogError($"Setting FarInteraction property to {value} on grabbable: {gameObject.name} but no objectManipulator attached.");
                return;
            }

            farInteraction = value;
            if (farInteraction)
                objectManipulator.AllowedInteractionTypes |= InteractionFlags.Ray;
            else
                objectManipulator.AllowedInteractionTypes &= ~InteractionFlags.Ray;

        }
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

        uGUIInputAdapterDraggable = gameObject.AddComponent<UGUIInputAdapterDraggable>();
        Assert.IsNotNull(uGUIInputAdapterDraggable);

        //xrGrabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        //Assert.IsNotNull(xrGrabInteractable);

        minMaxScaleConstraint = gameObject.AddComponent<MinMaxScaleConstraint>();
        Assert.IsNotNull(minMaxScaleConstraint);

        constraintManager = GetComponent<ConstraintManager>();
        Assert.IsNotNull(constraintManager);


        objectManipulator.AllowedManipulations &= ~TransformFlags.Scale; // use &= ~ to remove undesired action
        FarInteraction = farInteraction;

        objectManipulator.selectEntered.AddListener(OnManipulationStart);
        objectManipulator.selectExited.AddListener(OnManipulationEnd);


        tooltip = gameObject.GetComponentInChildren<ToolTip>(true);
        if (tooltip == null)
            Debug.LogWarning("Found draggable " + name + " without a tooltip");

        EnableTooltip(true);
        SetLerpedTransformations(false);

    }

    protected virtual void Start()
    {
        IsReactive = true;
    }

    protected virtual void HandleOnGrabbed()
    {
        OnGrabbed?.Invoke(this, EventArgs.Empty);
        isGrabbed = true;
        EnableTooltip(false);

    }

    protected virtual void HandleOnDropped()
    {
        OnDropped?.Invoke(this, EventArgs.Empty);
        isGrabbed = false;
    }

    protected void OnManipulationStart(SelectEnterEventArgs eventData)
    {
        EnableTooltip(false);

        if (!IsReactive || isGrabbed)
            return;
        HandleOnGrabbed();
    }

    protected void OnManipulationEnd(SelectExitEventArgs eventData)
    {
        EnableTooltip(true);

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

    public void SetTooltip(ObjectTextId objectTextId)
    {
        if(tooltip == null) return;
        tooltip.ToolTipText = LocaleManager.Instance.GetObjectText(GetType().ToString(), objectTextId);
    }

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

            EnableTooltip(isReactive);
            minMaxScaleConstraint.enabled = isReactive;
        }
    }

    public virtual void EnableTooltip(bool enable)
    {

        if (tooltip != null)
            tooltip.gameObject.SetActive(enable);
        else
            Debug.LogWarning("no tooltip in draggable " + name);
    }

    public void EnableGraphicalHelpers(bool enable)
    {
        //Nothing to do for this Grabbable
    }
}
