using UnityEngine;
using System.Collections;

public class NetworkController : MonoBehaviour {

    private string gameVersion = "0.1";

	// Use this for initialization
	void Start () {
        //PhotonNetwork.ConnectUsingSettings(gameVersion);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnJoinedLobby()
    {
        print("**************************************************************");
        PhotonNetwork.CreateRoom("une room");
    }

    void OnPhotonRandomJoinFailed()
    {
        print("** create room **");
       // PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {   
        Application.LoadLevel("veryGoodGame");
    }

    public void create ()
    {
        PhotonNetwork.ConnectUsingSettings(gameVersion);
    }   
}
