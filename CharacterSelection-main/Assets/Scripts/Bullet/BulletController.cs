using UnityEditor;
using UnityEngine;

public class BulletController
{
    [SerializeField] private BulletView bulletView;
    private BulletModel bulletModel;
    public BulletController(BulletView bulletView, BulletModel bulletModel, Transform fireTransform)
    {
        this.bulletModel = bulletModel;
        this.bulletView = Fire(bulletView, fireTransform);

        this.bulletView.SetEnemyController(this);
    }

    private BulletView Fire(BulletView bulletView,Transform fireTransform)
    {
        

        GameObject shellInstance = Object.Instantiate(bulletView.gameObject, fireTransform.position, fireTransform.rotation);

        Rigidbody shellRigidBody = shellInstance.GetComponent<Rigidbody>();


        shellRigidBody.velocity = bulletModel.launchForce * fireTransform.forward;

        return shellInstance.GetComponent<BulletView>();

    }

  
}
