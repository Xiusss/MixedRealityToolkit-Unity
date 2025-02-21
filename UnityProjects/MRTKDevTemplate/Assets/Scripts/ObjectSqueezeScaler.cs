using MixedReality.Toolkit.SpatialManipulation;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class ObjectSqueezeScaler : MonoBehaviour
{
    public MixedReality.Toolkit.Input.GrabInteractor grabInteractor; // The hand interacting with the object


    private ObjectManipulator objectManipulator;
    private Vector3 initialHandPosition; // The hand position when the interaction starts
    private Vector3 initialScale; // The initial scale of the object

    private bool neutral = true;
    void Start()
    {
        if (objectManipulator == null)
        {
            objectManipulator = GetComponent<ObjectManipulator>();
            Assert.IsNotNull(objectManipulator);
        }
        float lerpSpeed = 0.1f;

        objectManipulator.selectEntered.AddListener(Squeeze);
        objectManipulator.selectExited.AddListener(Unsqueeze);

        // Save the initial scale of the object
        initialScale = transform.localScale;
    }

    public void Squeeze(SelectEnterEventArgs args=null)
    {
        neutral = true;
        this.transform.localScale = initialScale*0.2f;
    }

    public void Unsqueeze(SelectExitEventArgs args=null)
    {
        neutral = false;
        float lerpSpeed = 0.1f; // Adjust this value for the speed of interpolation
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, initialScale, lerpSpeed);
    }

    private void Update()
    {
        if (!neutral && this.transform.localScale != initialScale)
        {
            Unsqueeze();
        }
    }
}
