
using UnityEngine;

public class TankModel 
{
   private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankModel(float movementSpeed, float rotationSpeed)
    {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
    }
    public void SetTrankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
