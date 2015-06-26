using UnityEngine;
using System.Collections;

public class Rebooting : MonoBehaviour {
	
	void Start () {
		Invoke ("Reboot", 3f);
	}

	void Reboot () {
		Application.LoadLevel ("Start");
	}
}
