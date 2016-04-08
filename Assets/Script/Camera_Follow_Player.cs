using UnityEngine;
using System.Collections;

public class Camera_Follow_Player : MonoBehaviour {
	public GameObject camHolder;

	public float zPos = -5;
	Vector3 playerPosition;
	// Use this for initialization
	void Start () {
		playerPosition = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition.x = this.transform.position.x;
		playerPosition.y = this.transform.position.y;
		playerPosition.z = zPos;
		camHolder.transform.position = playerPosition;
		Debug.Log (playerPosition);

	}
}
