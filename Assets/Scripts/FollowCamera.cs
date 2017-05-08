using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowCamera : MonoBehaviour {
    public GameObject movieCamera;       //Public variable to store a reference to the player game object

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public Text PositionCamera;

    // Use this for initialization
    void Start () {

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.localPosition - movieCamera.transform.localPosition;
        Debug.Log("OFFSET: " +offset);

    }

    // Update is called once per frame
    void Update () {

        // Debug.Log("movieCamera.transform.localPosition: " + movieCamera.transform.localPosition);

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.localPosition = movieCamera.transform.localPosition + offset;
        //transform.rotation = movieCamera.transform.rotation + Vector3.Angle(0, 180, 0); ;
    }

}
