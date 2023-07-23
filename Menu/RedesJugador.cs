using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;

public class RedesJugador : MonoBehaviour
{
  public  MonoBehaviour[] ignore;
  private PhotonView  photonView;
  void Start()
  {
    photonView = GetComponent<PhotonView>();
    if (!photonView.IsMine) {
      foreach(var codigo in ignore) {
        codigo.enabled = false;
      }
    }
    updatePlayers();
  }

  void Update()
  {

  }

  void updatePlayers() {
    GameObject[] players  = GameObject.FindGameObjectsWithTag("Texteable");
    if  (players[0] != null) {
      string playersText = players[0].GetComponent<Text>().text;
      string num;
      num =  playersText[playersText.Length-1].ToString();
      if (int.TryParse(playersText[playersText.Length-2].ToString(), out _)) {
        num = playersText[playersText.Length-2].ToString() +  playersText[playersText.Length-1].ToString();
      }
      int result = int.Parse(num);
      result++;
      players[0].GetComponent<Text>().text = "Jugadores: " + result;
    }
  }
}
