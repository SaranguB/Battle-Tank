using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody shell;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private Slider aimSlider;
    [SerializeField] private float minLaunchForce = 15f;
    [SerializeField] private float maxLaunchForce = 30f;
    [SerializeField] float maxChargeTime = .75f;



    private string fireButton;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    private void OnEnable()
    {
        //Debug.Log("enabled");
        currentLaunchForce = minLaunchForce;
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
            currentLaunchForce = maxLaunchForce;
            Fire();
        }
        else if (Input.GetButtonDown(fireButton))
        {
            fired = false;
            currentLaunchForce = minLaunchForce;
        }
        else if (Input.GetButton(fireButton) && !fired)
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            aimSlider.value = currentLaunchForce;
        }
        else if (Input.GetButtonUp(fireButton) && !fired)
        {
            Fire();
        }

    }

    private void Fire()
    {
        fired = true;

        Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;

        shellInstance.velocity = currentLaunchForce * fireTransform.forward;

        currentLaunchForce = minLaunchForce;
    }
}
