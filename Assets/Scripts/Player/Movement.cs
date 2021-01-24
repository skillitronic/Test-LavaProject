using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    public float MoveSpeed
    {
        get => _playerController.playerSettings.moveSpeed;
        private set => MoveSpeed = _playerController.playerSettings.moveSpeed;
    }

    public void WalkTo()
    {
        _playerController.navMeshAgent.destination = _playerController.RayMouse();
    }

}
