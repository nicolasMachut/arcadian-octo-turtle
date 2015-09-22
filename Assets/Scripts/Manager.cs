using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        print("instanciate");
        PhotonNetwork.Instantiate("Player", player.transform.position, Quaternion.identity, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
