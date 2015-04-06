using UnityEngine;
using System.Collections;

public class NPCRaycast : MonoBehaviour {

	public float speed = .5f;
	float randy;
	public float distance = 3f;

	//put this on a capsule with a rigidbody
	// Use this for initialization
	void Start () {
	
	}
	
	// FixedUpdate is called once per physics frame
	void FixedUpdate () {

		GetComponent<Rigidbody>().AddForce (transform.forward * speed, ForceMode.VelocityChange);

		// generate ray
		Ray ray = new Ray(gameObject.transform.position, transform.forward);

		// shoot the raycast
		if (Physics.Raycast (ray, distance)) {
			transform.Rotate (0f, Random.Range (-90f,90f), 0f);

		}
	}
}
