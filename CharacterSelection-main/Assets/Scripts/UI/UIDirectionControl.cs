using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
   

    public bool useReleativeRotation = true;

    private Quaternion releativeRotation;

    private void Start()
    {
        releativeRotation = transform.parent.localRotation;
    }

    private void Update()
    {
        if (useReleativeRotation)
        {
            transform.rotation = releativeRotation;
        }
    }

}
