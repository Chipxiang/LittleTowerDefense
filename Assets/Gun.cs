using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    /// <inheritdoc />
    /// <summary>
    /// Fires bullets. Don't ask questions, kid.
    /// </summary>

    public class Gun : MonoBehaviour
    {
        public static BulletMan Bullets;
        private const float FireCooldown = 1f;
        private float _lastfire;
        public void FireAt(Transform target)
        {
            float time = Time.time;
            if (time < _lastfire + FireCooldown) { return; }
            _lastfire = time;
            var bullets = GameObject.Find("bullets");
            Bullets = new BulletMan(bullets.transform);
            var pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Bullets.Spawn(pos+transform.up*0.1f, transform.rotation, 4f, target);
        }
    private void Update()
    {
    }
}
