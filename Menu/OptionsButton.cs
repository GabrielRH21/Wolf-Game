using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
  public LevelManager deleg;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    deleg.showOpt += showOptsMenu;
    deleg.hideOpt += hideOptsMenu;
  }

  private void showOptsMenu() {
    transform.GetChild(0).gameObject.SetActive(true);
  }

  private void hideOptsMenu() {
    transform.GetChild(0).gameObject.SetActive(false);
  }
}
