using UnityEngine;

public class SettingRe : MonoBehaviour
{
    public GameObject settingsWindow;

    public void SettingsGame()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}
