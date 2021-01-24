using UnityEngine;

[CreateAssetMenu(menuName ="Player Settings",fileName = "Create settings")]
public class ScriptableObjectSettings : ScriptableObject
{
    public BulletForce bulletForceMode;
    public float moveSpeed;
    public float bulletSpeed;
    public float fireRate;

}


