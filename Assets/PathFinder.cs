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
        var targetPos = FindObjectOfType<Base>().transform.position;
        agent.CalculatePath(targetPos, path);
        if (path.status != NavMeshPathStatus.PathComplete)
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
        this.transform.position = new Vector3(0f, 0.7f, 4f);
    }
}
