using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class serverList : MonoBehaviour {

	// Use this for initialization
    public GameObject serverButton;
    public GameObject panel;
    public List<ServerButton> listServer;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void RefreshList()
    {
        this.listServer = this.simulationRequestServer();

        this.Populate();
    }

    public List<ServerButton> simulationRequestServer()
    {
        List<ServerButton> listToReturn = new List<ServerButton>();

        listToReturn.Add(new ServerButton{
            ip = "10.224.230.15",roomName ="Romm nico", button = Resources.Load("ServerButton") as Button
        });
        listToReturn.Add(new ServerButton
        {
            ip = "10.14.228.23",
            roomName = "Romm Alex",
            button = Resources.Load("ServerButton") as Button
        });

        return listToReturn;
    }

    public void Populate()
    {
	    PhotonNetwork.ConnectUsingSettings("0.1");
        this.DestroyChilds();
        this.listServer = this.simulationRequestServer();
        float offsetX=20;
        float offsetY=-20;
        foreach (ServerButton oneButton in this.listServer)
        {
             GameObject newButton = Instantiate (serverButton) as GameObject;
             ServerButton button = newButton.GetComponent<ServerButton>();
            button.roomName= oneButton.roomName;
            button.ip = oneButton.ip ;
            
            //button.button.onClick = item.thingToDo;
            newButton.transform.SetParent (this.panel.transform);
            Vector3 position = this.panel.transform.position;
            


            position.x += offsetX;
            position.y += offsetY;
            newButton.transform.position = position; 
            offsetY -= 20; 
        }
        print("refresh");

        foreach (RoomInfo info in PhotonNetwork.GetRoomList())
        {
            print(info.name);
        }
    }

    public void DestroyChilds()
    {
        foreach (Transform children in this.panel.transform)
        {
            Destroy(children.gameObject);
        }
    }
}
