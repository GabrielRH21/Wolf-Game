using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

using Cainos.PixelArtTopDown_Basic;

public class RedesJugador : MonoBehaviour
{
    private static int numPlayers;
    public GameObject cameraPrefab; // Asigna el prefab de la cámara desde el Inspector de Unity
    public MonoBehaviour[] ignore; // Componentes a desactivar para los jugadores que no sean el local

    private PhotonView photonView;
    private GameObject ownCamera;

    private static bool isCameraAlreadySet = false; // Variable para evitar que las cámaras existentes se centren en el nuevo jugador

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

        // Incrementar el contador de jugadores y asignar el número al GameObject
        int numPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
        gameObject.name = "Player_" + numPlayers;
        updatePlayers();
        // Crea una cámara para el jugador actual solo si no se ha asignado una cámara a otro jugador
        if (!isCameraAlreadySet)
        {
            BuildCamera();
            isCameraAlreadySet = true;
        }
    }

    void Update()
    {

    }

    void BuildCamera()
    {
        // Verifica que se haya asignado el prefab de la cámara
        if (cameraPrefab != null)
        {
            // Crea una instancia de la cámara en la posición y rotación del transform del jugador actual
            ownCamera = Instantiate(cameraPrefab, transform.position, Quaternion.identity);
            ownCamera.name = "Camera_Player_" + photonView.Owner.ActorNumber; // Usar ActorNumber como identificador

            // Asigna la cámara al transform del nuevo jugador
            CameraFollow ownCameraComponent = ownCamera.GetComponent<CameraFollow>();
            ownCameraComponent.target = transform;
        }
        else
        {
            Debug.Log("No se ha asignado el prefab de la cámara para crear.");
        }
    }

    void updatePlayers()
    {
        Debug.Log("holas");
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
        // Decrementar el contador de jugadores cuando un jugador sale de la sala
        numPlayers--;
        updatePlayers();
    }
}
