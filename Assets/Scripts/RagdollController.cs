using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private Rigidbody[] ragdolls;

    private void Awake()
    {
        SetRagdollState(true);
    }

    public void SetRagdollState(bool state)
    {
        foreach (Rigidbody ragdoll in ragdolls)
        {
            ragdoll.isKinematic = state;
        }
    }
}
