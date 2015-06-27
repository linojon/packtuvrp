using UnityEngine;
using System.Collections;

public class HeadLookWalk : MonoBehaviour {
	public bool walking = false;
	public float velocity = 0.7f;

	private CharacterController controller;

	void Start() {
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		if (keyPressed()) {
			walking = !walking;
		}
		if (walking) {
			controller.SimpleMove (Camera.main.transform.forward * velocity);
		}
	}
	
	private bool keyPressed() {
#if (UNITY_ANDROID || UNITY_IPHONE)
		return Cardboard.SDK.CardboardTriggered;
#else
		return Input.anyKeyDown;
#endif
	}

}
