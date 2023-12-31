using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class InputRecover : MonoBehaviour
{
  public delegate void manage();
  public delegate void message(string mes);
  public event manage connect;
  public event message send;
  public static int usersCount;
  public static string userName;
  public static string hallCode;


  void Start()
  {

  }

  void Awake()  {
    DontDestroyOnLoad(gameObject);
  }

  void Update()
  {
    if (Input.GetKey("escape")){
      Application.Quit();
    }
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

  public void OnCodeEntered(string answer) {
    hallCode = answer;
    Debug.Log("El código de la sala es: " + answer);
  }

  public void OnCreateHall() {
    string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    var charArr = new char[6];
    var rand = new System.Random();
    for (int i  =  0; i < charArr.Length; i++)  {
      charArr[i] = characters[rand.Next(characters.Length)];
    }
    hallCode = new string(charArr);
    Debug.Log("El  codigo de la sala es: " + hallCode);
    if (userName != null && userName != "") {
      SceneManager.LoadScene(1);
      connect();
    }
    send("Debe escribir un nombre de usuario.");
  }
}
