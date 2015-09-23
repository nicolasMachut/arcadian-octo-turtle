using UnityEngine;
using System.Collections;

public class OrbitElement : MonoBehaviour {
	public Transform target;
	public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround(obj.transform.position, Vector3.forward, 100 * Time.deltaTime);
	}
}
