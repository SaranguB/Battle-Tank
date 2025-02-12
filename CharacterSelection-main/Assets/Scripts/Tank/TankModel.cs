
using UnityEngine;

public class TankModel 
{
   private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    public int health;
    public TankTypes tankTypes;
    public Material color;

    public TankModel(float movementSpeed, float rotationSpeed, TankTypes tankType, Material color, int health)
    {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.tankTypes = tankType;
        this.color = color;
        this.health = health;
    }
    public void SetTrankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
