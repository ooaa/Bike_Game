using UnityEngine;
using System.Collections;

public class Player_Jump : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("TOUCH!");
        }

        
	}
}
