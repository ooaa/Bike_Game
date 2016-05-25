using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class Start_Menu : MonoBehaviour {

	public Canvas startCanvas;

	void Start() {

		startCanvas.enabled = true; 
	}

	public void PlayOn()
	{
		SceneManager.LoadScene (1);
	}

    public void HighScoreOn()
    {
        SceneManager.LoadScene(2);
    }

    public void Update ()
	{
		if (Input.GetKeyDown (KeyCode.G)) {
			SceneManager.LoadScene ("Level_1");
		}
	}

}
