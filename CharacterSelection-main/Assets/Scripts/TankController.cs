
using UnityEngine;

public class TankController
{

    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel tankModel, TankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = tankView;

        tankModel.SetTrankController(this);
        tankView.SetTrankController(this);

        GameObject.Instantiate(tankView.gameObject);   
    }
}
