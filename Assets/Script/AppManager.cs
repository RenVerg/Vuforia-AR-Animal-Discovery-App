using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
	public string MainMenuScene;
	public string StartScene;

    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(StartScene);
    }
	
	public void ExitApplication()
	{
		Application.Quit();
	}

}
