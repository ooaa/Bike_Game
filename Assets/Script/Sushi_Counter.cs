using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sushi_Counter : MonoBehaviour {

    public Text sushiScore;

    private int counter = 0;


	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col) { 
        //Debug.Log(col.gameObject);
        if(col.gameObject.tag == "Sushi")
        {
            //Debug.Log("Sushi" + ++counter);
            sushiScore.text = "" + ++counter;
            Destroy(col.gameObject);
        }
    }
}
