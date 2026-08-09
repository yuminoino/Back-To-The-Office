using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject ComputerUI;
    public Transform CameraPoint;
    public Camera PlayerCamera;

    public PlayerController PlayerController;
    public CameraController CameraController;

    public RectTransform MonitorArea;

    private bool playerInside;
    private bool computerOpen;

    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;

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
        originalCameraPosition = PlayerCamera.transform.position;
        originalCameraRotation = PlayerCamera.transform.rotation;

        PlayerCamera.transform.position = CameraPoint.position;
        PlayerCamera.transform.rotation = CameraPoint.rotation;

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

        PlayerCamera.transform.position = originalCameraPosition;
        PlayerCamera.transform.rotation = originalCameraRotation;

        PlayerController.enabled = true;
        CameraController.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

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