using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public Camera PlayerCamera;
    public float InteractionDistance = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);

            Debug.DrawRay(ray.origin, ray.direction * InteractionDistance, Color.red, 2f);

            if (Physics.Raycast(ray, out RaycastHit hit, InteractionDistance))
            {
                Debug.Log("Colpito: " + hit.collider.name);

                if (hit.collider.CompareTag("Inspectable"))
                {
                    Debug.Log("Interazione!");
                }
            }
            else
            {
                Debug.Log("Nessun oggetto colpito");
            }
        }
    }
}