using UnityEngine;
using System.Collections;

public class Phaser : MonoBehaviour {

	public GameObject player;
	public float speed = 200f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		rigidbody.AddForce (transform.forward * speed * Time.deltaTime);
	}
}
