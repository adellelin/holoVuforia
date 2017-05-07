using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public GameObject ToniDoveStudio;
    public GameObject TomsStudio;
    public GameObject MovieBottom;
    public GameObject KeyScene;
    //public GazeGestureManagerToni gazeToni;
   
    //public GazeGestureManager gazeKeyScene;
    //public GazeGestureManagerTom gazeTom;
    public ActivationZoneManagerToni activationZoneToni;
    public ActivationZoneManagerTom activationZoneTom;
    // Use this for initialization
    void Start () {

        // GUI is rendered with last camera.
        // As we want it to end up in the main screen, make sure main camera is the last one drawn.
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
        if (Display.displays.Length > 3)
            Display.displays[3].Activate();


        MovieBottom.SetActive(false);
        ToniDoveStudio.SetActive(false);
        TomsStudio.SetActive(false);
        KeyScene.SetActive(true);
        activationZoneTom.enabled = false;
        activationZoneToni.enabled = false;
        //gazeKeyScene.enabled = true;
        //gazeToni.enabled = true;
        //gazeTom.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
