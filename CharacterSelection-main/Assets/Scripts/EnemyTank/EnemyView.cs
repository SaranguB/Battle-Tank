using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{

    public enum EnemyState
    {
        DEFAULT,
        ALIVE,
        DEAD,
    }
    public EnemyState enemyState;

    private EnemyController enemyController;
    public Vector3 directionToPlayer { get; private set; }
    public bool isPlayerFound { get; private set; }

    [SerializeField] private float targetDistance;

    public Transform player;
    private Rigidbody rb;
    private Vector3 targetDirection;

    [SerializeField] private GameObject particleEffect;
    ParticleSystem tankExplosion;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        tankExplosion = particleEffect.GetComponent<ParticleSystem>();

    }

    void Start()
    {
        enemyState = EnemyState.ALIVE;
    }


    void Update()
    {

        if (player != null)
        {
            if (player.GetComponent<TankView>() != null)
            {
                CheckForPlayer();
            }
        }

        if (enemyController.GetHealth() <= 0 && enemyState == EnemyState.ALIVE)
        {

            
            enemyState = EnemyState.DEAD;
            tankExplosion.Play();

            StartCoroutine(DestroyEnemyTank(3));

        }

    }

    private IEnumerator DestroyEnemyTank(int time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);

    }

    private void CheckForPlayer()
    {
        Vector3 enemyToPlayerVector = player.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;
        float distanceToPlayer = enemyToPlayerVector.magnitude;

        float buffer = .2f;

        if (distanceToPlayer <= targetDistance - buffer)
        {

            isPlayerFound = true;
        }
        else if (distanceToPlayer >= targetDistance + buffer)
        {

            isPlayerFound = false;
        }
    }

    private void FixedUpdate()
    {
        //if (enemyController == null) Debug.Log("it's null");

        //  Debug.Log($"fixedUpdate called on: {gameObject.name}");


        if (enemyController != null)
        {
            enemyController.UpdateTargetDirection();
            enemyController.RotateTowardsTarget();
            //enemyController.SetVelocity();
        }
    }

    public void SetEnemyController(EnemyController enemyController, Transform player)
    {

        // Debug.Log($"SetEnemyController called on: {gameObject.name}");

        enemyState = EnemyState.ALIVE;

        this.enemyController = enemyController;
        this.player = player;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<BulletView>() != null)
        {

            enemyController.TakeDamage(10);

        }
    }

    public Rigidbody GetRigidBody()
    {
        return rb;
    }
}
