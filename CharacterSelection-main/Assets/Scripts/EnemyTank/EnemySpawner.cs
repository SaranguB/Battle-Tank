using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;

    [SerializeField] private BoxCollider spawnArea;

    EnemyController enemyController;
    [SerializeField] private EnemyView enemyView;
    private EnemyModel enemyModel;

    private Transform player;


    void Start()
    {
    }

    public void SpawnEnemy()
    {
        player = FindObjectOfType<TankView>().transform;
        EnemyModel enemyModel = new EnemyModel(movementSpeed, rotationSpeed);

        enemyController = new EnemyController(enemyView, enemyModel, spawnArea, player);

    }

    
    void Update()
    {

    }




}
