using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private RagdollController _ragdollController;
    [SerializeField] private Collider _collider;

    public void Die()
    {
        _animator.enabled = false;
        _ragdollController.SetRagdollState(false);
        _collider.enabled = false;
    }
}
