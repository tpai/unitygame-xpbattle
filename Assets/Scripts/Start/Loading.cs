using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	public float speed = 1f;

	private int time = 0;
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
			LogoFadeOut (false);
		}
		else if (other.name == "Mask2") {
			transform.position = GameObject.Find ("Mask1").transform.position;
			LogoFadeOut (true);
		}
	}

	void LogoFadeOut (bool b) {
		if (b)
			time ++;
		else
			time --;

		if (time > 10) {
			time = 10;
			SceneManager.LoadScene(Scene.Main);
		} else if (time < -5) {
			time = -5;
			SceneManager.LoadScene(Scene.Win95Start);
		}

		Color color = Color.white;
		color.a = time * .1f;

		GameObject.Find ("Flag").GetComponent<SpriteRenderer> ().color = color;
		GameObject.Find ("Title").GetComponent<SpriteRenderer> ().color = color;
	}
}
