using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class putText : MonoBehaviour
{
  public LevelManager deleg;
  void Start()
  {

  }

  void Update()
  {
    deleg.showText += write;
  }

  private void write(string mes) {
    this.GetComponent<Text>().text = mes;
  }
}
