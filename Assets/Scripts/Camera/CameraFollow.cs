using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private GameObject target;
    private Vector2 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
	}

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z -50);
        }
    }
}
