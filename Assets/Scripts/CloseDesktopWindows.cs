using UnityEngine;

public class CloseDesktopWindows : MonoBehaviour
{
    public GameObject[] Windows;

    public void CloseAll()
    {
        foreach (GameObject window in Windows)
        {
            window.SetActive(false);
        }
    }
}