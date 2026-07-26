using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
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
        animator.SetFloat("Speed", movement.magnitude);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
    
        }
         transform.Translate(movement * speed * Time.deltaTime, Space.World); 
    }
}
