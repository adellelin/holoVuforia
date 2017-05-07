using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GazeGestureManagerMovie : MonoBehaviour {

    public static GazeGestureManagerMovie instance { get; private set; }

    // hologram being gazed at
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    GameObject movieTop;
    GameObject movieBottom;
    GameObject movieLeft;
    GameObject movieRight;
    GameObject movieCenter;
    
    private movieStart MovieTopStartObject;
    private movieStart MovieBottomStartObject;
    private movieStart MovieLeftStartObject;
    private movieStart MovieRightStartObject;
    private movieStart MovieCenterStartObject;

    // Use this for initialization
    void Start () {

        instance = this;

        movieTop = GameObject.Find("MovieTop");
        movieBottom = GameObject.Find("MovieBottom");
        movieLeft = GameObject.Find("MovieLeft");
        movieRight = GameObject.Find("MovieRight");
        movieCenter = GameObject.Find("MovieCenter");

        // set up a gesture recognizer to detect select gestures
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            // send an onselect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect");
            }
        };
        recognizer.StartCapturingGestures();

    }
	
	// Update is called once per frame
	void Update () {
        GameObject oldFocusedObject = FocusedObject;

        // do raycast into world based on user's head position
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            FocusedObject = hitInfo.collider.gameObject;
            
        } else
        {
            // if the raycast did no hit holo, clear focused object
            FocusedObject = null;
        }

        // if the focused object changed, start detecting fresh gestures
        if (FocusedObject != oldFocusedObject)
        {

            if (FocusedObject == movieTop)
            {
                MovieTopStartObject = movieTop.GetComponent<movieStart>();
                MovieTopStartObject.PlayMovie();
                MovieBottomStartObject.PauseMovie();
                MovieLeftStartObject.PauseMovie();
                MovieRightStartObject.PauseMovie();
                MovieCenterStartObject.PauseMovie();
            }
            else if (FocusedObject == movieBottom)
            {
                MovieBottomStartObject = movieBottom.GetComponent<movieStart>();
                MovieBottomStartObject.PlayMovie();
                MovieTopStartObject.PauseMovie();
                MovieLeftStartObject.PauseMovie();
                MovieRightStartObject.PauseMovie();
                MovieCenterStartObject.PauseMovie();
            }
            else if (FocusedObject == movieLeft)
            {
                MovieLeftStartObject = movieLeft.GetComponent<movieStart>();
                MovieLeftStartObject.PlayMovie();
                MovieTopStartObject.PauseMovie();
                MovieBottomStartObject.PauseMovie();
                MovieRightStartObject.PauseMovie();
                MovieCenterStartObject.PauseMovie();
            }
            else if (FocusedObject == movieRight)
            {
                MovieRightStartObject = movieRight.GetComponent<movieStart>();
                MovieRightStartObject.PlayMovie();
                MovieTopStartObject.PauseMovie();
                MovieBottomStartObject.PauseMovie();
                MovieLeftStartObject.PauseMovie();
                MovieCenterStartObject.PauseMovie();
            }
            else if (FocusedObject == movieCenter)
            {
                MovieCenterStartObject = movieCenter.GetComponent<movieStart>();
                MovieCenterStartObject.PlayMovie();
                MovieTopStartObject.PauseMovie();
                MovieBottomStartObject.PauseMovie();
                MovieLeftStartObject.PauseMovie();
                MovieCenterStartObject.PauseMovie();
            } else
            {
                MovieTopStartObject.PauseMovie();
                MovieBottomStartObject.PauseMovie();
                MovieLeftStartObject.PauseMovie();
                MovieRightStartObject.PauseMovie();
                MovieCenterStartObject.PauseMovie();
            }

            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }

    }

}
