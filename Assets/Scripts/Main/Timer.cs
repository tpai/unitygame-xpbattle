using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

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
			Application.LoadLevel ("Shutdown");

		GetComponent<Image>().fillAmount = m_nowTime / maxTime;
	}
}
