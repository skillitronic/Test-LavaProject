using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigController : MonoBehaviour
{
    [SerializeField] private Transform _targetAim;
    [SerializeField] private Rig _rig;

    public void ChangeRigWeight(float amount)
    {
        _rig.weight = amount;
    }
}
