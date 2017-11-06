using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tower : MonoBehaviour {
    // Use this for initialization
    void Start () {
        this.transform.position = new Vector3(1 , 1, -0.7f);
    }
    void TurnToEnemy()
    {

    }
    // Update is called once per frame
    void Update() {
        /*RaycastHit[] hitinfo;
        var layermask = 1 << 8;
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hitinfo, 1.5f, layermask))
        {
            Vector3 relativePos = hitinfo.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, transform.up);
            transform.rotation = rotation;
            GetComponentInChildren<Gun>().FireAt(hitinfo.transform);
        }
        hitinfo = Physics.SphereCastAll(transform.position, 0.5f, transform.forward, 1.5f, layermask);
        if (hitinfo.Length != 0)
        {
            int nearest = 0;
            for (int i = 0; i < hitinfo.Length; i++)
            {
                if (hitinfo[i].distance <= hitinfo[nearest].distance)
                {
                    nearest = i;
                }
            }
            Vector3 relativePos = hitinfo[nearest].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, transform.up);
            transform.rotation = rotation;
            GetComponentInChildren<Gun>().FireAt(hitinfo[nearest].transform);
        }*/
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
}
