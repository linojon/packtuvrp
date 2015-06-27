using UnityEngine;
using System.Collections;

public class HeadLookWalk : MonoBehaviour {
	public float velocity = 0.7f;

	private CharacterController controller;
	private AudioSource footsteps;
	private Transform head;
	private Transform body;
	private HeadGesture gesture;
	private bool walking;

	void Start() {
		controller = GetComponent<CharacterController> ();
		footsteps = GetComponent<AudioSource> ();
		head = Camera.main.transform.Find ("MeHead");
		body = transform.Find ("MeBody");
		gesture = GameObject.Find ("GameController").GetComponent<HeadGesture> ();
		walking = false;
	}

	void Update () {
		if (gesture.isMovingDown || keyPressed()) {
			walking = !walking;
		}
		if (walking) {
			controller.SimpleMove (Camera.main.transform.forward * velocity);
			body.rotation = Quaternion.Euler (new Vector3 (0.0f, head.eulerAngles.y, 0.0f));
			if (!footsteps.isPlaying) {
				footsteps.Play ();
			} 
		} else { // not walking
			footsteps.Stop();
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
