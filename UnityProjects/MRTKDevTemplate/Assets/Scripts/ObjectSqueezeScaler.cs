using UnityEngine;


public class ObjectSqueezeScaler : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // The object that can be grabbed
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor handInteractor; // The hand interacting with the object

    private Vector3 initialHandPosition; // The hand position when the interaction starts
    private Vector3 initialScale; // The initial scale of the object

    void Start()
    {
        if (grabInteractable == null)
        {
            grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        }

        // Save the initial scale of the object
        initialScale = transform.localScale;
    }

    void Update()
    {
       
        // Track the current position of the hand
        Vector3 currentHandPosition = handInteractor.transform.position;

        // Calculate the distance moved by the hand along the relevant axis (e.g., Z-axis for squeezing)
        float distanceMoved = currentHandPosition.z - initialHandPosition.z;

        // Scale the object based on how much the hand has moved
        if (Mathf.Abs(distanceMoved) > 0.1f) // Threshold to prevent small jitter
        {
            float scaleFactor = 1 + distanceMoved * 0.1f; // Adjust the factor for desired scaling speed

            // Apply scaling to the object along the relevant axis (e.g., Z-axis)
            transform.localScale = initialScale * scaleFactor;
        }

        // Update initial hand position to continue tracking
        initialHandPosition = currentHandPosition;
        
    }

    // When grabbing the object, set the initial hand position
    public void OnGrab()
    {
        initialHandPosition = handInteractor.transform.position;
    }
}
