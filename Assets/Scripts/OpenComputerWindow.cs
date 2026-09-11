using UnityEngine;
using TMPro;

public class OpenComputerWindow : MonoBehaviour
{
    public GameObject ComputerWindow;
    public GameObject PasswordWindow;
    public TMP_InputField PasswordInput;
    public TextMeshProUGUI Phrase;
    public string Password;

    public void Open()
    {
        if (PasswordWindow != null)
        {
            PasswordWindow.SetActive(true);
        }
        else
        {
            ComputerWindow.SetActive(true);
        }
    }

    public void CheckPassword()
    {
        if (PasswordInput.text == Password)
        {
            PasswordWindow.SetActive(false);
            ComputerWindow.SetActive(true);
        }
        else
        {
            Phrase.text = "THE END IS NEAR";
        }
    }

    void Update()
    {
        if (PasswordWindow != null && PasswordWindow.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            CheckPassword();
        }
    }
}