using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	public string shutDownScene = Scene.Shutdown;
	public float maxTime = 30f;

	private bool m_countdown = false;
	private float m_nowTime;

	void Start () {
		m_nowTime = maxTime;

		Invoke ("CountDown", 3.5f);
	}

	void CountDown () {
		m_countdown = true;
	}

	void FixedUpdate () {

		if (m_countdown)
			m_nowTime -= Time.deltaTime;

		if (m_nowTime <= 0)
			SceneManager.LoadScene(shutDownScene);

		GetComponent<Image>().fillAmount = m_nowTime / maxTime;
	}
}
