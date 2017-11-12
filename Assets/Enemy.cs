using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
  public float Health;
  public float Damage;
  public float Speed;
  public int valve;
        Transform Target;
    // public static EnemySpawner Manager;
    void Start()
    {
        Target = FindObjectOfType<Base>().transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = Target.position;
    }
    public void Initialize ()
    {
        transform.position = new Vector3(0, 0.7f, 4);
        Health = 10000f;
        Damage = 5f;
        Speed = 0.5f;
        valve = 10;
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
                    MoneyManager.AddMoney(valve);
                }
                other.gameObject.GetComponentInChildren<Bullet>().flag = false;
            }

        }
    }

    void FixedUpdate() {
        //float step = Speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(4,0,0), step);
    }
}
