using UnityEngine;

public class InspectionZone : MonoBehaviour
{
    public Transform InspectionPoint;

    private bool playerInside;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            transform.SetParent(InspectionPoint);

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            Debug.Log("MATITA PRESA");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("PLAYER È VICINO ALLA MATITA");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("PLAYER SI È ALLONTANATO");
        }
    }
}