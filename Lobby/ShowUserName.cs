using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUserName : MonoBehaviour
{

  void Awake() {
      this.gameObject.GetComponent<TextMesh>().text = InputRecover.userName;
  }

  void Update() {
    if (transform.parent != null && transform.parent.gameObject.activeSelf) {
      transform.position = new Vector3(transform.parent.position.x - 0.2575f, transform.parent.position.y + 2, transform.parent.position.z);
    }
    Destroy(this.gameObject);
  }
}
