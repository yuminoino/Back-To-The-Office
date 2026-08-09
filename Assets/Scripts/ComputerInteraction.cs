using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject ComputerUI;
    public Transform CameraPoint;
    public Camera PlayerCamera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        PlayerCamera.transform.position = CameraPoint.position;
        PlayerCamera.transform.rotation = CameraPoint.rotation;

        ComputerUI.SetActive(true);
    }
}
