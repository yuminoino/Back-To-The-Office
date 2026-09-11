using UnityEngine;

public class InspectionZone : MonoBehaviour
{
    public Transform InspectionPoint;

    private bool playerInside;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            ObjectInspection inspection = GetComponent<ObjectInspection>();

            if (inspection != null)
            {
                inspection.PickUp();
                Debug.Log("MATITA PRESA");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("PLAYER È VICINO A" + gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("PLAYER SI È ALLONTANATO DA" + gameObject.name);
        }
    }
}