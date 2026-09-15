using UnityEngine;

public class ObjectInspection : MonoBehaviour
{
    public Transform InspectionPoint; // The point where the object will be inspected
    public GameObject DialogueObject;
    public float RotationSpeed = 100f;
    public float ZoomSpeed = 2f;

    private bool isInspecting; // Check if the object is being inspected

    private Transform originalParent; // The original parent of the object before inspection
    private Vector3 originalPosition; // The original position of the object before inspection
    private Quaternion originalRotation; // The original rotation of the object before inspection

    public void PickUp()
    {
        originalParent = transform.parent; // Save the original parent of the object
        originalPosition = transform.position; // Save the original position of the object
        originalRotation = transform.rotation; // Save the original rotation of the object

        transform.SetParent(InspectionPoint); // Inspection point as the new parent
        transform.localPosition = Vector3.zero; // Reset local position to zero to align with the inspection point
        transform.localRotation = Quaternion.identity; // The object's rotation is reset to match the inspection point's rotation

        if (DialogueObject != null)
        {
            DialogueObject.SetActive(true);
        }

        GameManager gameManager = FindFirstObjectByType<GameManager>(); // Find the GameManager in the scene

        if (gameManager != null) // Wthout this this the object remains on Steve
        {
            gameManager.StartInspection(this); // Because the object is being inspected, we notify the GameManager to handle the inspection state
        }

        isInspecting = true;
    }

    private void Update()
    {
        if (!isInspecting) 
            return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, -mouseX * RotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, mouseY * RotationSpeed * Time.deltaTime, Space.Self);

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.localPosition;
        position.z -= scroll * ZoomSpeed;

        position.z = Mathf.Clamp(position.z, -1f, 0f); // Limit the zoom to prevent the object from going too far away or too close

        transform.localPosition = position;
    }

    public void EndInspection()
    {
        isInspecting = false;

        if (DialogueObject != null)
        {
            DialogueObject.SetActive(false);
        }

        transform.SetParent(originalParent);
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}