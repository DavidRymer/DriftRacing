using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    
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
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate("Jeep", spawnPoint1.transform.position, Quaternion.identity);

        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate("Jeep", spawnPoint2.transform.position, Quaternion.identity);

        }
        
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