using UnityEngine;
using System.Collections;

public class Rebooting : MonoBehaviour {
	
	void Start () {
		Invoke ("Reboot", 4f);
	}

	void Reboot () {
		Application.LoadLevel ("Start");
	}
}
