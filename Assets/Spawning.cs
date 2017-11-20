using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Assets.Code
{
    public class Spawning : MonoBehaviour
    {
        
        //private const float WaveCd = 20f;
        public const float WaveCd = 5f;
        private const float SpawnTime = 0.8f;
        private const int MaxMonsterCount = 10;
        private const int MAX_WAVE = 3;
        private static Object _EnemyPrefab;
        private float _lastspawn;
        private Transform _holder;
        private float spawn_time;
        public static int wave;
        public static int monsternumber;
        internal void Start()
        {
            this.transform.position = new Vector3(0f, 0.7f, 4f);
            _EnemyPrefab = Resources.Load("Enemy");
            _holder = this.transform;
            _lastspawn = 0f;
            spawn_time = 0f;
            wave = 1;
            monsternumber = 0;
            //Asteroid.Manager = this;
        }
        internal void FixedUpdate()
        {
            if (wave == 1 && monsternumber <= MaxMonsterCount)
            {
                GameImfomation.hideinfo();
                if ((Time.time - _lastspawn) < SpawnTime) return;
                _lastspawn = Time.time;
                Spawn();
                monsternumber++;
                if (monsternumber == 10)
                {
                    nextwave();
                    GameImfomation.Updateinfo(wave, MaxMonsterCount);
                }
            }

            else if ( (wave>1 && wave<=MAX_WAVE) && (Time.time - spawn_time) >= WaveCd && monsternumber <= MaxMonsterCount)
            {
                GameImfomation.hideinfo();
                if ((Time.time - _lastspawn) < SpawnTime) return;
                _lastspawn = Time.time;
                Spawn();
                monsternumber++;
                if (monsternumber == 10)
                {
                    nextwave();

                 }
            }
            GameImfomation.Updateinfo(wave, monsternumber);
            if (wave == MAX_WAVE)
            {
                //胜负判定


            }
        }
        void nextwave()
        {
            wave++;
            spawn_time = Time.time;
            monsternumber = 0;
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