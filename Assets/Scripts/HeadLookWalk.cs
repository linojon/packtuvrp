using UnityEngine;
using System.Collections;

public class HeadLookWalk : MonoBehaviour {
	public float velocity = 0.7f;
	private CharacterController controller;
	private HeadGesture gesture;
	private bool walking;

	void Start() {
		controller = GetComponent<CharacterController> ();
		gesture = GameObject.Find ("GameController").GetComponent<HeadGesture> ();
		walking = false;
	}

	void Update () {
		if (gesture.isMovingDown || keyPressed()) {
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
