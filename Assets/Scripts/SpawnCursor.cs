using UnityEngine;
using System.Collections;

public class SpawnCursor : MonoBehaviour {

	public GameObject cursorPrefab;

	private AudioSource m_audioSource;

	void Start () {
		m_audioSource = GetComponent<AudioSource> ();

		InvokeRepeating ("Spawn", 3.5f, 1f);
	}
	
	void Spawn () {
		m_audioSource.Play ();
		Instantiate (cursorPrefab, transform.position, Quaternion.identity);
	}
}
