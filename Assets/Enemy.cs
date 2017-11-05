using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Health;
	public float Damage;
	public float Speed; 
	public Transform Target = GameObject.Find("Base").transform;
	// public static EnemySpawner Manager;
	
	public void Initialize ()
	{
		Health = 25f;
		Damage = 2f;
		Speed = 0.2f;
	}
	
	internal void OnCollisionEnter (Collision other) {
		string name = other.gameObject.name;
		// print("THIS " + name);
		if(name == "Base")
		{
			// HitBase();
			Destroy(gameObject);
		}
		if(name == "Bullet")
		{ 
			//var damage = other.gameObject.GetComponent<Bullet>().whatever;
			//Health -= damage;
		}
	}
	
	void FixedUpdate() {
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(4,0,0), step);
	}
}
