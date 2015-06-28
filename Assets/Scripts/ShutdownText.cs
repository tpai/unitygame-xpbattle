using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShutdownText : MonoBehaviour {

	Text shutdownText;

	void Start () {
		shutdownText = GetComponent<Text> ();

		string contentTW = "呿 沒有天天在過年的啦";
		string contentEN = "Sometimes you just get lucky";
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
	}
}
