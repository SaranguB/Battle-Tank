using System;
using System.Collections;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private GameObject bulletParticleEffet;
    ParticleSystem bulletExplosion;
    BulletController bulletController;

    [SerializeField] private CapsuleCollider collider;

    void Start()
    {
        bulletParticleEffet.SetActive(true);

       bulletExplosion = bulletParticleEffet.GetComponent<ParticleSystem>();

    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        //Debug.Log("collided");
        bulletExplosion.Play();

         collider.isTrigger = true;
        StartCoroutine(DestroyGameObject());
    }


    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
    public void SetEnemyController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
}
