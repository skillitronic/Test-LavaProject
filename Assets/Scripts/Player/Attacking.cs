using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform _spawnOrigin;
    [SerializeField] private GameObject _bullet;

    [HideInInspector] public float timer;

    public float FireRate
    {
        get => _playerController.playerSettings.fireRate;
        private set => FireRate = _playerController.playerSettings.fireRate;

    }
    public float BulletSpeed
    {
        get => _playerController.playerSettings.bulletSpeed;
        private set => BulletSpeed = _playerController.playerSettings.bulletSpeed;
    }

    public void Fire()
    {
        ChangePointPosition();

        if (Time.time > timer)
        {
            timer = Time.time + FireRate;
            CreateBullet();
        }
    }

    private void ChangePointPosition()
    {
        _targetPoint.position = _playerController.RayMouse();
    }

    private void CreateBullet()
    {
        GameObject go = Instantiate(_bullet, _spawnOrigin.position, _spawnOrigin.rotation);
        go.GetComponent<Bullet>().explosionForce = (float)_playerController.playerSettings.bulletForceMode;
        go.GetComponent<Rigidbody>().AddForce(_spawnOrigin.transform.forward * BulletSpeed, ForceMode.Impulse);

    }

}
