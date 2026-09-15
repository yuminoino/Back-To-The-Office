using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseCanvas;
    public PlayerController PlayerController;
    public CameraController CameraController;

    private bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                Resume(); // Resume the game if it is currently paused
            }
            else
            {
                Pause(); // Pause the game if it is currently running
            }
        }
    }

    public void Pause()
    {
        isPaused = true;

        PauseCanvas.SetActive(true);

        PlayerController.enabled = false;
        CameraController.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        isPaused = false;

        PauseCanvas.SetActive(false);

        PlayerController.enabled = true;
        CameraController.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }
}