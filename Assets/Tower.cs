using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Tower : MonoBehaviour {
    // Use this for initialization
    void Start () {
        //this.transform.position = new Vector3(2 , 0.7f, 2);
    }
    /*public bool Initialize(Vector3 pos)
    {
        GetComponentInParent<NavMeshObstacle>().enabled = true;
        var ispath = FindObjectOfType<PathFinder>().PathExists();
        GetComponentInParent<NavMeshObstacle>().enabled = false;
        if (!ispath)
        {
            Debug.Log("Road Blocker");
            return false;
        }
        else
        {
            GetComponentInParent<NavMeshObstacle>().enabled = true;
            return true;
        }
    }*/
    void TurnToEnemy()
    {
        var layermask = 1 << 8;
        Collider[] enemyInRange = Physics.OverlapSphere(transform.position, 2f, layermask);
        int nearest = 0;
        if (enemyInRange.Length > 0)
        {
            for (int i = 0; i < enemyInRange.Length; i++)
            {
                var distance = Vector3.Distance(enemyInRange[i].transform.position, transform.position);
                var nearestDistance = Vector3.Distance(enemyInRange[nearest].transform.position, transform.position);
                if (distance < nearestDistance)
                {
                    nearest = i;
                }
            }
            Vector3 relativePos = enemyInRange[nearest].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, transform.up);
            transform.rotation = rotation;
            GetComponentInChildren<Gun>().FireAt(enemyInRange[nearest].transform);
        }
    }
    // Update is called once per frame
    void Update() {
        TurnToEnemy();
    }
}
