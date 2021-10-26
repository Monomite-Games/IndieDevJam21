using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InventoryEvents InventoryEvents => InventoryEvents.Instance;

    [SerializeField] private float speed;
    public float Speed
    {
        get => speed;
        private set => speed = value;
    }

    [SerializeField] private Vector2 movementDirection;
    public Vector2 MovementDirection
    {
        get => movementDirection;
        private set => movementDirection = value;
    }

    [SerializeField] private bool isInteracting;
    public bool IsInteracting
    {
        get => isInteracting;
        private set => isInteracting = value;
    }

    [SerializeField] private FrontDetection objectDetection;
    public FrontDetection ObjectDetection
    {
        get => objectDetection;
        private set => objectDetection = value;
    }

    public Transform Front;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movementDirection = new Vector2(h, v);

        if (Input.GetKeyUp(KeyCode.E))
        {
            Interact();
        }
    }

    public bool CanInteract()
    {
        return objectDetection.CanInteract();
    }

    public Transform GetNearestObject()
    {
        return objectDetection.FrontDetectedObject;
    }

    private void Interact()
    {
        Transform interactable = GetNearestObject();

        if (interactable != null && interactable.TryGetComponent<Part>(out Part itemInfo))
        {
            InventoryEvents.RequestAddToInventory(itemInfo);
        }
    }
}