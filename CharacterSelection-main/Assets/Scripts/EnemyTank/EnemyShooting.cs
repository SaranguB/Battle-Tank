using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    private BulletController bulletController;
    private BulletModel bulletModel;
    [SerializeField] private BulletView bulletView;

    [SerializeField] private Transform fireTransform;

    private float LaunchForce;
    private float reloadTime;
    private float reloadTimer = 0;

    private void Start()
    {
        reloadTime = 2f;
        LaunchForce = 20f;
    }

    private void Update()
    {
        reloadTimer += Time.deltaTime;

        if (reloadTimer > reloadTime)
        {
            Fire();
        }
    }

    private void Fire()
    {
        bulletModel = new BulletModel(LaunchForce);

        bulletController = new BulletController(bulletView, bulletModel, fireTransform);

        reloadTimer = 0;
    }
}
