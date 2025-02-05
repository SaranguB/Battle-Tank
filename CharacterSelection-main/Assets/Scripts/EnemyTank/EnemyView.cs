using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    public Vector3 directionToPlayer { get; private set; }
    public bool isPlayerFound { get; private set; }

    [SerializeField] private float targetDistance;

    public Transform player;
    private Rigidbody rb;
    private Vector3 targetDirection;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }


    void Update()
    {

        if (player != null)
        {
            Vector3 enemyToPlayerVector = player.position - transform.position;
            directionToPlayer = enemyToPlayerVector.normalized;

            if (enemyToPlayerVector.magnitude <= targetDistance)
            {
                isPlayerFound = true;
            }
            else
            {
                isPlayerFound = false;
            }
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

        this.enemyController = enemyController;
        this.player = player;
    }

    public Rigidbody GetRigidBody()
    {
        return rb;
    }
}
