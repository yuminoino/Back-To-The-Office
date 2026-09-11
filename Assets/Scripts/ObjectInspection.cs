using UnityEngine;

public class ObjectInspection : MonoBehaviour
{
    public Transform InspectionPoint;
    public float RotationSpeed = 100f;

    private bool isInspecting;

    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public void PickUp()
    {
        originalParent = transform.parent;
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        transform.SetParent(InspectionPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.StartInspection();
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
    }

    public void EndInspection()
    {
        isInspecting = false;

        transform.SetParent(originalParent);
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}