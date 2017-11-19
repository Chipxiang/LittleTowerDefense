using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class TowerBlockCollection : MonoBehaviour
{
    private static Object _TowerBlockPrefab;
    private Transform _holder;
    // Use this for initialization
    internal void Start()
    {
        this.transform.position = new Vector3(0f, 0.7f, 0f);
        _TowerBlockPrefab = Resources.Load("TowerBlock");
        _holder = this.transform;

    }
    public bool Spawn(Vector3 pos)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        var tower = (GameObject)Object.Instantiate(_TowerBlockPrefab, pos, rotation, _holder);
        var s = tower.GetComponentInChildren<Tower>();
        return s.Initialize();
        /*var flag = FindObjectOfType<PathFinder>().PathExists();
        if (!flag)
        {
            DestroyImmediate(tower);
        }
        return flag;*/
    }
}
