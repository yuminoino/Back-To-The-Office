using UnityEngine;

public class InspectionController : MonoBehaviour
{
    public Camera PlayerCamera;
    public float InteractionDistance = 3f;
    void Update()
{
    Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, InteractionDistance))
    {
        Debug.Log("Colpito: " + hit.collider.name);

        if (Input.GetKeyDown(KeyCode.E))
        {
            ObjectInspection inspection = hit.collider.GetComponent<ObjectInspection>();

            if (inspection != null)
            {
                Debug.Log("ObjectInspection trovato!");
                inspection.PickUp();
            }
        }
    }
}
}