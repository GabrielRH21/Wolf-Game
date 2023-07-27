using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUserName : MonoBehaviour
{
  private float lifeTime = 0.1f;

  void Awake() {
      this.gameObject.GetComponent<TextMesh>().text = InputRecover.userName;
  }

  void Update() {
    lifeTime -= Time.deltaTime;
    if (transform.parent != null && transform.parent.gameObject.activeSelf) {
      transform.position = new Vector3(transform.parent.position.x - 0.2575f, transform.parent.position.y + 2, transform.parent.position.z);
    }
    Destroy(this.gameObject);
  }
}
