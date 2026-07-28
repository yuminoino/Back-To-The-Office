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
     float horizontalInput = Input.GetAxis("Horizontal");
     float verticalInput = Input.GetAxis("Vertical");

     Vector3 forward = CameraTransform.forward;
     Vector3 right = CameraTransform.right;

     forward.y = 0;
     right.y = 0;

     forward.Normalize();
     right.Normalize();

     Vector3 movement = forward * verticalInput + right * horizontalInput;

     bool isMoving = horizontalInput != 0 || verticalInput != 0;
     bool isRunning = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && isMoving;

     animator.SetFloat("Speed", movement.magnitude);
     
     animator.SetBool("isRunning", isRunning);

    if (movement != Vector3.zero)
    {
     Quaternion targetRotation = Quaternion.LookRotation(movement);

     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }

    float currentSpeed = isRunning ? RunSpeed : Speed;

    controller.Move(movement * currentSpeed * Time.deltaTime);
    }
}
