using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGestureHandlerCylinder : MonoBehaviour
{

    private bool isActive = false;
    public ActivationZoneManagerTom activationZoneManagerTom;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(0, 0, 0.5f);
        //this.transform.GetChild(0).Rotate(0, 0, 1f);
        if (isActive)
        {
            
            this.transform.GetChild(0).Rotate(0, 0, 1f);
            this.transform.GetChild(1).Rotate(0, 0, 1f);
        }

    }
    /*
    void OnAirTapped()
    {
        isActive = !isActive;
    }*/
    void OnSelect()
    {
        //Debug.Log("cone selected");
        //this.transform.GetChild(0).Rotate(0, 0, 1f);
        //this.transform.GetChild(1).Rotate(0, 0, 1f);
        if (activationZoneManagerTom.sculptureZoneActivated)
        {
            isActive = !isActive;
        }
        
    }

}
