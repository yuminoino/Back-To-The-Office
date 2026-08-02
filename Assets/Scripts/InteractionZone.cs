using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    public GameObject InteractionText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionText.SetActive(false);
        }
    }
}