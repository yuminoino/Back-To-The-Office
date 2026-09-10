using UnityEngine;

public class ObjectInspection : MonoBehaviour
{
    public Transform InspectionPoint;

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
    }
}