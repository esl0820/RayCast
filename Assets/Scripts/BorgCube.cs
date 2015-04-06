using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BorgCube : MonoBehaviour {


	public GameObject player;
	public float speed = 200f;
	bool isCloseEnough;
	bool isInViewCone;
	bool isInLineOfSight;
	public float distance = 500f;
	public GameObject borgCube;

	
	// once per physics frame or something
	void FixedUpdate () {
		float distShip = Vector3.Distance(player.transform.position, borgCube.transform.position);
			if (distShip < 1000f) {
				isCloseEnough = true;
			} else {
				isCloseEnough = false;
			}
			if (Vector3.Angle (player.transform.position, borgCube.transform.position) < 90f) {
				isInViewCone = true;
			} else {
				isInViewCone = false;
			}
		Ray raymond = new Ray (player.transform.position, borgCube.transform.position);
		RaycastHit hitRaymond = new RaycastHit();
		Physics.Raycast (raymond, out hitRaymond);
			if (hitRaymond.collider != null) {
				if (hitRaymond.collider.gameObject.tag == "Player") {
					isInLineOfSight = true;
				} else {
					isInLineOfSight = false;
				}
			}
			if (isCloseEnough && isInViewCone && isInLineOfSight) {
				Vector3 movement = player.transform.position - borgCube.transform.position;
				Vector3 borgCubeMove = movement.normalized;
				rigidbody.AddForce (borgCubeMove * speed * Time.deltaTime); 
			} else {
				rigidbody.AddForce (transform.forward * speed * Time.deltaTime);
				Ray ray = new Ray (borgCube.transform.position, borgCube.transform.forward);
					if (Physics.Raycast (ray,  10f)) {
						transform.Rotate (0f, 90f, 0f);
					} else {
						rigidbody.AddForce (transform.forward * speed * Time.deltaTime);
					}
			}
	}
}