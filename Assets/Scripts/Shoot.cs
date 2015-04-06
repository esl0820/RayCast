using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shoot : MonoBehaviour {

	public GameObject phaserBank;
	public GameObject phaser;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (phaser, phaserBank.transform.position, phaserBank.transform.rotation);
		}
	
	}
}
