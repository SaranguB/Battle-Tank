using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{

    [SerializeField] private TankSpawner tankSpawner;
    public void BlueTankSelected()
    {
        Debug.Log("blue");
        tankSpawner.CreateTank(TankTypes.BLUE_TANK);
        DisableGameObject();
    }
    public void GreenTankSelected()
    {
        Debug.Log("Green");

        tankSpawner.CreateTank(TankTypes.GREEN_TANK);
        DisableGameObject();

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
