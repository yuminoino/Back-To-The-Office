using UnityEngine;

public class ProximitySound : MonoBehaviour
{
    public AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.Play();
        }
    }
}