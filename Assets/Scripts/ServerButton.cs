using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class ServerButton : MonoBehaviour
{
    public Text text;
    public Button button;
    public string ip;
    public string roomName;
    public SinglePlayer manager;

    
    public void Start()
    {
      
    }
    public void Update()
    {
        text.text = roomName;
        
    }

    public void ClickConnect()
    {
        this.manager.joinRoom(this);
        //Application.LoadLevel("LogoMenu");
        
    }
}

