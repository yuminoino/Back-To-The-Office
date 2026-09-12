using UnityEngine;
using TMPro;

public class DoorPassword : MonoBehaviour
{
    public GameObject PasswordWindow;
    public TMP_InputField PasswordInput;

    public string Password1 = "1234";
    public Transform TeleportPoint1;

    public string Password2 = "5678";
    public Transform TeleportPoint2;

    private bool playerInside;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            Open();
        }

        if (PasswordWindow.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            CheckPassword();
        }
    }

    public void Open()
    {
        PasswordWindow.SetActive(true);

        PasswordInput.text = "";
        PasswordInput.ActivateInputField();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CheckPassword()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        Transform destination = null;

        if (PasswordInput.text == Password1)
        {
            destination = TeleportPoint1;
        }
        else if (PasswordInput.text == Password2)
        {
            destination = TeleportPoint2;
        }
        else
        {
            Debug.Log("PASSWORD SBAGLIATA");
            return;
        }

        CharacterController controller = player.GetComponent<CharacterController>();

        if (controller != null)
        {
            controller.enabled = false;
        }

        player.transform.position = destination.position;
        player.transform.rotation = destination.rotation;

        if (controller != null)
        {
            controller.enabled = true;
        }

        PasswordWindow.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
}