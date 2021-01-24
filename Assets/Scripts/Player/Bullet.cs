using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float explosionForce;

    private void Awake()
    {
        Destroy(gameObject, 4f);
    }

    private void OnEnemyHit(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
        collision.collider.transform.root.GetComponent<EnemyController>().Die();
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionForce, transform.position, 2f, 5f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.root.CompareTag("Enemy"))
        {
            OnEnemyHit(collision);
        }

        Destroy(gameObject);
    }
}
