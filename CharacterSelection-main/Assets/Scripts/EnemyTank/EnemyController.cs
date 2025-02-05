
using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;

    private Rigidbody enemyRB;
    private Vector3 targetDirection;

    public EnemyController(EnemyView enemyView, EnemyModel enemyModel, BoxCollider spawnArea, Transform player)
    {
        this.enemyModel = enemyModel;

        this.enemyView = SpawnEnemy(enemyView, spawnArea);

        enemyRB = this.enemyView.GetRigidBody();

        this.enemyView.SetEnemyController(this, player);
    
    }

    public EnemyView SpawnEnemy(EnemyView enemyView, BoxCollider spawnArea)
    {
        Vector3 randomPosition = GenerateRandomEnemyPoisitions(spawnArea);
        GameObject enemyInstance = Object.Instantiate(enemyView.gameObject, randomPosition, Quaternion.identity);
        return enemyInstance.GetComponent<EnemyView>();
    }

    private Vector3 GenerateRandomEnemyPoisitions(BoxCollider spawnArea)
    {
        Bounds bounds = spawnArea.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);

        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(randomX, 0, randomZ);
    }


    public void UpdateTargetDirection()
    {
        if(!enemyView.isPlayerFound)
        {
            targetDirection = enemyView.directionToPlayer;
        }
        else
        {
            targetDirection = Vector3.zero;
        }
    }

    public void RotateTowardsTarget()
    {
        if(targetDirection == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(enemyView.transform.rotation, targetRotation, enemyModel.rotationSpeed *Time.deltaTime);
        enemyRB.MoveRotation(rotation);
    }

    public void SetVelocity()
    {
        if(targetDirection == Vector3.zero)
        {
            enemyRB.velocity = Vector3.zero;
        }
        else
        {
            enemyRB.velocity = enemyView.transform.forward * enemyModel.speed;
        }
    }
}
