using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    private EnemyController enemyController;

    public float speed;
    public float rotationSpeed;
    public int health;

    public EnemyModel(float speed, float rotationSpeed, int health)
    {
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
        this.health = health;
    }


    public void SetEnemyController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

   
}
