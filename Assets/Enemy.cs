using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float Health;
    public float Damage;
    public float Speed;
    public int value;
    private NavMeshAgent agent;
    private Transform Target;
    
    // public static EnemySpawner Manager;
    void Start()
    {
    }
    public void Initialize (float health, float damage,float speed,int val,int type)
    {
        Health = health;
        Damage = damage;
        value = val;
        Speed = speed;
        var col = this.GetComponent<Renderer>();
        Target = FindObjectOfType<Base>().transform;
        this.agent = this.GetComponent<NavMeshAgent>();
        this.transform.position = new Vector3(0, 0.7f, 4);
        agent.destination = Target.position;
        GetComponent<Freeze>().freezeLevel = 0;
        if (type == 1)//fast ene
        {
            Color fast = Color.green;
            col.material.color = fast;
        }
        else if (type == 2)
        {
            Color strong = Color.yellow;
            col.material.color = strong;
        }
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
                other.gameObject.GetComponentInChildren<Bullet>().flag = false;
            }

        }
    }

    void FixedUpdate() {
        if (Health <= 0)
        {
            Destroy(gameObject);
            
            MoneyManager.AddMoney(value);
        }
    }
}
