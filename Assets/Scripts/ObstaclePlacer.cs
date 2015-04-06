using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstaclePlacer : MonoBehaviour {

	public Transform obstaclePrefab; // assign in the inspector

	List<Transform> obstacleClones = new List<Transform>(); 

	//ObstaclePlacer places walls, remembers the walls it places
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {

		//generate ray before shooting raycase
		Ray cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition);

		//reserve in memory a blank object to hold impact data
		RaycastHit cursorRayInfo = new RaycastHit();

		if ( Physics.Raycast ( cursorRay, out cursorRayInfo, 1000f)) {
			Debug.Log ( cursorRayInfo.collider.name );

			if (Input.GetMouseButtonDown (1)) {
				Transform newClone = Instantiate ( obstaclePrefab, cursorRayInfo.point, Quaternion.Euler (0f,Random.Range (-90f,90f),0f)) as Transform;
				obstacleClones.Add (newClone);
			}
		}

		if ( Input.GetKeyDown (KeyCode.K)) {
			foreach (Transform clone in obstacleClones) {
				clone.Rotate (0f, 90f, 0f);
			}
		}
	}
}
