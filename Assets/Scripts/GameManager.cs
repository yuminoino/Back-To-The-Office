using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsInspecting;

    public PlayerController PlayerController;
    public CameraController CameraController;
    public GameObject mesh_node;

    void Start()
    {
        Cursor.visible = false;
    }

    public void StartInspection()
    {
        IsInspecting = true;

        PlayerController.enabled = false;
        CameraController.enabled = false;
        mesh_node.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EndInspection()
    {
        IsInspecting = false;

        PlayerController.enabled = true;
        CameraController.enabled = true;
        mesh_node.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (IsInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            ObjectInspection inspection = FindFirstObjectByType<ObjectInspection>();

            if (inspection != null)
            {
                inspection.EndInspection();
            }

            EndInspection();
        }
    }
}