using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultText : MonoBehaviour {

	Text resultText;

	void Start () {
		resultText = GetComponent<Text>();

		string prefix = "A problem has been detected and windoms has been shutdown to prevent damage to your computer.\n\n";
		string suffix = "\n\n*** KGJ: 0x20150626 (0xIH0VGj8DTl8, 0xfYWLIM3Gklw, 0xVppL8DTD-L0, 0x3co6_gPw1Hw)";
		string content = "加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎加油好嗎\n\n你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了你弱爆了\n\n有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎有很難嗎";

		resultText.text = prefix + content + suffix;
	}
}
