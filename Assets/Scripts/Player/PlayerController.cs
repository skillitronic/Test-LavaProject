using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Movement _playerMovement;
    [SerializeField] private Attacking _playerAttack;
    [SerializeField] private EnemyFinder _enemyFinder;
    [SerializeField] private RigController _rigController;
    public NavMeshAgent navMeshAgent;
    public ScriptableObjectSettings playerSettings;

    public PlayerStates playerState;

    private Vector2 _mousePosition = Vector2.zero;
    [HideInInspector] public bool isAttacking;
    [HideInInspector] public bool isTargetVisible;

    private void Awake()
    {
        navMeshAgent.speed = _playerMovement.MoveSpeed;
    }

    private void Update()
    {
        if (_enemyFinder.enemyColliders.Length > 0)
        {
            foreach (Collider enemyCollider in _enemyFinder.enemyColliders)
            {
                Physics.Linecast(transform.position + Vector3.up, enemyCollider.transform.position + Vector3.up, out RaycastHit hit);

                if (hit.collider.transform.Equals(enemyCollider.transform))
                {
                    isTargetVisible = true;
                }
                else
                {
                    isTargetVisible = false;
                    _rigController.ChangeRigWeight(0);
                }
            }
        }

        if (isAttacking) _playerAttack.Fire();
        
    }

    private void FixedUpdate()
    {
        _enemyFinder.SearchForEnemy();
    }

    public Vector3 RayMouse()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(_mousePosition), out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Default"));

        return hit.point;
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            if (playerState.Equals(PlayerStates.STATE_WALKING))
            {
                _playerMovement.WalkTo();
            }

        if (ctx.started)
            if (playerState.Equals(PlayerStates.STATE_FIGHT))
            {
                isAttacking = true;
                _rigController.ChangeRigWeight(1f);
            }

        if (ctx.canceled) 
            if (playerState.Equals(PlayerStates.STATE_FIGHT))
            {
                isAttacking = false;
                _rigController.ChangeRigWeight(0f);
                _playerAttack.timer = 0;
            }

    }

    public void OnMousePosition(InputAction.CallbackContext ctx)
    {
        _mousePosition = ctx.ReadValue<Vector2>();
    }

}
