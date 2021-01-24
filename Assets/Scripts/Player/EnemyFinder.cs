using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField] private float _searchRadius = 5f;

    [SerializeField] private LayerMask _enemyLayer;

    [HideInInspector] public Collider[] enemyColliders;

    public void SearchForEnemy()
    {
        enemyColliders = Physics.OverlapSphere(transform.position, _searchRadius, _enemyLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _searchRadius);
    }
}
