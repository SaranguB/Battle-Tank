using System;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float roatationSpeed;

        public TankTypes tankType;
        public Material color;
    }

    public List<Tank> tankList;
    private TankController tankController;

    [SerializeField] private TankView tankView;
    void Start()
    {

    }

    public void CreateTank(TankTypes tankType)
    {
        TankModel tankModel;
        
        if (tankType == TankTypes.GREEN_TANK)
        {

            //Debug.Log(tankList[0].color);

            tankModel = new TankModel(tankList[0].movementSpeed, tankList[0].roatationSpeed,
     tankList[0].tankType, tankList[0].color);

        }
        else if (tankType == TankTypes.BLUE_TANK)
        {
            //Debug.Log(tankList[1].color);

            tankModel = new TankModel(tankList[1].movementSpeed, tankList[1].roatationSpeed,
    tankList[1].tankType, tankList[1].color);

        }
        else if (tankType == TankTypes.RED_TANK)
        {

            //Debug.Log(tankList[2].color);

            tankModel = new TankModel(tankList[2].movementSpeed, tankList[2].roatationSpeed,
    tankList[2].tankType, tankList[2].color);

        }
        else
        {
            //Debug.Log(tankList[0].color);

            tankModel = new TankModel(tankList[0].movementSpeed, tankList[0].roatationSpeed,
     tankList[0].tankType, tankList[0].color);

        }
         tankController = new TankController(tankModel, tankView);

    }



}
