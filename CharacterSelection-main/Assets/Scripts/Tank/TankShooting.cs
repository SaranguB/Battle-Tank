using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{

    [SerializeField] private Transform fireTransform;
    [SerializeField] private Slider aimSlider;
    private float minLaunchForce = 15f;
    private float maxLaunchForce = 30f;
    private float maxChargeTime = .75f;

    BulletController bulletController;
    BulletModel bulletModel;
    [SerializeField] BulletView bulletView;


    private string fireButton;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    private void OnEnable()
    {
        //Debug.Log("enabled");
        SetCurrentLaunchForce(minLaunchForce);
        aimSlider.value = minLaunchForce;
    }

    private void Start()
    {
        fireButton = "Fire1";
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }

    private void Update()
    {

        aimSlider.value = minLaunchForce;

        if (currentLaunchForce >= maxLaunchForce && !fired)
        {
            SetCurrentLaunchForce(maxLaunchForce);
            Fire();
            fired = true;
            SetCurrentLaunchForce(minLaunchForce);


        }

        else if (Input.GetButtonDown(fireButton))
        {
            fired = false;
            SetCurrentLaunchForce(minLaunchForce);
        }
        else if (Input.GetButton(fireButton) && !fired)
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            aimSlider.value = currentLaunchForce;
        }
        else if (Input.GetButtonUp(fireButton) && !fired)
        {
            Fire();
            fired = true;
            SetCurrentLaunchForce(minLaunchForce);


        }

    }

    void SetCurrentLaunchForce(float force)
    {
        currentLaunchForce = force;
    }

    private void Fire()
    {
        bulletModel = new BulletModel(currentLaunchForce);

        bulletController = new BulletController(bulletView, bulletModel, fireTransform);




    }
}
