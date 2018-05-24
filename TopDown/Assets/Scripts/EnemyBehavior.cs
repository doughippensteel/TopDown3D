using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {
	Rigidbody rig;

	//public float moveSpeed;
	public float hearingRange;

	public Light eyes;
	public float sightDistance;
	public float sightAngle;
	public PlayerController player;
	public LayerMask visionMask;

	public NavMeshAgent agent;
	// Use this for initialization
	void Start () {

		rig = GetComponent<Rigidbody> ();
		agent = GetComponent<NavMeshAgent> ();
		player = FindObjectOfType<PlayerController> ();
		sightAngle = eyes.spotAngle;
		eyes.enabled =false;

	}
	
	// Update is called once per frame
	void Update () {
		float distFromPlayer = Vector3.Distance (transform.position, player.transform.position);
		if (distFromPlayer <= hearingRange) {
			transform.LookAt (player.transform.position);
		}
		if (PlayerSpotted()) {
			eyes.enabled = true;
		}
		
	}
	bool PlayerSpotted(){
		if (Vector3.Distance (transform.position, player.transform.position) <= sightDistance) {
			Vector3 dirToPlayer =( player.transform.position - transform.position).normalized;
			float angleBetweenEnemyandPlayer = Vector3.Angle (transform.forward, dirToPlayer);
			if (angleBetweenEnemyandPlayer < sightAngle / 2f) {
				if(!Physics.Linecast(transform.position,player.transform.position,visionMask)){
					return true;
				}
			}
		}
		return false;
	}

	void FixedUpdate(){
		if (PlayerSpotted()) {
			//rig.velocity = transform.forward * moveSpeed;
			agent.SetDestination(player.transform.position);
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		Gizmos.DrawRay (transform.position, transform.forward * sightDistance);
	}

}
