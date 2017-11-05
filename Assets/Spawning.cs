using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Code
{
    public class Spawning : MonoBehaviour
    {
        private const float SpawnTime = 3f;
        //private const int MaxAsteroidCount = 8;
        private static Object _EnemyPrefab;
        private float _lastspawn;
        private Transform _holder;
        internal void Start()
        {
            //this.transform.position = new Vector3(0f, 4f, -1.5f);
            _EnemyPrefab = Resources.Load("Enemy");
            _holder = gameObject.GetComponent<Transform>();
            _lastspawn = 0f;
            //Asteroid.Manager = this;
        }
        internal void FixedUpdate()
        {
            if ((Time.time - _lastspawn) < SpawnTime) return;
            _lastspawn = Time.time;
            Spawn();
        }
        private void Spawn()
        {
            //if (_holder.childCount >= MaxAsteroidCount) { return; }
            float time = Time.time;
            var tra = gameObject.GetComponent<Transform>();
            var pos = tra.position;
            //if (time < _lastspawn + SpawnTime) { return; }
            ForceSpawn(pos);
        }

        public void ForceSpawn(Vector2 pos)
        {
            Quaternion rotation = new Quaternion();
            var ast = (GameObject)Object.Instantiate(_EnemyPrefab, pos, rotation, _holder);
            var s = ast.GetComponentInChildren<Enemy>();
            s.Initialize();
        }
        // Use this for initialization

        // Update is called once per frame
    }
}