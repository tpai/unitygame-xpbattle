using UnityEngine;
using System.Collections;

public class AlertboxSpawner : MonoBehaviour {

	public GameObject alertboxPrefab;
	public int alertBoxAmount = 50;

	private bool m_trick = false;
	private Transform m_canvas;
	private Transform m_alertboxes;

	void Start () {
		PlayerPrefs.SetInt ("RestAlertBox", 0);

		m_canvas = GameObject.Find ("Canvas").transform;
		m_alertboxes = m_canvas.Find("Alertboxes");

		Invoke ("StartSpawn", 3.6f);

		InvokeRepeating ("DetectTrick", 5f, .5f);
	}

	void DetectTrick () {
		if (!m_trick && m_alertboxes.childCount == 0) {
			m_trick = true;
			Invoke ("StartSpawn", .1f);
		}
	}

	void StartSpawn () {
		StartCoroutine ("SpawnAlertBox", alertBoxAmount);
	}

	IEnumerator SpawnAlertBox (int amt) {
		for(int i=0;i<amt;i++) {
			GameObject alertbox = (GameObject)Instantiate (alertboxPrefab);
			alertbox.transform.SetParent (m_alertboxes);
			alertbox.GetComponent<RectTransform>().localScale = Vector3.one;
			alertbox.GetComponent<RectTransform>().position = m_canvas.position + new Vector3 (
				Random.Range (-500f, 400f),
				Random.Range (-181f, 240f),
				0f
			);
			yield return new WaitForSeconds (.05f);
		}
	}
}
