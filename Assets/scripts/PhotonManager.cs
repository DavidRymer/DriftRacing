using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions {MaxPlayers = 2};
        PhotonNetwork.JoinOrCreateRoom("lol", roomOptions, TypedLobby.Default);
        
    } 
    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Jeep", new Vector3(0, 1, 0), Quaternion.identity);
        
    }
    
    
    
     void OnConnected()
    {
        Debug.Log("aaaaaaaaaaaaa");
    }

    // Update is called once per frame
    void Update()
    {
    }
}