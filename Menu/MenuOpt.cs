using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpt : MonoBehaviour
{
  public LevelManager deleg;

  void Start() {

  }

  void Update() {
    deleg.hideMenu += hideMainMenu;
    deleg.showMenu += showMainMenu;
  }

  private void hideMainMenu() {
    transform.GetChild(0).gameObject.SetActive(false);
  }

  private void showMainMenu() {
    transform.GetChild(0).gameObject.SetActive(true);
  }
}
