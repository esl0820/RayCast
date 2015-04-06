using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject player; //assign in inspector

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Ray mouseCommandPoint = Camera.main.ScreenPointToRay (Input.mousePosition );
		RaycastHit moveToPoint = new RaycastHit();

		if (Physics.Raycast ( mouseCommandPoint , out moveToPoint, 1000f)){
			if (Input.GetMouseButton (0)) {
				Vector3 movement = moveToPoint.point - player.transform.position;
				Vector3 playerMove = movement.normalized;
				player.rigidbody.AddForce (playerMove * speed * Time.deltaTime);
				player.transform.LookAt(moveToPoint.point);
			}
		}
	}
}
