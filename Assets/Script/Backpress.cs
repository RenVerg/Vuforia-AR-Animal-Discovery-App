using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Backpress : MonoBehaviour {

	public string SceneName;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
        {
			SceneManager.LoadScene(SceneName);
        }
	}

	public void BackToMenu()
    {
		SceneManager.LoadScene(SceneName);
	}

}