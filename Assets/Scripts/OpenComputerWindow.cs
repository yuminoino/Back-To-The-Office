using UnityEngine;
using TMPro;

public class OpenComputerWindow : MonoBehaviour
{
    public GameObject ComputerWindow;
    public GameObject PasswordWindow;
    public TMP_InputField PasswordInput;
    public TextMeshProUGUI Phrase;

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
        if (PasswordInput.text == "brave")
        {
            PasswordWindow.SetActive(false);
            ComputerWindow.SetActive(true);
        }
        else if (PasswordInput.text == "WDMHFSB?")
        {
            PasswordWindow.SetActive(false);
            GameObject.Find("ComputerWindow_User02").SetActive(true);
        }
        else if (PasswordInput.text == "remember")
        {
            PasswordWindow.SetActive(false);
            GameObject.Find("ComputerWindow_User03").SetActive(true);
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