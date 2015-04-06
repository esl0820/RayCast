using UnityEngine;
using System.Collections;

public class Hurtable : MonoBehaviour {

	public float health = 100f;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0f) {
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy ( gameObject );
		}
	}
}
