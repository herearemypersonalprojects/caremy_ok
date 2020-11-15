using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
	public GameObject gameOverUI;

	public static GameOverManager instance;

   private void Awake()
   {
       if(instance != null)
       {
        Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
        return;

       }
       
    
       instance = this;
   }

    public void OnPlayerDeath()
    {
      if(CurrentSceneManager.instance.isPlayerPresentByDefault)
      {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
      }

    	gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
      	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      	gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {

    }

    public void QuitButton()
    {
    	Application.Quit();
    }
}
