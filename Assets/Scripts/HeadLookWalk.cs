using UnityEngine;
using System.Collections;

public class HeadLookWalk : MonoBehaviour {
	public bool walking = false;
	public float velocity = 0.7f;

	private CharacterController controller;
	private Clicker clicker = new Clicker();

	void Start() {
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		if (clicker.clicked()) {
			walking = !walking;
		}
		if (walking) {
			controller.SimpleMove (Camera.main.transform.forward * velocity);
		}
	}
}
