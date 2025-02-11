using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagValveMask : GrabbableObject
{
    public event EventHandler<EventArgs> Squeezed; 
    private bool backToNeutral = true; // Ensure it starts in neutral state
    private bool hasSqueezed = false;  // Tracks if the event has been triggered for the current squeeze

    [SerializeField] private GameObject squeezablePart;
    [SerializeField] private Vector3 maxSqueezeScale;

    protected override void Awake()
    {
        base.Awake();
        //tooltip.ToolTipText = LocaleManager.Instance.GetObjectText("BagValveMask", ObjectTextId.Tooltip);
        PhysicsEnabled = false;
    }

    protected void Update()
    {
        float squeezeAmount = Input.GetAxis("AXIS_1");

        // Check if the user has returned to neutral state
        if (squeezeAmount < 0.1f)
        {  // Patient.Instance.SetChestUp(false);
            backToNeutral = true;
            hasSqueezed = false; // Allow squeezing again when returning to neutral
        }

        // If in editor, handle squeezing logic
        // if (Application.isEditor)
        // {
            if (squeezeAmount > 0.1f)
            {  // Patient.Instance.SetChestUp(true);
                Squeeze(squeezeAmount);
                Debug.Log(squeezeAmount);
                
            }
            
        //}
    }

    public void Squeeze(float amount)
    {        

        // Trigger the event only once per squeeze when transitioning out of neutral
        if (backToNeutral && amount > 0.1f && !hasSqueezed)
        {
            Squeezed?.Invoke(this, EventArgs.Empty);
            hasSqueezed = true; // Mark the squeeze event as triggered
        }

        squeezablePart.transform.localScale = Vector3.Lerp(Vector3.one, maxSqueezeScale, amount);
    }
}
