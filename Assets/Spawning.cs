using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
            this.transform.position = new Vector3(0f, 0.7f, 4f);
            _EnemyPrefab = Resources.Load("Enemy");
            _holder = this.transform;
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
            var tra = this.transform;
            var pos = tra.position;
            //if (time < _lastspawn + SpawnTime) { return; }
            ForceSpawn(pos);
        }

        public void ForceSpawn(Vector3 pos)
        {
            Quaternion rotation = Quaternion.Euler(0,0,0);
            var ast = (GameObject)Object.Instantiate(_EnemyPrefab, pos, rotation, _holder);
            var s = ast.GetComponentInChildren<Enemy>();
            s.Initialize();
        }
        // Use this for initialization
        // Update is called once per frame
    }
}