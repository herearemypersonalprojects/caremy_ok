using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;

	Resolution[] resolutions;

	public void Start()
	{
		resolutions = Screen.resolutions;
	}

    public void SetVolume(float volume)
    {
    	audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
    	Screen.fullScreen = isFullScreen;
    }
}