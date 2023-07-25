using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GestorPhotom : MonoBehaviourPunCallbacks
{

  public LevelManager deleg;

  public InputRecover conct;
  void Start() {
    //PhotonNetwork.ConnectUsingSettings();
  }

  void Update() {
    deleg.connect += OnStartPressed;
    conct.connect += OnStartPressed;
  }

  public void OnStartPressed() {
    PhotonNetwork.ConnectUsingSettings();
  }

    public override void OnConnectedToMaster() {
      PhotonNetwork.JoinLobby();
  }

  public override void OnJoinedLobby() {
      PhotonNetwork.JoinOrCreateRoom(InputRecover.hallCode, new RoomOptions { MaxPlayers = 12 }, TypedLobby.Default);
      GameObject[] menu = GameObject.FindGameObjectsWithTag("Menu");
      menu[0].transform.GetChild(2).gameObject.GetComponent<Text>().text = "Codigo: " + InputRecover.hallCode;
  }

  public override void OnJoinedRoom() {
      PhotonNetwork.Instantiate("Jugador", new Vector2(Random.Range(-7, 7), 2), Quaternion.identity);
  }
}
