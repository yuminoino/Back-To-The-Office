using UnityEngine;

public class CloseDesktopWindows : MonoBehaviour
{
    public GameObject[] Windows;

    public void CloseAll()
    {
        foreach (GameObject window in Windows) //for each window in the array of windows, set it to inactive
        {
            window.SetActive(false);
        }
    }
}