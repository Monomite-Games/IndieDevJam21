using UnityEngine;

public class FrontDetection : MonoBehaviour
{
    public PlayerController Player;

    [SerializeField] float RayLength;
    [SerializeField] Transform frontDetectedObject;
    public Transform FrontDetectedObject
    {
        get => frontDetectedObject;
        private set => frontDetectedObject = value;
    }

    [SerializeField] LayerMask InteractLayer;

    private void Update()
    {
        if (!Player.IsInteracting)
        {
            ForwardDetection();
        }
    }

    private void ForwardDetection()
    {
        Vector3 frontPosition = Player.Front.position;
        Vector3 forwardDirection = Player.Front.forward;

        Ray detectorRay = new Ray(frontPosition, forwardDirection);
        RaycastHit detectorRayHit;

        Debug.DrawRay(frontPosition, forwardDirection * RayLength);

        bool hitFound = Physics.Raycast(detectorRay, out detectorRayHit, RayLength, InteractLayer);

        if (hitFound)
        {
            frontDetectedObject = detectorRayHit.transform;
        }
        else
        {
            frontDetectedObject = null;
        }
    }

    public Transform GetFrontDetectedObject()
    {
        return frontDetectedObject;
    }

    public bool CanInteract()
    {
        return frontDetectedObject != null;
    }

    public float GetRayLength()
    {
        return RayLength;
    }
}