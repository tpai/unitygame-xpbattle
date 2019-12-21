using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWin95 : MonoBehaviour {
	public float m_nowTime = 5f;

	void Update () {
		m_nowTime -= Time.deltaTime;

		if (m_nowTime <= 0)
			SceneManager.LoadScene(Scene.Win95Main);
	}
}
