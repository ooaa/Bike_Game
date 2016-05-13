using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Menu : MonoBehaviour {

	public Canvas pauseCanvas;
	public Canvas scoreCanvas;
	public Canvas HUDCanvas;

    int currentsushi, currentdist;
    public PlayerData pd;
    private int start;

    void Start() {

        
		pauseCanvas.enabled = false;
		scoreCanvas.enabled = false;
		HUDCanvas.enabled = true; 

		Time.timeScale = 1;
        
        initPlayerData();

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject);
        if (col.gameObject.tag == "Sushi")
        {
            //Debug.Log("Sushi" + ++counter);
            ++currentsushi;
            //Destroy(col.gameObject);
        }
    }

    void Update()
    {
        currentdist = (int)this.transform.position.x - start;
       
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
		Time.timeScale = 0;
	}

	public void StartOn()

	{
		SceneManager.LoadScene (0);
		Time.timeScale = 1;
	} 

	public void ReplayOn()

	{
        updatePlayerData();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); ;

		Time.timeScale = 1;
	}

    void updatePlayerData()
    {
                GameObject[] playerinfo;
                playerinfo = GameObject.FindGameObjectsWithTag("PlayerInfo");
        try {
            pd.sushi += (int)currentsushi;
            pd.distance += (int)currentdist;
            BinaryFormatter binform = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "Player.dat", FileMode.Open);
            binform.Serialize(file, pd);
            file.Close();
            Debug.Log("File Saved");
        }catch(Exception e)
        {
            Debug.Log("Save Failed");
            Debug.Log(e);
        }

    }

    void initPlayerData()
    {
        Debug.Log(pd.toString());
        if (File.Exists(Application.persistentDataPath + "/Player.dat"))
        {
            Debug.Log("File Loaded");
            BinaryFormatter bform = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/Player.dat", FileMode.Open);

            pd = (PlayerData)bform.Deserialize(fStream);

            fStream.Close();


        }
        else
        {
            FileStream f = File.Create(Application.persistentDataPath + "/Player.dat");
            f.Close();
            Debug.Log("New Data");
            pd = new PlayerData();
            pd.sushi_collected = 0;
            pd.villiagers_hit = 0;
            pd.distance_Travelled = 0;

        }

    }

}




