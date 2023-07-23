using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
  }

  void Update()
  {

  }
}
