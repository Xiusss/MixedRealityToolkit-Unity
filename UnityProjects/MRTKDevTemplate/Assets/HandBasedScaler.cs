using UnityEngine;
using UnityEngine.XR.Hands;
using MixedReality.Toolkit;
using System;
using System.Collections.Generic;
using Handedness = UnityEngine.XR.Hands.Handedness;

using UnityEngine.XR.Hands.Gestures;
using UnityEngine.XR.Interaction.Toolkit;
using XRController = UnityEngine.InputSystem.XR.XRController;


//A UNIFORM SCALED OBJECT IS ASSUMED. THE TRASNFORMATIONS ARE BASED ON THE LOCALSCALE.X VALUE
public class HandBasedScaler :MonoBehaviour
{
    [SerializeField]
    [Tooltip("The handedness to get the finger states for.")]
    Handedness m_Handedness;

    public Transform targetObject; // Assign in Inspector
    private float initialDistance;
    private Vector3 initialScale;
    private bool isPinching = false;
    static List<XRHandSubsystem> s_SubsystemsReuse = new List<XRHandSubsystem>();

    public GameObject HandGameObject;
    [SerializeField] XRController rightHand;
    [SerializeField] XRController leftHand;
    private bool toNeutral = true;

    private void Start()
    {

        initialScale = targetObject.localScale;
    }

    void Update()
    {
        if (transform.localScale.magnitude - initialScale.magnitude<0.01f && toNeutral)
        {
            Unsqueeze();
        }

       // XRFingerShapeMath.CalculateFingerShape(hand, XRHandFingerID.Index, XRFingerShapeTypes.Pinch);
         // if (shapes.TryGetPinch(out var pinch))
         //    XRFingerShapeDetector.SetFingerShape((int)XRFingerShapeType.Pinch, pinch);
    }

    public void SetFingerShape()
    {
        var subsystem = TryGetSubsystem();
        if (subsystem == null)
            return;

        var hand = m_Handedness == Handedness.Left ? subsystem.leftHand : subsystem.rightHand;
        // XRFingerShapeMath.CalculateFingerShape(hand, XRHandFingerID.Index, XRFingerShapeTypes.Pinch)
        //     .TryGetPinch(out var pinch);

        // if (XRFingerShapeMath.CalculateFingerShape(hand, XRHandFingerID.Index, XRFingerShapeTypes.FullCurl).TryGetFullCurl(out var fullCurl))
        //     ChangeScale(fullCurl);
        // else
        //     graph.HideFingerShape((int)XRFingerShapeType.FullCurl);

        // if (XRFingerShapeMath.CalculateFingerShape(hand, XRHandFingerID.Index, XRFingerShapeTypes.BaseCurl)
        //     .TryGetBaseCurl(out var baseCurl))
        //     ChangeScale(baseCurl);
        // // else
        // //     graph.HideFingerShape((int)XRFingerShapeType.BaseCurl);
        //
        if (XRFingerShapeMath.CalculateFingerShape(hand, XRHandFingerID.Index, XRFingerShapeTypes.TipCurl)
            .TryGetTipCurl(out var tipCurl) && tipCurl>0f)
             ChangeScale(tipCurl);
        else toNeutral = true;
        //    else
        //     // graph.HideFingerShape((int)XRFingerShapeType.TipCurl);
        //
        // if (XRFingerShapeMath.CalculateFingerShape(hand, XRHandFingerID.Index, XRFingerShapeTypes.Pinch)
        //     .TryGetPinch(out var pinch))
        //     ChangeScale(pinch);      //  else
        //     // graph.HideFingerShape((int)XRFingerShapeType.Pinch);
        //
        // if (XRFingerShapeMath.CalculateFingerShape(hand, XRHandFingerID.Index, XRFingerShapeTypes.Spread)
        //     .TryGetSpread(out var spread))
        //      ChangeScale(spread);    //    else
        //     // graph.HideFingerShape((int)XRFingerShapeType.Spread);
        // ChangeScale(spread);
    }

    public void Unsqueeze(SelectExitEventArgs args=null)
    {
        float lerpSpeed = 0.1f; // Adjust this value for the speed of interpolation
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, initialScale, lerpSpeed);
    }

    public void ChangeScale(float newScale)
    {
        newScale = Mathf.Max((initialScale.x - newScale), 0.2f*initialScale.x);
        targetObject.localScale = new Vector3(newScale, newScale, newScale);
        Debug.Log("New Scale: " + newScale+", initial "+initialScale.x);
        toNeutral = false;
    }


    private void OnTriggerStay(Collider other)
    {
        SetFingerShape();

    }

    private XRHandSubsystem TryGetSubsystem()
    {
        SubsystemManager.GetSubsystems(s_SubsystemsReuse);
        return s_SubsystemsReuse.Count > 0 ? s_SubsystemsReuse[0] : null;
    }
}
