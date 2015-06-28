﻿using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	private Rigidbody2D m_rigidbody2D;
	
	void Start () {
		m_rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		Move (x);
	}
	
	void Move (float x) {
		m_rigidbody2D.velocity = new Vector2 (x * 10f, m_rigidbody2D.velocity.y);

		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, -2.2f, 2.2f),
			transform.position.y,
			transform.position.z
		);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "Error") {
			Application.LoadLevel ("Error");
		}
	}
}
