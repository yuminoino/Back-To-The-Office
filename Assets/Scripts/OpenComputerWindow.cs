using UnityEngine;
using TMPro;

public class OpenComputerWindow : MonoBehaviour
{
    public GameObject ComputerWindow;
    public GameObject PasswordWindow;
    public TMP_InputField PasswordInput;
    public TextMeshProUGUI Phrase;

    private string password = "brave";

    public void Open()
    {
        PasswordWindow.SetActive(true);
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
        if (PasswordWindow.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            CheckPassword();
        }
    }
}