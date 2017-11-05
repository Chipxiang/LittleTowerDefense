using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


    public class BulletMan
    {
        private readonly Transform _holder;
        private readonly Object _bullet;
        public BulletMan(Transform holder)
        {
            _holder = holder;
            _bullet = Resources.Load("Bullet");
        }

        public void Spawn(Vector3 pos, Quaternion rotation, float speed, Transform target)
        {
            var newBullet = (GameObject)Object.Instantiate(_bullet, pos, rotation, _holder);
            var ss = newBullet.GetComponent<Bullet>();
            ss.Initialize(speed, target);
        }

        // Use this for initialization



    }
