using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

	bool foundIgloo = false;
	bool foundShip = false;
	bool foundRafts1 = false;
	bool foundRafts2 = false;

	public Transform tardis = null;
	public Transform igloo = null;
	public Transform ship = null;
	public Transform rafts1 = null;
	public Transform rafts2 = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distIgloo = Vector3.Distance(tardis.position, igloo.position); 
		float distShip = Vector3.Distance(tardis.position, ship.position);
		float distRafts1 = Vector3.Distance(tardis.position, rafts1.position);
		float distRafts2 = Vector3.Distance(tardis.position, rafts2.position);

		string textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";

		if (!foundShip) {

			if (distShip < 100) {
				textBuffer += "\nMaybe we should check for survivors!";
				textBuffer += "\nPress TAB to check for survivors";
				if (Input.GetKeyDown (KeyCode.Tab)) {
					foundShip = true;
				}
		
			} else if (distShip < 1200) {
				textBuffer += "\nDoctor, look! A shipwreck!";
			} else {
				textBuffer += "\nWell, Doctor... What nice ice we've found";
			}
		} else {
			textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
			textBuffer += "\nThere were two people left on the boat,";
			textBuffer += "\nThey told us that the life boats went in the opposite direction";
			textBuffer += "\nof where the boat is facing!";
		}
		if (!foundRafts1 && foundShip) {
					
					if (distRafts1 < 100) {
						textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
						textBuffer += "\nThere are a couple survivors down there!";
						textBuffer += "\nPress TAB to pick them up!";
						if (Input.GetKeyDown (KeyCode.Tab)) {
							foundRafts1 = true;
						}
					} else if (distRafts1 < 400) {
						textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
						textBuffer += "\nDoctor, look! Some rafts! Maybe there are some survivors down there!";	
					}
				} else if (foundRafts1) {
					textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
					textBuffer += "\nThere were a few survivors down there!";
					textBuffer += "\nThey told us that they saw some other rafts that headed";
					textBuffer += "\n off the right side of the ship!";
				}
		if (!foundRafts2 && foundRafts1 && foundShip) {
				if (distRafts2 < 100) {
					textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
					textBuffer += "\nHey, look! There's are a bunch of survivors down there!";
					textBuffer += "\nPress TAB to pick them up!";
					if (Input.GetKeyDown (KeyCode.Tab)) {
						foundRafts2 = true;
					}
					} else if (distRafts2 < 400) {
						textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
						textBuffer += "\nDoctor, look! More rafts!";
						textBuffer += "\nThere must be more survivors down there!";	
					}
				} else if (foundRafts2) {
					textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
					textBuffer += "\nThere were a bunch of survivors!";
					textBuffer += "\nThey said that most of them went inland to make camp!";
					textBuffer += "\nThere must be some more survivors on this island!";
				}
		if (!foundIgloo && foundRafts2 && foundRafts1 && foundShip) {
			if (distIgloo < 60) {
				textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
				textBuffer += "\nWow! They managed to make a shelter over here!";
				textBuffer += "\nA lot of survivors come out to greet us";
				textBuffer += "\nPress TAB to pick them up!";
				if (Input.GetKeyDown (KeyCode.Tab)) {
					foundIgloo = true;
				}
			} else if (distIgloo < 200) {
				textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
				textBuffer += "\nHey, Doctor! Look! An igloo!";
				textBuffer += "\nThe rest of the survivors must have set up camp there!";	
			}
		} else if (foundIgloo) {
			textBuffer = "PLANET: EARTH, TEMPERATURE: COLD, HABITABILITY: MEH";
			textBuffer += "\nGood job, Doctor!";
			textBuffer += "\nWe managed to collect all of the survivors!";
			textBuffer += "\nGG";
		}




		GetComponent<Text>().text = textBuffer;
	}

}

//if (!foundSurvivors) {
//	if (distance < 50) {
//		textBuffer += "\nDoctor, look! An igloo! The survivors must be in there!";
//		textBuffer += "\nPress TAB to pick them up!";
//		if (Input.GetKeyDown (KeyCode.Tab)){
//			foundSurvivors = true;
//		}
//	} else if (distance < 600) {
//		textBuffer += "\nDoctor, look! More rafts! The survivors must be on this island!";
//	} else if (distance < 1000) {
//		textBuffer += "\nDoctor, look! Rafts! There are survivors somewhere!";
//	} else if (distance < 2000) {
//		textBuffer += "\nDoctor, look! A shipwreck!";
//	} else {
//		textBuffer += "\nWhat nice ice we've found.";
//	}
//
//} else {
//	textBuffer += "\nWell done, Doctor! You've saved them!";
//}