using System;
using System.Collections.Generic;
using System.Data;
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

 
    [SerializeField] private TankView tankView;
  

    public void CreateTank(TankTypes tankType)
    {

        if (tankType == TankTypes.GREEN_TANK)
        {
         /*   Debug.Log("Green");
            Debug.Log(tankList[1].color);*/

            TankModel tankModel = new TankModel(tankList[0].movementSpeed, tankList[0].roatationSpeed,
      tankList[0].tankType, tankList[0].color);

            TankController tankController = new TankController(tankModel, tankView);
        }
        else if (tankType == TankTypes.BLUE_TANK)
        {
           // Debug.Log(tankList[1].color);
            TankModel tankModel = new TankModel(tankList[1].movementSpeed, tankList[1].roatationSpeed,
     tankList[1].tankType, tankList[1].color);

            TankController tankController = new TankController(tankModel, tankView);
        }
        else if (tankType == TankTypes.RED_TANK)
        {
            //Debug.Log("RED");

            TankModel tankModel = new TankModel(tankList[2].movementSpeed, tankList[2].roatationSpeed,
     tankList[2].tankType, tankList[2].color);

            TankController tankController = new TankController(tankModel, tankView);
        }
    }
   


}
