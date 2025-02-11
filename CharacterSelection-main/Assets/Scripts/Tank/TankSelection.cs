using UnityEngine;

public class TankSelection : MonoBehaviour
{ 
    [SerializeField] private TankSpawner tankSpawner;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void BlueTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.BLUE_TANK);
        DisableGameObject();

        gameManager.SpawnEnemy();
    }
    public void GreenTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.GREEN_TANK);
        DisableGameObject();
        gameManager.SpawnEnemy();
    }
    public void RedTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.RED_TANK);
        DisableGameObject();
        gameManager.SpawnEnemy();

    }

    private void DisableGameObject()
    {
        this.gameObject.SetActive(false);
    }

   
}
