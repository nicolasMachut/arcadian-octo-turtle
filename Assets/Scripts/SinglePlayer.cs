using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SinglePlayer : MonoBehaviour
{

    public GameObject Canvas;
    public GameObject Cube;
    public GameObject currentDetonator;
    public GameObject menuOptionStart;
    public GameObject menuOptionMultiplayer;
    public GameObject listServerGrid;
    public GameObject player;
    public GameObject defaultButton;

    private int _currentExpIdx = -1;
    public GameObject[] detonatorPrefabs;
    public float explosionLife = 10;
    public float timeScale = 1.0f;
    public float detailLevel = 1.0f;
    public float speedRotation;

    public float forceExplosion;
    public float radiusExplosion;

    public float durationBeforeChangeScreen;
    private float timeToChangeLvl = -10;
    // Use this for initialization
    void Start()
    {
        this._currentExpIdx = 5;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(PhotonNetwork.connectionState);
        if (this.timeToChangeLvl != -10)
            if (Time.time > timeToChangeLvl)
                Application.LoadLevel("LogoMenu");
    }

    public void ClickNewGame()
    {
        if (this.Cube != null)
        {
            DestroyObject(Cube);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Detonator dTemp = (Detonator)currentDetonator.GetComponent("Detonator");

            float offsetSize = dTemp.size / 3;

            GameObject exp = (GameObject)Instantiate(currentDetonator, Cube.GetComponent<Rigidbody>().position, Quaternion.identity);
            dTemp = (Detonator)exp.GetComponent("Detonator");


            Destroy(exp, explosionLife);
            Cube.GetComponent<Rigidbody>().AddExplosionForce(this.forceExplosion, Cube.GetComponent<Rigidbody>().position, this.radiusExplosion);
            DestroyObject(Cube);
            this.timeToChangeLvl = Time.time + this.durationBeforeChangeScreen;
        }
    }

    public void ClickContinue()
    {
        Debug.Log("continue");
    }

    public void ClickMultiplayer()
    {
        this.Cube.GetComponent<Rigidbody>().AddTorque(0, this.speedRotation, 0);

        this.menuOptionStart.active = false;
        this.menuOptionMultiplayer.active = true;
        PhotonNetwork.ConnectUsingSettings("0.1");

        Debug.Log(PhotonNetwork.connectionState);
    }

    public void CreateRoom()
    {
       

            Debug.Log(PhotonNetwork.connectionState);
            switch (PhotonNetwork.connectionState)
            {
                case ConnectionState.Disconnected:

                    break;
                case ConnectionState.Connecting:
                    break;
                case ConnectionState.Connected:
                    Debug.Log("creation room");
                    PhotonNetwork.CreateRoom("une room");
                    break;
                case ConnectionState.Disconnecting:
                    break;
                case ConnectionState.InitializingApplication:
                    break;
                default:
                    break;
            }    
    }

    void OnJoinedLobby()
    {
       
    }
   public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        Application.LoadLevel("game");
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
    }

    public void joinRoom(ServerButton servButton)
    {
        Debug.Log("joinRoom");
        PhotonNetwork.JoinRoom(servButton.roomName);
    }

 

    void Refresh()
    {
        this.DeleteListServer();
        
        foreach(RoomInfo oneServ in PhotonNetwork.GetRoomList())
        {
            

            GameObject newButton = Instantiate(this.defaultButton) as GameObject;
            ServerButton button = newButton.GetComponent<ServerButton>();
            button.roomName = oneServ.name;
            button.ip = "";
            newButton.active = true;
            newButton.name = "button" + button.roomName;

            RectTransform rect = newButton.GetComponent<RectTransform>();
            button.manager = this;
            //button.button.onClick = item.thingToDo;
            newButton.transform.localScale = this.listServerGrid.transform.localScale;
            newButton.transform.SetParent(this.listServerGrid.transform);
            newButton.transform.localScale = this.listServerGrid.transform.localScale;
        }
    }

    private void DeleteListServer()
    {
        foreach (Transform children in this.listServerGrid.transform)
        {
            Destroy(children.gameObject);
        }

    }

    public List<ServerButton> simulationRequestServer()
    {
        List<ServerButton> listToReturn = new List<ServerButton>();

        listToReturn.Add(new ServerButton
        {
            ip = "10.224.230.15",
            roomName = "Romm nico",
            button = Resources.Load("ServerButton") as Button
        });
        listToReturn.Add(new ServerButton
        {
            ip = "10.14.228.23",
            roomName = "Romm Alex",
            button = Resources.Load("ServerButton") as Button
        });

        return listToReturn;
    }
    public void Quit()
    {
        this.menuOptionStart.active = true;
        this.menuOptionMultiplayer.active = false;
    }
}
