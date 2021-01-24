using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator.SetFloat("Velocity", _playerController.navMeshAgent.velocity.magnitude/_playerController.navMeshAgent.speed);
    }
}
