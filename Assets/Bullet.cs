using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Transform target;
    private float speed;
    public void Initialize(float speed, Transform target)
    {
        this.speed = speed;
        this.target = target;
    }
    internal void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<Enemy>())
        {
            Die();
        }
    }
    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

