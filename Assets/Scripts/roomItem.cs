using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class roomItem : MonoBehaviour
{

    public TextMeshProUGUI roomName;
    LobbyManager manager;


    private void Start()
    {
        manager = FindObjectOfType<LobbyManager>();
    }


    public void setRoomName(string _roomName) { 


        roomName.text = _roomName;

        }

    public void onClickItem() {

        manager.JoinRoom(roomName.text);
    }


   

    
}
