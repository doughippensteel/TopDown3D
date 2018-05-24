using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetection : MonoBehaviour {
	public PlayerController player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Check for controller input

		if (Input.GetAxisRaw ("RHorizontal") != 0.0f || Input.GetAxisRaw ("RVertical") != 0.0f) {
			player.useController = true;
		}

		if (Input.GetKey (KeyCode.Joystick1Button0) ||
			Input.GetKey (KeyCode.Joystick1Button1) ||
			Input.GetKey (KeyCode.Joystick1Button2) ||
			Input.GetKey (KeyCode.Joystick1Button3) ||
			Input.GetKey (KeyCode.Joystick1Button4) ||
			Input.GetKey (KeyCode.Joystick1Button5) ||
			Input.GetKey (KeyCode.Joystick1Button6) ||
			Input.GetKey (KeyCode.Joystick1Button7) ||
			Input.GetKey (KeyCode.Joystick1Button8) ||
			Input.GetKey (KeyCode.Joystick1Button9) ||
			Input.GetKey (KeyCode.Joystick1Button10)) {
			player.useController = true;
		}

		//Check for mouse input

		if(Input.GetMouseButton (0)|| Input.GetMouseButton (1) || Input.GetMouseButton(2)){

			player.useController = false;
		}
		if (Input.GetAxisRaw ("Mouse X") != 0.0f || Input.GetAxisRaw ("Mouse Y") != 0.0f) {

			player.useController = false;
		}

		
	}
}
