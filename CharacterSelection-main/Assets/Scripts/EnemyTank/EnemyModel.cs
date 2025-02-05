using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    private EnemyController enemyController;

    public float speed;
    public float rotationSpeed;

    public EnemyModel(float speed, float rotationSpeed)
    {
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
    }


    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
}
