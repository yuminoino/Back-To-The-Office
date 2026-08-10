using UnityEngine;
using TMPro;

public class RandomDesktopMessage : MonoBehaviour
{
    public TextMeshproUI RandomText;
    public string[] Messages =
    {
        "DON'T bE PESSIMISTIC!",
        "YOU HAVE A FrIEND HERE",
        "YOU SEE EVERYTHING IN GRaY",
        "vOID",
        "YOU CAN'T eXIT",
        "HELLO?",
        "CAN YOU HEAR ME?",
        "I MISS WHO I USED TO BE",
        "THIS PLACE IS STILL HERE. THEY AREN'T",
        "DESPITE EVERYTHING, IT'S STILL YOU",
    };

    public void ShowRandomMessage()
    {
        int randomIndex = Random.Range(0, Messages.Length);

        RandomText.text = Messages[randomIndex];
        RandomText.gameObject.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
