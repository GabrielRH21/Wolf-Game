using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RedLogical : MonoBehaviourPunCallbacks
{
  public static RedLogical instance;

  void awake()  {
    instance = this;
    DontDestroyOnLoad(gameObject);
  }

  void Start()
  {
    PhotonNetwork.ConnectUsingSettings();
  }

  void Update()
  {

  }

  public override void OnConnectedToMaster() {
    Debug.Log("You are connected");
  }
}
