using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskLighting : MonoBehaviour {
    public GameObject deskPosition;       //Public variable to store a reference to the player game object
    public Light deskLightObject;
    private Vector3 deskOffset;         //Private variable to store the offset distance between the player and camera
    private Vector3 viewerTransform;
   // public Text PositionCamera;

    // Use this for initialization
    void Start () {

        deskLightObject.enabled = false;
        deskLightObject.enabled = true;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        viewerTransform = transform.localPosition;
        Debug.Log("viewerPosition: " + viewerTransform);
        
        //deskLightObject = new GameObject("TheLight");
        //Light lightComp = deskLightObject.AddComponent<Light>();
        //lightComp.color = Color.blue;
        
    }
	
	// Update is called once per frame
	void Update () {
        //deskOffset = transform.localPosition - deskPosition.transform.localPosition;
        deskOffset = transform.position - deskPosition.transform.position;
        //Debug.Log("DeskPos: " + deskPosition.transform.localPosition);
        //Debug.Log("deskoffset" + Mathf.Abs(deskOffset.x));

        if (Mathf.Abs(deskOffset.x) < 2f)
            
        {
            Debug.Log("walked into desk");
            deskLightObject.enabled = true;
        } else
        {
            deskLightObject.enabled = false;
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
