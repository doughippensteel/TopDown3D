using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float followSpeed = 3f;

	public Transform player;

	Vector3 centeredPosition;

	// Use this for initialization
	void Start () {
		centeredPosition = transform.position - player.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = player.position + centeredPosition;
		transform.position = Vector3.Lerp (transform.position, targetPosition,followSpeed* Time.deltaTime);
		
	}
}
