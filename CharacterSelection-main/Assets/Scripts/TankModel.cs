
using UnityEngine;

public class TankModel 
{
   private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankTypes tankTypes;
    public Material color;

    public TankModel(float movementSpeed, float rotationSpeed, TankTypes tankType, Material color)
    {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.tankTypes = tankType;
        this.color = color;
    }
    public void SetTrankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
