using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class Start_Menu : MonoBehaviour {

	public void PlayOn() 
	{
		SceneManager.LoadScene (0);
	}
}