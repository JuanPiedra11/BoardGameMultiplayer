using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TMP_Text roomName;

    public roomItem roomItemPrefab;
    List  <roomItem> roomItemsList  = new List<roomItem> ();


    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f; 
    float nextUpdateTime;



    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate() {

        if (roomInputField.text.Length >= 1)
        {
        PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers= 5});
        }
    }


    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    }   

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        if(Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;

        }



        
    }
        
    void UpdateRoomList(List <RoomInfo> list) 
    { 
        foreach (roomItem item in roomItemsList) {
            Destroy(item.gameObject);
        }

        roomItemsList.Clear();  

        foreach (RoomInfo room in list) {
        roomItem newRoom =Instantiate(roomItemPrefab, contentObject);
            newRoom.setRoomName(room.Name);
            roomItemsList.Add(newRoom);
            
        }


    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom() { 
     PhotonNetwork.LeaveRoom();
    }


    public override void OnLeftRoom()
    {
       roomPanel.SetActive(false);
       lobbyPanel.SetActive(true);
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();  
    }


}
