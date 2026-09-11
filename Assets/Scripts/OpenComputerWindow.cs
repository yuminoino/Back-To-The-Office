using UnityEngine;
using TMPro;

public class OpenComputerWindow : MonoBehaviour
{
    public GameObject ComputerWindow;
    public GameObject PasswordWindow;
    public TMP_InputField PasswordInput;
    public TextMeshProUGUI Phrase;

    private string password = "brave";
    private string password2 = "WDMHFSB?";
    private string password3 = "remember";

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
        if (PasswordInput.text == password)
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