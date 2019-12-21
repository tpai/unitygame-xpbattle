using UnityEngine;
using System.Collections;

public class GJBase : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	private static GJBase m_instance;
	public static GJBase instance {
		get {
			if (m_instance == null) {
				m_instance = FindObjectOfType<GJBase>();
			}
			return m_instance;
		}
	}
#if UNITY_WEBGL || UNITY_WEBPLAYER
	public void AddScore (int score) {
		bool isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;
		
		int scoreValue = score;
		string scoreText = "Crash "+scoreValue.ToString ()+" times";
		int tableID = 78742; // your score table id
		string extraData = "";
		
		if (isSignedIn) {
			GameJolt.API.Scores.Add (scoreValue, scoreText, tableID, extraData, (bool success) => {
				Debug.Log ("Player score added!");
			});
		} else {
			string guestName = "Guest";
			GameJolt.API.Scores.Add(scoreValue, scoreText, guestName, tableID, extraData, (bool success) => {
				Debug.Log ("Guest score added!");
			});
		}
	}

	public void UnlockTrophy (int val) {
		if (val >= 10)
			GameJolt.API.Trophies.Unlock (33124, (bool success) => { Debug.Log ("Unlock gold trophy!"); });
		if (val >= 5)
			GameJolt.API.Trophies.Unlock (33123, (bool success) => { Debug.Log ("Unlock silver trophy!"); });
		if (val >= 1)
			GameJolt.API.Trophies.Unlock (33122, (bool success) => { Debug.Log ("Unlock bronze trophy!"); });
	}
#endif
}
