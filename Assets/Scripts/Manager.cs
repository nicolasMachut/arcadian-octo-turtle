using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        print("instanciate");
        PhotonNetwork.Instantiate("Joueur", Vector3.zero, Quaternion.identity, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnLeftRoom()
    {
        PhotonNetwork.autoCleanUpPlayerObjects = true;
    }
}
