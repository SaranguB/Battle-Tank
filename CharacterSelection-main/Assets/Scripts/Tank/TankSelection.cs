using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{

    [SerializeField] private TankSpawner tankSpawner;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public void BlueTankSelected()
    {
        //Debug.Log("blue");
        tankSpawner.CreateTank(TankTypes.BLUE_TANK);
        DisableGameObject();

        enemySpawner.SpawnEnemy();

    }
    public void GreenTankSelected()
    {
       // Debug.Log("Green");

        tankSpawner.CreateTank(TankTypes.GREEN_TANK);
        DisableGameObject();
        enemySpawner.SpawnEnemy();

    }
    public void RedTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.RED_TANK);
        DisableGameObject();

    }

    private void DisableGameObject()
    {
        this.gameObject.SetActive(false);
    }

   
}
