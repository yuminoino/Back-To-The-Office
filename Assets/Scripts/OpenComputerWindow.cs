using UnityEngine;
using TMPro;

public class OpenComputerWindow : MonoBehaviour
{
    public GameObject ComputerWindow;
    public GameObject PasswordWindow;
    public TMP_InputField PasswordInput;

    private string Password = "brave";

    public void Open()
    {
        PasswordWindow.SetActive(true);
    }

    public void CheckPassword()
    {
        if (PasswordInput.text == Password)
        {
            PasswordWindow.SetActive(false);
            ComputerWindow.SetActive(true);
        }
    }
}