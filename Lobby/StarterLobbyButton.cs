using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

using Cainos.PixelArtTopDown_Basic;
public class StarterLobbyButton : MonoBehaviour
{
  private bool startButtonFlag = false;

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

    if (RedesJugador.flagInstanced) {
      if (PhotonNetwork.CurrentRoom.PlayerCount > 1 && !startButtonFlag) {
        GetComponent<Button>().enabled = true;
        startButtonFlag = true;
      } if (PhotonNetwork.CurrentRoom.PlayerCount <= 1) {
        GetComponent<Button>().enabled = false;
      }
    }
  }

  void startPressed() {
    switch (PhotonNetwork.CurrentRoom.PlayerCount) {
    case 5:
    case 6:
    case 7:
        oneWolfOption(PhotonNetwork.CurrentRoom.PlayerCount);
        break;
    case 8:
    case 9:
    case 10:
        twoWolvesOption(PhotonNetwork.CurrentRoom.PlayerCount);
        break;
    case 11:
    case 12:
        threeWolvesOption(PhotonNetwork.CurrentRoom.PlayerCount);
        break;
    default:
        Debug.Log("low number of players");
        break;
    }
  }

  void oneWolfOption(int players) {
    villagers = players - 2;
    bool witch = false;
    if  (villagers == 5) {
      villagers -=1;
      witch = true;
    }
  }

  void twoWolvesOption(int players) {
    wolves = 2;
    witch = true;
    villagers = players - 4;
    if (villagers != 4) {
      villagers -=1;
      seer = true;
    }
  }

  void threeWolvesOption(int players) {
    wolves = 3;
    witch = true;
    seer = true;
    villagers = players - 6;
  }
}
