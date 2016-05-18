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
    private bool villagerHit;

    // Use this for initialization
    void Start () {
        this.init();
        villagerHit = false;
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
		Time.timeScale = 0;
		scoreCanvas.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Civilian")
        {
            villagerHit = true;
            this.reset();
        }
    }

    public bool getVillagerHit()
    {
        return villagerHit;
    }

    public void fail()
    {

    }

    public void success()
    {

    }

}
