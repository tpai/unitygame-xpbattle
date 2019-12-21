using UnityEngine;
using UnityEngine.SceneManagement;

public class Rebooting : MonoBehaviour {
	
	void Start () {
		Invoke ("Reboot", 5f);
	}

	void Reboot () {
		SceneManager.LoadScene(Scene.Start);
	}
}
