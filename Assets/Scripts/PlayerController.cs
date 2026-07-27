using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float runSpeed = 10f;
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     float horizontalInput = Input.GetAxis("Horizontal");
     float verticalInput = Input.GetAxis("Vertical");

     Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

     bool isMoving = horizontalInput != 0 || verticalInput != 0;
     bool isRunning = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && isMoving;

     animator.SetFloat("Speed", movement.magnitude);
     animator.SetBool("isWalking", isMoving);
     animator.SetBool("isRunning", isRunning);

    if (movement != Vector3.zero)
    {
     transform.rotation = Quaternion.LookRotation(movement);
    }

    float currentSpeed = isRunning ? runSpeed : speed;

    transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);
    }
}
