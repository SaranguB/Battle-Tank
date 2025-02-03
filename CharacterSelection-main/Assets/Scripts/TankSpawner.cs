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

    [SerializeField] private TankView tankView;
    void Start()
    {
        CreateTank();
    }

    public void CreateTank()
    {
        TankModel tankModel = new TankModel(tankList[1].movementSpeed, tankList[1].roatationSpeed, 
            tankList[1].tankType, tankList[1].color);

        TankController tankController = new TankController(tankModel, tankView);
    }

}
