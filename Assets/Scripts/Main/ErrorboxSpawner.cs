using UnityEngine;
using System.Collections;

public class ErrorboxSpawner : MonoBehaviour {

	public GameObject errorboxPrefab;
	public int errorboxAmount = 50;

	void Start () {
		Invoke ("StartSpawn", 1f);
	}

	void StartSpawn () {
		StartCoroutine ("SpawnAlertBox", errorboxAmount);
	}

	IEnumerator SpawnAlertBox (int amt) {
		for(int i=0;i<amt;i++) {
			GameObject errorbox = (GameObject)Instantiate (
				errorboxPrefab,
				new Vector3 (
					Random.Range (-2f, 2f),
					2f,
					0f
				),
				Quaternion.identity
			);
			errorbox.GetComponent<Rigidbody2D>().gravityScale = Random.Range (.1f, 1f);
			yield return new WaitForSeconds (.5f);
		}
	}
}
