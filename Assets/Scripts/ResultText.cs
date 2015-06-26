using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultText : MonoBehaviour {

	Text resultText;

	void Start () {
		resultText = GetComponent<Text>();

		string prefix = "A problem has been detected and windoms has been shutdown to prevent damage to your computer.\n\n";
		string suffix = "\n\n*** KGJ: 0x20150626 (0xIH0VGj8DTl8, 0xfYWLIM3Gklw, 0xVppL8DTD-L0, 0x3co6_gPw1Hw)";
		string content = "";
		if (PlayerPrefs.GetInt ("RestAlertBox") <= 10) {
			content = "好吧我不得不說你真的很沒有耐心，竟然就這樣關機了，我實在是對你很失望。\n\n不過呢，念在你有打開我遊戲玩一下的份上我就不跟你計較了，雖然你還是沒有完全破關。\n\n對啊！難道你不想試試關完全部的警告視窗之後再按關機嗎？試試嘛試試嘛試試嘛。";
		}
		else if (PlayerPrefs.GetInt ("RestAlertBox") <= 25) {
			content = "根據你關的速度與點擊的力道，我可以推測出你一定是一個很常用電腦跟智慧型手機的人。看吧？我猜對了！\n\n欸欸你都關一半了，不要半途而廢嘛，全部點掉又不會怎樣，幹嘛這麼小氣，再堅持一下啦！\n\n做事情要有頭有尾，既然開了這個遊戲就把它玩完，既然都開始關了，就關完全部視窗再關機。";
		}
		else if (PlayerPrefs.GetInt ("RestAlertBox") < 50) {
			content = "欸阿差沒幾個你也不關。厚！朋友這樣當的啦，快點快點，再重新玩一次把它全部點完啦！\n\n也才五十個而已，又不是一百個，你嘛卡拜託耶，這樣子放棄實在是太沒品了啦！\n\n好視窗不關嗎？多點幾下，馬上就不痛了喔，真的啦！不騙你，趕快把它點完。";
		}
		else if (PlayerPrefs.GetInt ("RestAlertBox") < 100) {
			content = "不只五十個？喔喔... 那個，那個只是bug啦，程式沒寫好，這五十個再點完真的就沒有了，相信我(之術)！\n\n好啦，別生氣嘛，我真的不是故意的，小心駛得萬年船嘛，意外總是會發生。\n\n真的！我跟你保證，這是最後一次，如果再有五十個，你就直接把遊戲關掉，然後來海景第一排找我。";
		}
		resultText.text = prefix + content + suffix;
	}
}
