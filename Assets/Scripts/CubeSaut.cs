using UnityEngine;
using System.Collections;

public class CubeSaut : MonoBehaviour {

    public float timeReloadJump;
    private Rigidbody rigidBody;
    private float timeNextJump = 0f;
    public float forceJump;
	void Start () {
        this.rigidBody = this.GetComponent<Rigidbody>();
        this.timeNextJump = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeNextJump)
        {
            timeNextJump = Time.time + timeReloadJump;
            this.rigidBody.AddForce(0, this.forceJump, 0);   
        }
	}
}
