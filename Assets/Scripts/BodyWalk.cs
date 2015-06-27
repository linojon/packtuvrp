using UnityEngine;
using System.Collections;

public class BodyWalk : MonoBehaviour {
	private HeadLookWalk lookWalk;
	private AudioSource footsteps;
	private Transform head;
	private Transform body;

	void Start () {
		lookWalk = GetComponent<HeadLookWalk> ();
		footsteps = GetComponent<AudioSource> ();
		head = Camera.main.transform;
		body = transform.Find ("MeBody");
	}

	void Update () {
		if (lookWalk.walking) {
			body.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, head.transform.eulerAngles.y, 0.0f));
			if (!footsteps.isPlaying) {
				footsteps.Play ();
			}
		} else { // not walking
			footsteps.Stop ();
		}
	}
}
