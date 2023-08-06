using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

using Cainos.PixelArtTopDown_Basic;
public class StarterLobbyButton : MonoBehaviour
{
  private bool startButtonFlag = false;

  void Start()
  {

  }


  void Update()
  {

    if (RedesJugador.flagInstanced) {
      // mDebug.Log(PhotonNetwork.CurrentRoom.Players.Value.NickName );
      if (PhotonNetwork.CurrentRoom.PlayerCount > 1 && !startButtonFlag) {
        GetComponent<Button>().enabled = true;
        startButtonFlag = true;
      } if (PhotonNetwork.CurrentRoom.PlayerCount <= 1) {
        GetComponent<Button>().enabled = false;
      }
    }
  }


}
