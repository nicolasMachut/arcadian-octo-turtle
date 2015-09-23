using UnityEngine;
using System.Collections;

public class destroyByContact : MonoBehaviour {
	
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if(gameControllerObject == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}

	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Destroy (other);
		}
		//gameController.gameOver ();
	}
}
