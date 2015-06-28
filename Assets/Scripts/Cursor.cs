using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * 5f;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Error") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
