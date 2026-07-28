using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float MouseSensivity;
    private float rotationX;
    private float rotationY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position;

        rotationY += Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime;
        rotationX -= Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}
