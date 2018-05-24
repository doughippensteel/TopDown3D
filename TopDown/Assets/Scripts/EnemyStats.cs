using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
	public int maxHealth;
	[SerializeField]
	int currentHealth;

	public int damage;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (currentHealth <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void TakeDamage (int damage){

		currentHealth -= damage;
	}
}
