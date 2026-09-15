using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject ComputerUI;

    public PlayerController PlayerController;
    public CameraController CameraController;

    public RectTransform MonitorArea;

    private bool playerInside;
    private bool computerOpen;

    void Update()
    {
        if (playerInside && !computerOpen && Input.GetKeyDown(KeyCode.E))
        {
            OpenComputer(); //activate the computer UI and disable player controls
        }

        if (computerOpen)
        {
            LimitCursor(); //Limit the cursor to the monitor area

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseComputer();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true; //Set the playerInside flag when the player enters the trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false; //Reset the playerInside flag when the player exits the trigger
        }
    }

    private void OpenComputer()
    {
        ComputerUI.SetActive(true);

        PlayerController.enabled = false;
        CameraController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        computerOpen = true;
    }

    private void CloseComputer()
    {
        ComputerUI.SetActive(false);

        PlayerController.enabled = true;
        CameraController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        computerOpen = false;
    }

    private void LimitCursor()
    {
        Vector3[] corners = new Vector3[4]; // Array to hold the corners of the RectTransform
        MonitorArea.GetWorldCorners(corners); // Get the coordinates of the corners in world space

        Vector2 min = RectTransformUtility.WorldToScreenPoint(null, corners[0]); // Convert the bottom-left corner to screen space and not world space. Null because of no camera is needed for this conversion
        Vector2 max = RectTransformUtility.WorldToScreenPoint(null, corners[2]); // Convert the top-right corner to screen space

        Vector3 mousePosition = Input.mousePosition; 

        mousePosition.x = Mathf.Clamp(mousePosition.x, min.x, max.x); // Clamp the mouse position to the bounds of the monitor area!!
        mousePosition.y = Mathf.Clamp(mousePosition.y, min.y, max.y); // Clamp the mouse position to the bounds of the monitor area!!

        Cursor.lockState = CursorLockMode.None;

        UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(mousePosition); // Set the cursor position in a fancy way
    }
}