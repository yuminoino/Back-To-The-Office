using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 3.0f;
    public float RunSpeed = 7f;
    public float RotationSpeed = 10f;
    public Transform CameraTransform; 

    private Animator animator;
    private CharacterController controller;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
     float horizontalInput = Input.GetAxis("Horizontal"); // Get the horizontal input (A/D or Left/Right arrow keys)
     float verticalInput = Input.GetAxis("Vertical"); // Get the vertical input (W/S or Up/Down arrow keys)

     Vector3 forward = CameraTransform.forward; // Get the forward direction of the camera. Move the player in the direction of the camera's forward vector
     Vector3 right = CameraTransform.right; // Get the right direction of the camera. Move the player in the direction of the camera's right vector

     forward.y = 0;
     right.y = 0;

     forward.Normalize(); // Don't want the player to move up or down
     right.Normalize(); // Don't want the player to move up or down

     Vector3 movement = forward * verticalInput + right * horizontalInput; // Calculate the movement vector based on the input and camera direction

     bool isMoving = horizontalInput != 0 || verticalInput != 0; // Check if the player is moving based on the input
     bool isRunning = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && isMoving; // Check if the player is running based on the input and movement

     animator.SetFloat("Speed", movement.magnitude); // Set the Speed parameter in the Animator to the magnitude of the movement vector

     animator.SetBool("isRunning", isRunning); // Say if the player is running or not based on the input and movement


     if (movement != Vector3.zero) // If the player is moving, rotate the player to face the direction of movement
     {

     Quaternion targetRotation = Quaternion.LookRotation(movement); // Calculate the target rotation based on the movement vector

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime); // Smoothly rotate the player towards the target rotation based on the RotationSpeed and Time.deltaTime
        }

        float currentSpeed;

        if (isRunning)
        {
            currentSpeed = RunSpeed;
        }
        else
        {
            currentSpeed = Speed;
        }

        controller.Move(movement * currentSpeed * Time.deltaTime);
    }
}
