using UnityEngine;
using TMPro;

public class NoteManager : MonoBehaviour
{
    public TMP_InputField NoteInput;

    void Start()
    {
        NoteInput.text = PlayerPrefs.GetString("SavedNote", "");
        NoteInput.onValueChanged.AddListener(SaveNote);
    }

    void SaveNote(string text)
    {
        PlayerPrefs.SetString("SavedNote", text);
        PlayerPrefs.Save();
    }
}