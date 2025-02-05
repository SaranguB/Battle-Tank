
using UnityEngine;

public class TankController
{

    private TankModel tankModel;
    private TankView tankView;
    

    private Rigidbody rb;

    public TankController(TankModel tankModel, TankView tankView)
    {

        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);

        rb = this.tankView.GetRigidBody();

        this.tankModel.SetTrankController(this);
        this.tankView.SetTrankController(this);

        this.tankView.changeColor(tankModel.color);

        

    }

    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float rotate, float rotateSpeed)
    {
        Vector3 vector = new Vector3(0f, rotate * rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel()
    {
        return tankModel;
    }
}
