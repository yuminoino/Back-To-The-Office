using UnityEngine;
using TMPro;

public class NoteManager : MonoBehaviour
{
    public TMP_InputField NoteInput;

    void Start()
    {
        NoteInput.text = PlayerPrefs.GetString("SavedNote", ""); // Load saved note if it exists
        NoteInput.onValueChanged.AddListener(SaveNote); // Save note whenever the text changes
    }

    void SaveNote(string text) //get the text from the input field and save it to PlayerPrefs
    {
        PlayerPrefs.SetString("SavedNote", text); // Save the note to PlayerPrefs
        PlayerPrefs.Save(); // Ensure the data is written to disk
    }
}