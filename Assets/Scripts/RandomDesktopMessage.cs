using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RandomDesktopMessage : MonoBehaviour
{
    public TextMeshProUGUI RandomText;

    public string[] Messages =
    {
        "DON'T bE PESSIMISTIC!",
        "YOU HAVE A FRIEND HERE",
        "YOU SEE EVERYTHING IN GRaY",
        "vOID",
        "YOU CAN'T EXIT",
        "HELLO?",
        "CAN YOU HEAR Me?",
        "I MISS WHO I USED TO BE",
        "THIS PLACE IS STILL HErE. THEY AREN'T",
        "NOT NOW"
    };

    private List<string> availableMessages; // List to keep track of available messages

    void Start()
    {
        availableMessages = new List<string>(Messages); // Create a new list with the initial messages
    }

    public void ShowRandomMessage()
    {
        if (availableMessages.Count == 0) // If all messages have been shown, reset the list
        {
            availableMessages = new List<string>(Messages); // Reset the list to the original messages
        }

        int random = Random.Range(0, availableMessages.Count); // Get a random index from the available messages

        RandomText.text = availableMessages[random]; // Set the text of the TextMeshProUGUI to the randomly selected message
        RandomText.gameObject.SetActive(true); // Make sure the text is visible

        availableMessages.RemoveAt(random); // Remove the displayed message from the available messages list to avoid repetition
    }
}