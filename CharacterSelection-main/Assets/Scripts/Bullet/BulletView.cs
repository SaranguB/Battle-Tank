using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private GameObject bulletParticleEffet;
    ParticleSystem bulletExplosion;
    BulletController bulletController;

    
    void Start()
    {

       bulletExplosion = bulletParticleEffet.GetComponent<ParticleSystem>();

    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collided");
        bulletExplosion.Play();


        StartCoroutine(DestroyGameObject());
    }


    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
    public void SetEnemyController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
}
