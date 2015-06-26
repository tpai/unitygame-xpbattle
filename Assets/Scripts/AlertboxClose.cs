using UnityEngine;
using System.Collections;

public class AlertboxClose : MonoBehaviour {

	public void Close () {
		PlayerPrefs.SetInt ("RestAlertBox", PlayerPrefs.GetInt ("RestAlertBox")+1);
		Destroy (gameObject);
	}
}
