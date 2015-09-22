using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    private PhotonView view;
    private Rigidbody2D rigidbody;


	// Use this for initialization
	void Start () { 
        view = GetComponent<PhotonView>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (view.isMine)
        {
            KeyBoardInputHandler();
        }
	}

    void KeyBoardInputHandler ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(new Vector2(-0.5f, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(new Vector2(0.5f, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
        }
    }
}
