using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  //public InputRecover memory;
  public delegate void manage();
  public delegate void message(string mes);
  public event manage hideMenu;
  public event manage showOpt;
  public event manage showMenu;
  public event manage hideOpt;
  public event manage showStart;
  public event manage hideStart;
  public event message showText;
  public event manage connect;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void OnStartEntered() {
    if (InputRecover.hallCode == null) {
      showText("Debe escribir el codigo de la sala o crearla.");
    } else if (InputRecover.userName == null && InputRecover.userName == "") {
      showText("Debe escribir un nombre de usuario.");
    } else {
      SceneManager.LoadScene(1);
      connect();
    }
  }


  public void StartButton() {
   // SceneManager.LoadScene(1);
    hideMenu();
    showStart();
  }

  public void OptionsButton() {
    hideMenu();
    showOpt();
  }

  public void BackButton() {
    hideOpt();
    showMenu();
  }

  public void BackStart() {
    hideStart();
    showMenu();
  }

  public void QuitButton() {
    Debug.Log("Saliendo");
    Application.Quit();
  }
}
