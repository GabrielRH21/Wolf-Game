using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
  public LevelManager deleg;
  void Start()
  {

  }

  void Update()
  {
    deleg.hideStart += hideStartMenu;
    deleg.showStart += showStartMenu;
  }

  private void hideStartMenu() {
    transform.GetChild(0).gameObject.SetActive(false);
  }

  private void showStartMenu() {
    transform.GetChild(0).gameObject.SetActive(true);
  }
}
