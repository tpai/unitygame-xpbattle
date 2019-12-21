using UnityEngine;
using System.Collections;

public class BackToStart : MonoBehaviour {

	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel ("Start");
		}
	}
}
