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

    private List<string> availableMessages;

    void Start()
    {
        availableMessages = new List<string>(Messages);
    }

    public void ShowRandomMessage()
    {
        if (availableMessages.Count == 0)
        {
            availableMessages = new List<string>(Messages);
        }

        int random = Random.Range(0, availableMessages.Count);

        RandomText.text = availableMessages[random];
        RandomText.gameObject.SetActive(true);

        availableMessages.RemoveAt(random);
    }
}