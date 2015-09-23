using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waitingRoomManager : MonoBehaviour {

    public GameObject defaultPlayer;
    public GameObject parentContainer;

	// Use this for initialization
	void Start () {
        if (PhotonNetwork.inRoom)
        {
            foreach (PhotonPlayer player in PhotonNetwork.playerList)
            {
                GameObject unPlayer = GameObject.Instantiate(this.defaultPlayer);
                Text guiTxt = unPlayer.GetComponent<Text>();
                guiTxt.text = player.name;

                unPlayer.transform.SetParent(this.parentContainer.transform);
            }
        }
        else
        {
            // plus dans la room, on redirige vers le menu d'accueil
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

   /* void OnPhotonPlayerConnected ()
    {
        print("connectioooooooooooooo");
        
    }*/
}
