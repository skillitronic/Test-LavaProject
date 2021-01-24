using UnityEngine;

public class StateChanger : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("StateChanger") && _playerController.isTargetVisible)
        {
            _playerController.playerState = PlayerStates.STATE_FIGHT;
        }
        else if (!_playerController.isTargetVisible)
        {
            _playerController.playerState = PlayerStates.STATE_WALKING;
            _playerController.isAttacking = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StateChanger"))
        {
            _playerController.playerState = PlayerStates.STATE_WALKING;
            _playerController.isAttacking = false;
        }
    }

}
