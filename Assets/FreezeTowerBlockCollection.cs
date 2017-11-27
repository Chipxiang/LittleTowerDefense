using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


public class FreezeTowerBlockCollection : MonoBehaviour
{
    private static Object _FreezeTowerBlockPrefab;
    private Transform _holder;
    public bool roadBlocker;
    public bool spawnFinished;
    // Use this for initialization
    internal void Start()
    {
        this.transform.position = new Vector3(0f, 0.7f, 0f);
        _FreezeTowerBlockPrefab = Resources.Load("FreezeTowerBlock");
        _holder = this.transform;
        roadBlocker = false;

    }
    public IEnumerator Spawn(GameObject cell)
    {
        var pos = new Vector3(cell.transform.position.x, cell.transform.position.y + 0.7f, cell.transform.position.z);
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        var tower = (GameObject)Object.Instantiate(_FreezeTowerBlockPrefab, pos, rotation, _holder);
        cell.GetComponent<Cell>().Toweron = tower;
        for (int i = 0; i < tower.GetComponentsInChildren<MeshRenderer>().Length; i++)
        {
            tower.GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
        }
        yield return null;
        var flag = FindObjectOfType<PathFinder>().PathExists();
        if (!flag)
        {
            DestroyImmediate(tower);
            cell.GetComponent<Cell>().isBuilt = false;
            roadBlocker = true;
        }
        else
        {
            roadBlocker = false;
            for (int i = 0; i < tower.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                tower.GetComponentsInChildren<MeshRenderer>()[i].enabled = true;
            }
            MoneyManager.ConsumMoney(25);
            cell.GetComponent<Cell>().isBuilt = true;
        }
        yield break;
    }
    public void Update()
    {

    }
}
