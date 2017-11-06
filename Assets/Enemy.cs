using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Health;
	public float Damage;
	public float Speed;
    Transform Target;
    // public static EnemySpawner Manager;
    void Start()
    {
        Target = FindObjectOfType<Base>().transform;
    }
    public void Initialize ()
	{
        transform.position = new Vector3(0, 4, -0.7f);
		Health = 25f;
		Damage = 5f;
		Speed = 0.5f;
	}
	
	 internal void OnCollisionEnter (Collision other) {
		if(other.gameObject.GetComponent<Base>())
		{
			// HitBase();
			Destroy(gameObject);
		}
		if(other.gameObject.GetComponentInChildren<Bullet>())
		{
            if (other.gameObject.GetComponentInChildren<Bullet>().flag)
            {
                float damage = other.gameObject.GetComponentInChildren<Bullet>().damage;
                Health -= damage;
                Debug.Log(Health);
                if (Health <= 0)
                {
                    Destroy(gameObject);
                }
                other.gameObject.GetComponentInChildren<Bullet>().flag = false;
            }
			
		}
	}
	
	void FixedUpdate() {
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(4,0,0), step);
    }
}
