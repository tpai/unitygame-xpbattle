using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	public float speed = 1f;

	private Rigidbody2D m_rigidbody2D;

	void Start () {
		m_rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		Move (x);
	}

	void Move (float x) {
		m_rigidbody2D.velocity = new Vector2 (x * speed, m_rigidbody2D.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Mask1") {
			transform.position = GameObject.Find ("Mask2").transform.position;
		}
		else if (other.name == "Mask2") {
			transform.position = GameObject.Find ("Mask1").transform.position;
		}
	}
}
