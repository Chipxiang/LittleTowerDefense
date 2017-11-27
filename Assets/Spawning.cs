using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Assets.Code
{
    public class Spawning : MonoBehaviour
    {
        private float Health;
        private float Damage;
        private float Speed;
        private int value;
        //private const float WaveCd = 20f;
        public const float WaveCd = 10f;
        private const float SpawnTime = 0.7f;
        private int[] MaxMonsterCount;
        private const int MAX_WAVE = 5;
        private static Object _EnemyPrefab;
        private float _lastspawn;
        private Transform _holder;
        private float spawn_time;
        public static int wave;
        public static int monsternumber;
        private float quicker;//special monster
        private float tanker;//special monster
        int flag;
        internal void Start()
        {
            MaxMonsterCount = new int[5]{10,14,12,13,15};
            Health = 10f;
            Damage = 2f;
            Speed = 0.3f;
            value = 10;
            this.transform.position = new Vector3(0f, 0.7f, 4f);
            _EnemyPrefab = Resources.Load("Enemy");
            _holder = this.transform;
            _lastspawn = 5f;
            spawn_time = 5f;
            wave = 1;
            monsternumber = 0;
            //Asteroid.Manager = this;
            flag = 0;
            foreach (Text w in FindObjectsOfType<Text>())
            {
                if (w.name == "Win")
                {
                    w.enabled = false;
                }
            }
            foreach (Text w in FindObjectsOfType<Text>())
            {
                if (w.name == "Lose")
                {
                    w.enabled = false;
                }
            }
        }
/*
        var bb = FindObjectOfType<Spawning>();
        var ene = bb.GetComponentInChildren<Enemy>();
        float damage = ene.Damage;
        float speed = ene.Speed;
        GameImfomation.GetWaveInfo(wave, MaxMonsterCount, damage, speed);
            GameImfomation.infomoving(wave);*/
        internal void FixedUpdate()
        {
            if(flag ==5)
            {
                for (int i = 0; i < MAX_WAVE; i++)
                {
                    GameImfomation.GetWaveInfo(i+1, MaxMonsterCount[i], Damage, Speed);
                }
                flag++;

            }
            if(flag!=5)
            {
                flag++;
            }
            if (wave == 1 && monsternumber < MaxMonsterCount[wave-1])
            {
                //GameImfomation.hideinfo();
                if ((Time.time - _lastspawn) < SpawnTime) return;
                GameImfomation.eclipse(wave);
                _lastspawn = Time.time;
                Spawn();
                FindObjectOfType<GameImfomation>().infomoving(wave+1,monsternumber/ MaxMonsterCount[wave]);
                monsternumber++;
            }
            else if (monsternumber >= MaxMonsterCount[wave-1])
            {
                if (gameObject.transform.childCount == 0)
                { nextwave(); }
            }

            else if ( (wave>1 && wave<=MAX_WAVE) && (Time.time - spawn_time) >= WaveCd && monsternumber < MaxMonsterCount[wave-1])
            {
                //GameImfomation.hideinfo();
                if ((Time.time - _lastspawn) < SpawnTime) return;
                GameImfomation.eclipse(wave);
                _lastspawn = Time.time;
                Spawn();
                monsternumber++;
                 FindObjectOfType<GameImfomation>().infomoving(wave + 1, monsternumber / MaxMonsterCount[wave]); 
                if (monsternumber == MaxMonsterCount[wave - 1])
                {
                    if (gameObject.transform.childCount == 0)
                    { nextwave(); }
                 }
            }
            if (wave > MAX_WAVE)
            {
                var aa = FindObjectOfType<Spawning>().transform;
                var d = aa.childCount;
                if (d == 0)
                {
                    Time.timeScale = 0;
                    foreach (Text w in FindObjectsOfType<Text>())
                    {
                        if (w.name == "Win")
                        {
                            w.enabled = true;
                        }
                    } 
                    Debug.Log("Win");
                }
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
            s.Initialize(Health, Damage, Speed, value);
            
        }

        // Use this for initialization
        // Update is called once per frame
    }
}