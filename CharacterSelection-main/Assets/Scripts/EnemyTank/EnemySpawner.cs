using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;
    public int health = 50;

    [SerializeField] private List<BoxCollider> spawnAreas;

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
        EnemyModel enemyModel = new EnemyModel(movementSpeed, rotationSpeed, health);

        int spawned = Random.Range(0, spawnAreas.Count -1); 

        enemyController = new EnemyController(enemyView, enemyModel, spawnAreas[spawned], player);

    }


    void Update()
    {

    }




}
