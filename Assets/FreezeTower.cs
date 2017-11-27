using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreezeTower : MonoBehaviour {
    public List<GameObject> enemyInRange;
    // Use this for initialization
    void Start () {
        enemyInRange = new List<GameObject>();
    }

    /*void FreezeEnemy()
    {
        var enemymask = LayerMask.GetMask("Enemy");
        var cellmask = LayerMask.GetMask("Cell");
        var size1 = new Vector3(1.5f, 1.5f, 1.5f);
        var size2 = new Vector3(1.3f, 1.3f, 1.3f);
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        Collider[] enemyInRange = Physics.OverlapBox(transform.position, size1,rotation, enemymask);
        Collider[] cellInRange = Physics.OverlapBox(transform.position, size2, rotation, cellmask);
        for (int i = 0; i < cellInRange.Length; i++)
        {
            cellInRange[i].gameObject.GetComponent<MeshRenderer>().material.color = new Color32(165, 242, 243, 1);
        }
        for (int i=0; i<enemyInRange.Length; i++)
        {
            enemyInRange[i].gameObject.GetComponent<MeshRenderer>().material.color = new Color32(0, 97, 242, 1);
            enemyInRange[i].gameObject.GetComponent<NavMeshAgent>().speed = (2f / 3f);
            
        }
 
    }*/
    
    // Update is called once per frame
    void Update () {
        //FreezeEnemy();
	}
    public void OnDestroy()
    {
        for(int i=0; i < enemyInRange.Count; i++)
        {
            enemyInRange[i].GetComponent<Freeze>().freezeLevel--;
        }
    }
}
