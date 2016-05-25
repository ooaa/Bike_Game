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

    private int sushi;
    private int distance;
    private int distanceHighest;
    private int sushiHighest;
    private bool villagerHit;
    private PlayerData pdat = new PlayerData();

    

    void Start()
    {
        sushi = GameObject.Find("WhaleGuy_Holder").GetComponent<Sushi_Counter>().getSushi();
        distance = GameObject.Find("WhaleGuy_Holder").GetComponent<Player_Distance>().getDistance();
        villagerHit = GameObject.Find("WhaleGuy_Holder").GetComponent<Player_Reset>().getVillagerHit();
        pauseCanvas.enabled = false;
		scoreCanvas.enabled = false;
		HUDCanvas.enabled = true; 
		Time.timeScale = 1;
        initPlayerData();
	}


    void Update()
    {

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
        savePlayerData();
		SceneManager.LoadScene (0);
		Time.timeScale = 1;
	} 

	public void ReplayOn()
    { 
        savePlayerData();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}



    void savePlayerData()
    {
        Debug.Log("Saving Player Data...");
        villagerHit = GameObject.Find("WhaleGuy_Holder").GetComponent<Player_Reset>().getVillagerHit();
        sushi = GameObject.Find("WhaleGuy_Holder").GetComponent<Sushi_Counter>().getSushi();
        distance = GameObject.Find("WhaleGuy_Holder").GetComponent<Player_Distance>().getDistance();
        if (villagerHit) pdat.villagers++;
        sushiHighest = sushi;
        distanceHighest = distance;
        pdat.sushi += sushi;
        pdat.distance += distance;
        pdat.sushiHighest = (pdat.sushiHighest < sushiHighest) ? sushiHighest : pdat.sushiHighest;
        pdat.distanceHighest = (pdat.distanceHighest < distanceHighest) ? distanceHighest : pdat.distanceHighest;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream save = File.Create(Application.persistentDataPath + "/Saves/player.dat");
        formatter.Serialize(save, pdat);
        save.Close();
        Debug.Log("Player Data Successfully Saved!");
        Debug.Log(pdat.toString());
    }

    void initPlayerData()
    {
        Debug.Log("Loading Player Data...");
        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Debug.Log("No File Found, Creating New File");
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
            if (!File.Exists(Application.persistentDataPath + "/Saves/player.dat"))
            {
                File.Create(Application.persistentDataPath + "/Saves/player.dat");
                pdat = new PlayerData();
            }
            Debug.Log("New Player Save Created!");
        }
        else
        {
            Debug.Log("Loading Player Data...");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream save = File.Open(Application.persistentDataPath + "/Saves/player.dat", FileMode.Open);
            pdat = (PlayerData)formatter.Deserialize(save);
            save.Close();
            Debug.Log("Player Data Successfully Recovered!");
            Debug.Log(pdat.toString());
        }

    }

}




