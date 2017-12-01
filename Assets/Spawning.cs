using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Assets.Code
{
    public class Spawning : MonoBehaviour
    {
        private float[] Health = new float[3] { 20f, 15f, 33f };
        private float[] Damage = new float[3] { 2f, 1f, 5f };
        private float[] Speed = new float[3] { 0.7f, 1f, 0.5f };
        private int[] value = new int[3] { 10, 8, 15 };
        //private const float WaveCd = 20f;
        public const float WaveCd = 10f;
        private const float SpawnTime = 0.7f;
        private int[] MaxMonsterCount = new int[9] { 5, 10, 15, 12, 24, 24, 30, 36, 38 };
        private int[] NorMonsterNum = new int[9] { 5, 10, 10, 10, 20, 10, 10, 15, 15 };
        private int[] FasMonsterNum = new int[9] { 0, 0, 5, 0, 0, 10, 14, 15, 15 };
        private int[] StrMonsterNum = new int[9] { 0, 0, 0, 2, 4, 4, 6, 6, 8 };
        //private int[,]SpawnSeq;
        private int[][] SpawnSeq = new int[9][] { new int[5]{ 0, 0, 0, 0, 0 }, new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[15] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
            new int[12]{0, 0, 0, 0, 0, 2, 2,0, 0, 0, 0, 0 }, new int[24]{0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0}, new int[24]{0,0,0,0,0,0,0,0,0,0,2,2,2,2,1,1,1,1,1,1,1,1,1,1 }
            , new int[15]{0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }, new int[15]{0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }, new int[15]{0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 } };
        private const int MAX_WAVE = 9;
        private static Object _EnemyPrefab;
        private float _lastspawn;
        private Transform _holder;
        private float spawn_time;
        public static int wave = 1;
        public static int monsternumber;
        private float quicker;//special monster
        private float tanker;//special monster
        private float begin_time;
        int flag;
        internal void Start()
        {
            /*MaxMonsterCount = new int[9]{5,10,15,12,24,24,30,36,38};
            NorMonsterNum = new int[9]{5,10,10,10,20,10,10,15,15};
            FasMonsterNum = new int[9]{0,0,5,0,0,10,14,15,15 };
            StrMonsterNum = new int[9]{ 0,0,0,2,4,4,6,6,8 };
            SpawnSeq[0] = new int[5]{0,0,0,0,0};
            SpawnSeq[1] = new int[10]{0, 0, 0, 0, 0 ,0,0,0,0,0};
            SpawnSeq[2] = new int[15]{0,0,0,0,0,1,1,1,1,1,0,0,0,0,0};
            SpawnSeq[3] = new int[12]{0, 0, 0, 0, 0, 2, 2,0, 0, 0, 0, 0 };
            SpawnSeq[4] = new int[24]{0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0};
            SpawnSeq[5] = new int[24]{0,0,0,0,0,0,0,0,0,0,2,2,2,2,1,1,1,1,1,1,1,1,1,1 };
            SpawnSeq[6] = new int[15]{0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 };
            SpawnSeq[7] = new int[15]{0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 };
            SpawnSeq[8] = new int[15]{0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 };
            Health = new float[3]{10f,5f,25f };
            Damage = new float[3]{2f,1f,5f };
            Speed = new float[3]{0.7f,1f,0.5f };
            value = new int[3]{10,8,15 };*/
            this.transform.position = new Vector3(0f, 0.7f, 4f);
            _EnemyPrefab = Resources.Load("Enemy");
            _holder = this.transform;
            _lastspawn = 10f;
            spawn_time = 10f;
            monsternumber = 0;
            flag = 0;
        }
        internal void Update()
        {
            /*if (flag == 5)//wrong happpen as beginin, so we 
            {
                for (int i = 0; i < MAX_WAVE; i++)
                {
                    GameImfomation.GetWaveInfo(i + 1, NorMonsterNum[i], StrMonsterNum[i], FasMonsterNum[i]);
                }
                flag++;

            }
            */
            if (flag <= 15)
            {
                GameImfomation.GetWaveInfo(1, NorMonsterNum[0], StrMonsterNum[0], FasMonsterNum[0]);
                flag++;
                return;

            }
            if (wave == 1 && monsternumber < MaxMonsterCount[wave - 1])
            {

                //GameImfomation.hideinfo();
                if ((Time.time - _lastspawn) < SpawnTime) return;
                if (monsternumber == 0)
                {
                    Debug.Log("1st wave begins:" + Time.time);
                }
                //GameImfomation.eclipse(wave);
                _lastspawn = Time.time;
                Spawn(SpawnSeq[wave - 1][monsternumber]);
                //FindObjectOfType<GameImfomation>().infomoving(wave + 1, ratio);
                monsternumber++;
            }
            else if (monsternumber >= MaxMonsterCount[wave - 1])
            {
                if (gameObject.transform.childCount == 0)
                { nextwave(); }
            }

            else if ((wave > 1 && wave <= MAX_WAVE) && (Time.time - spawn_time) >= WaveCd && monsternumber < MaxMonsterCount[wave - 1])
            {

                //GameImfomation.hideinfo();
                if ((Time.time - _lastspawn) < SpawnTime) return;
                if (monsternumber == 0)
                {
                    Debug.Log(wave + "st wave begins:" + Time.time);
                }
                //GameImfomation.eclipse(wave);
                _lastspawn = Time.time;
                Spawn(SpawnSeq[wave - 1][monsternumber]);
                monsternumber++;
                float ratio = (float)1/(float)MaxMonsterCount[wave - 1];
                //FindObjectOfType<GameImfomation>().infomoving(wave + 1, ratio);
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
                    GameObject w = (GameObject)Instantiate((GameObject)Resources.Load("WIN"));
                    w.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
                    w.GetComponent<Transform>().position = new Vector3(250, 150, 0);
                }
                foreach (Cell g in GameObject.FindObjectsOfType<Cell>())
                {
                    g.GetComponent<Cell>().enabled = false;
                }
            }
        }
        void nextwave()
        {
            Debug.Log(wave + "st wave ends:" + Time.time);
            wave++;
            spawn_time = Time.time;
            monsternumber = 0;
            GameImfomation.GetWaveInfo(wave, NorMonsterNum[wave-1], StrMonsterNum[wave-1], FasMonsterNum[wave-1]);
        }
        private void Spawn(int type)
        {
            //if (_holder.childCount >= MaxAsteroidCount) { return; }
            float time = Time.time;
            var tra = this.transform;
            var pos = tra.position;
            //if (time < _lastspawn + SpawnTime) { return; }
            int ty = type;
            ForceSpawn(pos, ty);
        }

        public void ForceSpawn(Vector3 pos, int type)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            var ast = (GameObject)Object.Instantiate(_EnemyPrefab, pos, rotation, _holder);
            var s = ast.GetComponentInChildren<Enemy>();
            var spe = s.GetComponent<NavMeshAgent>().speed = Speed[type];
            s.Initialize(Health[type], Damage[type], Speed[type], value[type], type);

        }

        // Use this for initialization
        // Update is called once per frame
    }
}