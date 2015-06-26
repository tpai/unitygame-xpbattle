using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	public void CheckAlertBox () {
		if (PlayerPrefs.GetInt ("RestAlertBox") >= 100) {
			Application.LoadLevel ("Shutdown");
		}
		else {
			Application.LoadLevel ("Error");
		}
	}
}
