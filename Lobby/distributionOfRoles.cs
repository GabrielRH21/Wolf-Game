using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class distributionOfRoles : MonoBehaviour
{
    // Cambiar a private, public para hacer pruebas.
  public bool witch = false;
  public bool seer = false;
  public int wolves = 1;
  public int villagers = 0;

  void Start()
  {

  }


  void Update()
  {

  }

  public void startPressed() {
    switch (PhotonNetwork.CurrentRoom.PlayerCount) {
    case 5:
    case 6:
    case 7:
        oneWolfOption(PhotonNetwork.CurrentRoom.PlayerCount);
        distribution();
        break;
    case 8:
    case 9:
    case 10:
        twoWolvesOption(PhotonNetwork.CurrentRoom.PlayerCount);
        distribution();
        break;
    case 11:
    case 12:
        threeWolvesOption(PhotonNetwork.CurrentRoom.PlayerCount);
        distribution();
        break;
    default:
        Debug.Log("low number of players");
        break;
    }
  }

  private void oneWolfOption(int players) {
    villagers = players - 2;
    bool witch = false;
    if  (villagers == 5) {
      villagers -=1;
      witch = true;
    }
  }

  private void twoWolvesOption(int players) {
    wolves = 2;
    witch = true;
    villagers = players - 4;
    if (villagers != 4) {
      villagers -=1;
      seer = true;
    }
  }

  private void threeWolvesOption(int players) {
    wolves = 3;
    witch = true;
    seer = true;
    villagers = players - 6;
  }

  private void distribution() {
    int[] players = new int[PhotonNetwork.CurrentRoom.PlayerCount];
    for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++) {
      players[i] = i+1;
    }
  }
}
