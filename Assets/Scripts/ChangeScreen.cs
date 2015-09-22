using UnityEngine;
using System.Collections;

public class ChangeScreen : MonoBehaviour {

	// Use this for initialization
    public float timeBeforeChangeScreen;
    private float timeToChangeScreen;


	void Start () {
        this.timeToChangeScreen = Time.time + timeBeforeChangeScreen;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > this.timeToChangeScreen)
        Application.LoadLevel("StartMenu");
	}
}
