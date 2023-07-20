using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public delegate void manage();
  public event manage hideMenu;
  public event manage showOpt;
  public event manage showMenu;
  public event manage hideOpt;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void StartButton() {
    SceneManager.LoadScene(1);
  }

  public void OptionsButton() {
    hideMenu();
    showOpt();
  }

  public void BackButton() {
    hideOpt();
    showMenu();
  }

  public void QuitButton() {
    Debug.Log("Saliendo");
    Application.Quit();
  }
}
