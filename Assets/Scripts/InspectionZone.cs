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

            ObjectInspection inspection = GetComponent<ObjectInspection>();

            if (inspection != null)
            {
                inspection.PickUp();
                Debug.Log("OGGETTO PRESO");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            InteractionText.SetActive(true);

            Debug.Log("PLAYER È VICINO A " + gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            InteractionText.SetActive(false);

            Debug.Log("PLAYER SI È ALLONTANATO DA " + gameObject.name);
        }
    }
}