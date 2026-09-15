using UnityEngine;

public class InspectionZone : MonoBehaviour
{
    public Transform InspectionPoint;
    public GameObject InteractionText;

    private bool playerInside;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            InteractionText.SetActive(false);

            ObjectInspection inspection = GetComponent<ObjectInspection>(); // Get the ObjectInspection component attached to this object

            if (inspection != null)
            {
                inspection.PickUp();
                Debug.Log("Picked up the object");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            InteractionText.SetActive(true);

            Debug.Log("Player is next to " + gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            InteractionText.SetActive(false);

            Debug.Log("Player is far from" + gameObject.name);
        }
    }
}