using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace Cainos.PixelArtTopDown_Basic // Asegúrate de que el namespace coincide con el del resto del proyecto
{
    public class RedesJugador : MonoBehaviourPunCallbacks
    {
        private static int numPlayers;
        public GameObject cameraPrefab;
        public MonoBehaviour[] ignore;

        private PhotonView photonView;
        private GameObject ownCamera;

        private static bool isCameraAlreadySet = false;
        public GameObject textPrefab;
        private Text playerNameText;
        public static bool flagInstanced = false;
        private string role = "noRole";

        private void Awake()
        {
            photonView = GetComponent<PhotonView>();
            if (!photonView.IsMine)
            {
                foreach (var codigo in ignore)
                {
                    codigo.enabled = false;
                }
            }
            PhotonNetwork.NickName = InputRecover.userName;

            int numPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
            gameObject.name = "Player_" + numPlayers;
            updatePlayers();

            if (!isCameraAlreadySet)
            {
                BuildCamera();
                isCameraAlreadySet = true;
            }
            flagInstanced = true;
        }

         void Update()
        {
            if (textPrefab != null)
            {
                showUserName();
            }
        }

        private void BuildCamera()
        {
            if (cameraPrefab != null)
            {
                ownCamera = Instantiate(cameraPrefab, transform.position, Quaternion.identity);
                ownCamera.name = "Camera_Player_" + photonView.Owner.ActorNumber;

                CameraFollow ownCameraComponent = ownCamera.GetComponent<CameraFollow>();
                ownCameraComponent.target = transform;
            }
            else
            {
                Debug.Log("No se ha asignado el prefab de la cámara para crear.");
            }
        }

        private void updatePlayers()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Texteable");
            if (players.Length > 0)
            {
                players[0].GetComponent<Text>().text = "Jugadores: " + PhotonNetwork.CurrentRoom.PlayerCount;
            }
            else
            {
                Debug.Log("No se encontraron GameObjects con la etiqueta 'Texteable'.");
            }
        }

        void OnDestroy()
        {
            numPlayers--;
            updatePlayers();
        }

        public void showUserName()
{
    if (textPrefab != null)
    {
        if (playerNameText == null)
        {
            GameObject nameObject = Instantiate(textPrefab);
            nameObject.transform.position = new Vector3(transform.position.x - 0.2575f, transform.position.y + 2, transform.position.z);
            nameObject.transform.SetParent(this.transform);
            playerNameText = nameObject.GetComponent<Text>();
        }

//        playerNameText.text = PhotonNetwork.NickName;
    }
}

        [PunRPC]
        void SetPlayerName(string playerName)
        {
            Debug.Log("RPC: Setting player name to " + playerName);
            if (playerNameText != null)
            {
                Debug.Log("Text component exists. Setting text to " + playerName);
                playerNameText.text = playerName;
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if (photonView.IsMine)
            {
                Debug.Log("Calling RPC for player " + newPlayer.NickName);
                photonView.RPC("SetPlayerName", newPlayer, newPlayer.NickName);
            }
        }
    }
}
