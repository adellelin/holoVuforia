using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskLighting : MonoBehaviour {
    public GameObject ToniDeskPosition;       //Public variable to store a reference to the player game object
    public GameObject TomDeskPosition;
    public Light ToniDeskLightObject;
    public Light TomDeskLightObject;
    private float ToniDeskOffset;         //Private variable to store the offset distance between the player and camera
    private float TomDeskOffset;
    private Vector3 viewerTransform;
   // public Text PositionCamera;

    // Use this for initialization
    void Start () {

        ToniDeskLightObject.enabled = false;
        TomDeskLightObject.enabled = false;

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        viewerTransform = transform.localPosition;
        //Debug.Log("viewerPosition: " + viewerTransform);
        
        //deskLightObject = new GameObject("TheLight");
        //Light lightComp = deskLightObject.AddComponent<Light>();
        //lightComp.color = Color.blue;
        
    }
	
	// Update is called once per frame
	void Update () {
        //deskOffset = transform.localPosition - deskPosition.transform.localPosition;
        ToniDeskOffset = Vector3.Distance(transform.position, ToniDeskPosition.transform.position);
        TomDeskOffset = Vector3.Distance(transform.position, TomDeskPosition.transform.position);

        //Debug.Log("DeskPos: " + deskPosition.transform.localPosition);
        //Debug.Log("deskoffset" + Mathf.Abs(deskOffset.x));

        if (ToniDeskOffset < 2.8f)
            
        {
            //Debug.Log("walked into desk");
            ToniDeskLightObject.enabled = true;
        } else
        {
            ToniDeskLightObject.enabled = true;
        }

        if (TomDeskOffset < 2.8f)

        {
            //Debug.Log("walked into desk");
            TomDeskLightObject.enabled = true;
        }
        else
        {
            TomDeskLightObject.enabled = true;
        }
    }
    /*
    void OnTriggerEnter(Collider CollisionCube)
    {
        deskLightObject.enabled = true;
        GameObject otherObj = CollisionCube.gameObject;
        Debug.Log("Triggered with: " + otherObj);

    }
    */

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //deskLightObject.transform.localPosition = deskPosition.transform.localPosition + new Vector3(0, 2, 0);
        //deskLightObject.transform.localPosition = new Vector3(0, 0, 0);
        //Debug.Log(transform.localPosition);
       // PositionCamera.text = transform.localPosition.ToString();
    }
}
