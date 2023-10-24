using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

void ConnectToServer()
    {
    PhotonNetwork.ConnectUsingSettings();
    Debug.Log("Trying to connect to a server..."); 
    }
    public override void OnConnectedToMaster()
    {
       Debug.Log("FINALLY CONNECTED TO A SERVER");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("JOINED A ROOM");
        base.OnJoinedRoom();

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A PLAYER HAS JOINED THE GAME");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}


