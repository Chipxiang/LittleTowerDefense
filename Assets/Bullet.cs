using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Transform target;
    private float speed;
    public float damage;
    public bool flag;
    public void Initialize(float speed, Transform target)
    {
        this.flag = true;
        this.damage = 7f;
        this.speed = speed;
        this.target = target;
    }
    internal void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            Die();
        }
    }
    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        else Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

