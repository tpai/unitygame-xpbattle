using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour {
	private bool is_clickable = false;

	void Start () {
		Invoke ("Wait", 1f);
	}

	void Wait () {
		is_clickable = true;
	}

	void FixedUpdate () {
		if (is_clickable && Input.anyKeyDown) {
			SceneManager.LoadScene(Scene.Start);
		}
	}
}
