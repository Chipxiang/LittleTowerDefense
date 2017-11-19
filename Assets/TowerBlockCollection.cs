using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class TowerBlockCollection : MonoBehaviour
{
    private static Object _TowerBlockPrefab;
    private Transform _holder;
    public bool roadBlocker;
    // Use this for initialization
    internal void Start()
    {
        this.transform.position = new Vector3(0f, 0.7f, 0f);
        _TowerBlockPrefab = Resources.Load("TowerBlock");
        _holder = this.transform;
        roadBlocker = false;

    }
    public IEnumerator Spawn(Vector3 pos)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        var tower = (GameObject)Object.Instantiate(_TowerBlockPrefab, pos, rotation, _holder);
        for (int i = 0; i<tower.GetComponentsInChildren<MeshRenderer>().Length;i++){
            tower.GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
        }
        yield return null;
        var flag = FindObjectOfType<PathFinder>().PathExists();
        if (!flag)
        {
            DestroyImmediate(tower);
            roadBlocker = true;
        }
        else
        {
            roadBlocker = false;
            for (int i = 0; i < tower.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                tower.GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
            }
        }
        yield break;
    }
    public void Update()
    {
        
    }
}
