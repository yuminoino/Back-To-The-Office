using UnityEngine;
public class InteractionController : MonoBehaviour
{
    public Camera PlayerCamera;
    public float InteractionDistance = 2f;
    public LayerMask InteractionLayers;

    void Update()
    {
     if (Input.GetKeyDown(KeyCode.E))
    {
        Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 2f);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f))
        {
            Debug.Log("Colpito: " + hit.collider.name);
        }
        else
        {
            Debug.Log("Non ho colpito nulla");
        }
    }
    }
}