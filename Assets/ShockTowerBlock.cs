using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShockTowerBlock : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            GetComponentInChildren<ShockTower>().enemyInRange.Add(other.gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            GetComponentInChildren<ShockTower>().enemyInRange.Remove(other.gameObject);
        }
    }

}
