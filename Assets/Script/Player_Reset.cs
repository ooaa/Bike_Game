using UnityEngine;
using System.Collections;

public class Player_Reset : MonoBehaviour {


	public Canvas scoreCanvas;

    //player position, scene positions: background, foreground, etc
    public GameObject backgroundHolder;
    public GameObject foregroundHolder;
    private Vector3 playerStartPos;
    private Vector3 backgroundStartPos;
    private Vector3 foregroundStartPos;

	// Use this for initialization
	void Start () {
        this.init();
	}
	
	// Update is called once per frame
	void Update () {
        if(this.transform.position.y < -4.0f)
        {
            this.reset();
        }
    }

    public void init(){
        playerStartPos = this.transform.position;
        backgroundStartPos = backgroundHolder.transform.position;
        foregroundStartPos = foregroundHolder.transform.position;
    }
    
    public void reset()
    {
        this.transform.position = playerStartPos;
        backgroundHolder.transform.position = backgroundStartPos;
        foregroundHolder.transform.position = foregroundStartPos;

		Time.timeScale = 0;
		scoreCanvas.enabled = true;
	

    }
    
    public void fail()
    {

    } 
    public void success()
    {

    }

}
