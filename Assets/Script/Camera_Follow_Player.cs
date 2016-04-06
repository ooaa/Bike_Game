using UnityEngine;
using System.Collections;

public class Camera_Follow_Player : MonoBehaviour {
	public GameObject camHolder;

	private float zPos = -5;
	private Vector3 playerPosition;
    private float upperY = 17.5f;
    private float lowerY = -4.0f;
	// Use this for initialization
	void Start () {
		playerPosition = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition.x = this.transform.position.x;
        if (this.transform.position.y > lowerY && this.transform.position.y < upperY)
        {
            playerPosition.y = this.transform.position.y;
            Debug.Log("between");
        }
        else
        {
            Debug.Log("Below or above");
            if (this.transform.position.y < lowerY)
            {
                playerPosition.y = lowerY;
            }
            else if (this.transform.position.y > upperY)
            {
                playerPosition.y = upperY;
            }
        }
		playerPosition.z = zPos;
		camHolder.transform.position = playerPosition;
		//Debug.Log (playerPosition);

	}
}
