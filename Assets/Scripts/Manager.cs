using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        print("instanciate");
        PhotonNetwork.Instantiate("PlayerBoule", new Vector3(-47, 10, 0), Quaternion.identity, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnLeftRoom()
    {
        //PhotonNetwork.autoCleanUpPlayerObjects = true;
    }
}
