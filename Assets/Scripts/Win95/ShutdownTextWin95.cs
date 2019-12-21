using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShutdownTextWin95 : MonoBehaviour {

	Text shutdownText;

	void Start () {
		shutdownText = GetComponent<Text> ();

		string contentTW = "謝謝你，老朋友";
		string contentEN = "Thank you, old friend.";
		string content;
		if (
			Application.systemLanguage == SystemLanguage.Chinese ||
			Application.systemLanguage == SystemLanguage.ChineseTraditional || 
			Application.systemLanguage == SystemLanguage.ChineseSimplified
		)
			content = contentTW;
		else
			content = contentEN;
		shutdownText.text = content;

		int passed = PlayerPrefs.GetInt ("Passed");
		PlayerPrefs.SetInt ("Passed", passed + 1);
#if UNITY_WEBGL || UNITY_WEBPLAYER
		GJBase.instance.UnlockRetroTrophy();
#endif
	}
}
