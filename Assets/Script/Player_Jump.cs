using UnityEngine;
using System.Collections;

public class Player_Jump : MonoBehaviour {

    public Camera gamecam;
    public LayerMask touchInputMask;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        foreach(Touch touch in Input.touches){
            Ray ray = gamecam.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, touchInputMask)){
                //GameObject touched = hit.transform.gameObject;
                Debug.Log(hit);
                this.GetComponent<Rigidbody>().AddForce(0.0f, 10.0f, 0.0f);
                
            }
        }
        
	}
}
