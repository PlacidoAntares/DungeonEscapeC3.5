using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
	{
		Debug.Log("Starting Game");
		SceneManager.LoadScene("Level1");
	}
	public void QuitButton()
	{
		Debug.Log("Quitting Game");
		Application.Quit();
	}
}
