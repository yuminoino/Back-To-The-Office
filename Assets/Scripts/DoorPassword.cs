using UnityEngine;
using TMPro;

public class DoorPassword : MonoBehaviour
{
    public GameObject PasswordWindow;
    public TMP_InputField PasswordInput;
    public Transform TeleportPoint;

    public string Password = "1234";

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
        if (PasswordInput.text == Password)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                CharacterController controller = player.GetComponent<CharacterController>();

                if (controller != null)
                {
                    controller.enabled = false;
                }

                player.transform.position = TeleportPoint.position;
                player.transform.rotation = TeleportPoint.rotation;

                if (controller != null)
                {
                    controller.enabled = true;
                }
            }

            PasswordWindow.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Debug.Log("PASSWORD SBAGLIATA");
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
}