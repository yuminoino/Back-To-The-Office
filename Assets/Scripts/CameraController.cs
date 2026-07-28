using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float MouseSensivity;
    private float rotationX;
    private float rotationY;
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
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        return;
    }

    rotationY += Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime;
    rotationX -= Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime;

    transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
}
}
