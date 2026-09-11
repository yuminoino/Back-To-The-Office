using UnityEngine;

public class ObjectInspection : MonoBehaviour
{
    public Transform InspectionPoint;
    public float RotationSpeed = 100f;
    public float ZoomSpeed = 2f;

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

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.localPosition;
        position.z -= scroll * ZoomSpeed;

        position.z = Mathf.Clamp(position.z, -1f, 0f);

        transform.localPosition = position;
    }

    public void EndInspection()
    {
        isInspecting = false;

        transform.SetParent(originalParent);
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}