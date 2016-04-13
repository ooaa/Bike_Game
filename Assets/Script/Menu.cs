using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour {

	public Canvas pauseCanvas;
	public Canvas scoreCanvas;
	public Canvas HUDCanvas;

	void Start() {

		pauseCanvas.enabled = false;
		scoreCanvas.enabled = false;
		HUDCanvas.enabled = true; 

		Time.timeScale = 1;

	}

	public void PauseOn() 

	{
		pauseCanvas.enabled = true;
		scoreCanvas.enabled = false;
		HUDCanvas.enabled = false;

		Time.timeScale = 0;
	}

	public void ResumeOn() 

	{
		pauseCanvas.enabled = false;
		scoreCanvas.enabled = false;
		HUDCanvas.enabled = true;

		Time.timeScale = 1;
	}

	public void ScoreOn()

	{
		pauseCanvas.enabled = false;
		scoreCanvas.enabled = true;
		HUDCanvas.enabled = false;

		Time.timeScale = 1;
	}

	public void StartOn()

	{
		SceneManager.LoadScene (0);

		Time.timeScale = 1;
	} 

	public void ReplayOn()

	{
		SceneManager.LoadScene (1);

		Time.timeScale = 1;
	}
		
}


