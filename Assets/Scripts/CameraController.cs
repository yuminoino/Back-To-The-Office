using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target; // The target object that the camera will follow (Steve's child lol)
    public float MouseSensivity; 
    private float rotationX;
    private float rotationY;
    private float minVerticalAngle = -20f;
    private float maxVerticalAngle = 45f;
    private float startDelay = 0.2f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotationX = transform.eulerAngles.x; 
        rotationY = transform.eulerAngles.y;
        
    }

    // Update is called once per frame
 void LateUpdate()
{
    transform.position = Target.position;

    if (startDelay > 0)
    {
        startDelay -= Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0); //
        return;
    }

 rotationX -= Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime;

 rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle); // limit the vertical rotation to prevent the camera from flipping over

 rotationY += Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime;

 transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
}
}
