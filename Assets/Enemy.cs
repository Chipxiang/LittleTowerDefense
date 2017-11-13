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
    private NavMeshAgent agent;
    private Transform Target;
    // public static EnemySpawner Manager;
    void Start()
    {
        
    }
    public void Initialize ()
    {
        Target = FindObjectOfType<Base>().transform;
        this.transform.position = new Vector3(0, 1, 4);
        Health = 10000f;
        Damage = 5f;
        Speed = 0.5f;
        valve = 10;
        this.agent = GetComponent<NavMeshAgent>();
        agent.destination = Target.position;
// Debug.Log(this.transform.position);
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
        //Debug.Log(this.transform.position);
        //float step = Speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(4,0,0), step);
    }
}
