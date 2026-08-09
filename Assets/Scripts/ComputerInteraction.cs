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
            OpenComputer();
        }

        if (computerOpen)
        {
            LimitCursor();

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
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
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
        Vector3[] corners = new Vector3[4];
        MonitorArea.GetWorldCorners(corners);

        Vector2 min = RectTransformUtility.WorldToScreenPoint(null, corners[0]);
        Vector2 max = RectTransformUtility.WorldToScreenPoint(null, corners[2]);

        Vector3 mousePosition = Input.mousePosition;

        mousePosition.x = Mathf.Clamp(mousePosition.x, min.x, max.x);
        mousePosition.y = Mathf.Clamp(mousePosition.y, min.y, max.y);

        Cursor.lockState = CursorLockMode.None;

        UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(mousePosition);
    }
}