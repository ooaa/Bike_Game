using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Distance : MonoBehaviour {

    public Text distanceText;
    private int start;
    private int distance;

	// Use this for initialization
	void Start () {
        start = (int)this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        distance = (int)this.transform.position.x - start;
        distanceText.text = distance + " m";
	}
    public int getDistance()
    {
        return distance;
    }
}
