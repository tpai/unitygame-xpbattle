using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	
	private Rigidbody2D m_rigidbody2D;
	
	void Start () {
		m_rigidbody2D = GetComponent<Rigidbody2D> ();

		if (PlayerPrefs.GetInt ("Crashed") >= 10) {
			GetComponent<SpawnCursor>().enabled = true;
		}
	}
	
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		Move (x);
	}
	
	void Move (float x) {
		m_rigidbody2D.velocity = new Vector2 (x * 10f, m_rigidbody2D.velocity.y);

		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, -2.226f, 2.223f),
			transform.position.y,
			transform.position.z
		);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.collider.tag == "Error") {
			int crashed = PlayerPrefs.GetInt ("Crashed");
			PlayerPrefs.SetInt ("Crashed", crashed + 1);
#if UNITY_WEBGL || UNITY_WEBPLAYER
			GJBase.instance.AddScore (crashed + 1);
#endif
			SceneManager.LoadScene(Scene.Error);
		}
	}
}
