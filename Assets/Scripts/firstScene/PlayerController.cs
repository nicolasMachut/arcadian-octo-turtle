using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	private Vector3 horizontalForce = new Vector3 (1f,0.0f,0.0f);
	public int accelleration;
	private Vector3 verticalForce = new Vector3 (0.0f,1,0.0f);
	public int jumpForce;
	public int maxSpeed;

	public bool candoublejump;
	public bool grounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
        //view = GetComponent<PhotonView>();
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				rb.AddForce (new Vector3 (0.0f, jumpForce,0.0f));
				candoublejump = true;
				grounded = false;
			} else {
				if (candoublejump) {
					candoublejump = false;
					rb.AddForce (new Vector3 (0.0f, jumpForce, 0.0f));
				}
			}
		}

		if (rb.velocity.magnitude < maxSpeed) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				moveLeft ();
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				moveRight ();
			}
		} else {
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
				rb.AddForce(-2 * rb.velocity);
			}
		}
	}

	void moveLeft(){
		rb.AddForce( -horizontalForce * accelleration);
	}

	void moveRight(){
		rb.AddForce(horizontalForce * accelleration);
	}

	void jump(){
		rb.AddForce(verticalForce * jumpForce);
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
//		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
//		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
//		print("Their relative velocity is " + collisionInfo.relativeVelocity);
		grounded = true;
		candoublejump = true;
	}
	
//	void OnCollisionStay(Collision collisionInfo)
//	{
//		print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
//	}
	
//	void OnCollisionExit(Collision collisionInfo)
//	{
//		print(gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
//	}
}
