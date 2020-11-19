using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool gameIsPaused = false;

	public GameObject pauseMenuUI;
	public GameObject pauseButtonUI;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(gameIsPaused)
			{
				Resume();
			}else
			{
				Paused();
			}
		}
	}

	void Paused()
	{
		PlayerMovement.instance.enabled = false;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		gameIsPaused = true;
	}

	public void PauseButton()
	{
		PlayerMovement.instance.enabled = false;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		gameIsPaused = true;
		pauseButtonUI.SetActive(false);
	}

	public void Resume()
	{
		PlayerMovement.instance.enabled = true;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		gameIsPaused = false;
		pauseButtonUI.SetActive(true);
	}

	 public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonQuit()
    {
    	 Application.Quit();
    }
}
