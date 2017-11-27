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
        var col = this.GetComponent<Renderer>();
        Target = FindObjectOfType<Base>().transform;
        this.agent = this.GetComponent<NavMeshAgent>();
        this.transform.position = new Vector3(0f, 0.7f, 4f);
        agent.destination = Target.position;
        Health = health;
        Damage = damage;
        value = val;
        Speed = speed;
        if(type==1)//fast ene
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
                if (Health <= 0)
                {
                    Destroy(gameObject);
                    MoneyManager.AddMoney(value);
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
