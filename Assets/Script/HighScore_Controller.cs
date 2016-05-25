using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HighScore_Controller : MonoBehaviour {

    Text su1, su2, di1, di2, vil;
    PlayerData pdat;

	// Use this for initialization
	void Start () {
        su1 = GameObject.Find("Sushi1").GetComponent<Text>();
        su2 = GameObject.Find("Sushi2").GetComponent<Text>();
        di1 = GameObject.Find("Dist1").GetComponent<Text>();
        di2 = GameObject.Find("Dist2").GetComponent<Text>();
        vil = GameObject.Find("Vill").GetComponent<Text>();

        initPlayerData();

        su1.text = "Total Sushi: " + pdat.sushi;
        su2.text = "Most Sushi Collected: " + pdat.sushiHighest;
        di1.text = "Total Distance: " + pdat.distance;
        di2.text = "Most Distance Covered: " + pdat.distanceHighest;
        vil.text = "Villagers Hit: " + pdat.villagers; 

    }
	
	// Update is called once per frame
	void Update () {
	
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
    public void back()
    {
        SceneManager.LoadScene(0);
    }

}
