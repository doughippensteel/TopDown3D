using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float flashTime;
	float flashCounter;
	public int maxHealth;

	[SerializeField]
	int currentHeatlth;

	public GunController gun;

	Vector3 moveInput;
	Vector3 moveVel;

	Rigidbody rig;
	Renderer rend;
	Color originalColor;
	[SerializeField]
	Camera mainCam;

	public bool useController;
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody> ();
		currentHeatlth = maxHealth;
		rend = GetComponent<Renderer> ();
		originalColor = rend.material.GetColor ("_Color");

		mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical"));
		moveVel = moveInput * moveSpeed;

		#region Mouse

		if (!useController) {
				//Rotate with mouse
				Ray camRay = mainCam.ScreenPointToRay (Input.mousePosition);
				Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
				float rayLength;

				if (groundPlane.Raycast (camRay, out rayLength)) {

					Vector3 lookPoint = camRay.GetPoint (rayLength);
					Debug.DrawLine (camRay.origin, lookPoint, Color.blue);

					transform.LookAt (new Vector3 (lookPoint.x, transform.position.y, lookPoint.z));
				}
		
		
		if (Input.GetMouseButtonDown(0)){
			gun.isFiring = true;

		}
			
		if (Input.GetMouseButtonUp(0)){
				gun.isFiring = false;
			}
		}
		#endregion
		#region  Controller	 
		//Rotate with Controller

		if (useController) {
			Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
			if (playerDirection.sqrMagnitude > 0.0f) {
				transform.rotation = Quaternion.LookRotation (playerDirection, Vector3.up);

			}
			if (Input.GetKeyDown(KeyCode.JoystickButton5)){
				gun.isFiring = true;

			}

			if (Input.GetKeyUp(KeyCode.JoystickButton5)){
				gun.isFiring = false;
			}
		}
		#endregion

		if (currentHeatlth <= 0) {
			gameObject.SetActive (false);
		}
		if (flashCounter > 0) {
			flashCounter -= Time.deltaTime;
			if (flashCounter <= 0) {
				rend.material.SetColor ("_Color", originalColor);
			}
		}
		
	}

	void FixedUpdate(){
		rig.velocity = moveVel;
		
	}

	public void TakeDamage(int damage){
		currentHeatlth -= damage;
		flashCounter = flashTime;
		rend.material.SetColor ("_Color", Color.white);
	}
}
