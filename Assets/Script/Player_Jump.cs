using UnityEngine;
using System.Collections;

public class Player_Jump : MonoBehaviour {

    private bool grounded;
    RaycastHit2D hit;
    // Use this for initialization
    void Start () {
        grounded = false;
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            jump();
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {

                jump();

            }
        }

    }

    void FixedUpdate()
    {

    }

    public void jump()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.0f);
        if (hit.collider.gameObject.tag == "Ground")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
        }
    }



}
