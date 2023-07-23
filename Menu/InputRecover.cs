using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class InputRecover : MonoBehaviour
{
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
  }
}
