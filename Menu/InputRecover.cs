using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRecover : MonoBehaviour
{
  public static int usersCount;
  public static string userName;


  void Start()
  {

  }

  void Awake()  {
    DontDestroyOnLoad(gameObject);
  }

  void Update()
  {

  }

  public void OnNumberEntered(string answer)
  {
    if (int.TryParse(answer,  out int usersCount)) {
      Debug.Log("El número de usuarios para el juego son: " + usersCount);
    }
  }

  public void OnNameEntered(string answer) {
    userName = answer;
    Debug.Log("El nombre de usuario elegido es: " + userName);
  }
}
