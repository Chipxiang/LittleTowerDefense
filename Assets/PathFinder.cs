using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour {
    private NavMeshAgent agent;
    private Transform target;
    private NavMeshPath path;
    // Use this for initialization
    void Start () {
        target = FindObjectOfType<Base>().transform;
        this.transform.position = new Vector3(0, 0.7f, 4);
        this.agent = this.GetComponent<NavMeshAgent>();
        
    }
    public bool PathExists()
    {
        path = new NavMeshPath();
        var targetPos = target.position;
        agent.CalculatePath(targetPos, path);
        Debug.Log("Calculated Path");
        if (path.status == NavMeshPathStatus.PathPartial)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    // Update is called once per frame
    void Update () {
        this.transform.position = new Vector3(-0.5f, 0.7f, 4.5f);
    }
}
