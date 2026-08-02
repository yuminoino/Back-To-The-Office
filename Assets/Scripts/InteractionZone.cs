using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    public GameObject InteractionText;
    public GameObject DialogueObject;

    private bool playerInside;

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            InteractionText.SetActive(false);
            DialogueObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            InteractionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            InteractionText.SetActive(false);
            DialogueObject.SetActive(false);
        }
    }
}