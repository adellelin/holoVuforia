using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;
using UnityEngine.UI;

public class GazeGestureManagerToni : MonoBehaviour
{

    public static GazeGestureManagerToni instance { get; private set; }

    // hologram being gazed at
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    public GameObject movieTop;
    public GameObject movieBottom;
    public GameObject movieLeft;
    public GameObject movieRight;
    public GameObject movieCenter;
    public GameObject toniBio;
    public GameObject toniContact;
    public GameObject toniCalendar;
    public GameObject toniStatement;


    //private GameObject[] toniDeskObject;
    List<GameObject> toniDeskObjects = new List<GameObject>();
    List<movieStart> toniMovies = new List<movieStart>();

    private movieStart MovieTopStartObject;
    private movieStart MovieBottomStartObject;
    private movieStart MovieLeftStartObject;
    private movieStart MovieRightStartObject;
    private movieStart MovieCenterStartObject;

    public Text[] ToniDeskText;


    // Use this for initialization
    void Awake()
    {

        instance = this;
        /*
        movieTop = GameObject.Find("MovieTop");
        movieBottom = GameObject.Find("MovieBottom");
        movieLeft = GameObject.Find("MovieLeft");
        movieRight = GameObject.Find("MovieRight");
        movieCenter = GameObject.Find("MovieCenter");

  
        toniBio = GameObject.Find("ToniBio");
        toniCalendar = GameObject.Find("ToniCalendar");
        toniStatement = GameObject.Find("ToniStatement");
        toniContact = GameObject.Find("ToniContact");
          */
        toniDeskObjects.Add(toniBio);
        toniDeskObjects.Add(toniCalendar);
        toniDeskObjects.Add(toniContact);
        toniDeskObjects.Add(toniStatement);

        MovieTopStartObject = movieTop.GetComponent<movieStart>();
        MovieRightStartObject = movieRight.GetComponent<movieStart>();
        MovieLeftStartObject = movieLeft.GetComponent<movieStart>();
        MovieCenterStartObject = movieCenter.GetComponent<movieStart>();
        MovieBottomStartObject = movieBottom.GetComponent<movieStart>();

    }

    void Start()
    {

        for (int i = 0; i < ToniDeskText.Length; i++)
        {
            ToniDeskText[i].enabled = false;
            Debug.Log("desk objects" + toniDeskObjects[i]);
        }

        toniMovies.Add(MovieTopStartObject);
        toniMovies.Add(MovieBottomStartObject);
        toniMovies.Add(MovieCenterStartObject);
        toniMovies.Add(MovieLeftStartObject);
        toniMovies.Add(MovieRightStartObject);

        // set up a gesture recognizer to detect select gestures
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            // send an onselect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect");
                //  to call onAirTapped method
                //FocusedObject.SendMessage("OnAirTapped", SendMessageOptions.RequireReceiver);
            }
        };
        recognizer.StartCapturingGestures();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject oldFocusedObject = FocusedObject;

        // do raycast into world based on user's head position
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            FocusedObject = hitInfo.collider.gameObject;

        }
        else
        {
            // if the raycast did no hit holo, clear focused object
            FocusedObject = null;


            // pause movie if raycast doesn't hit anything
            for (int i = 0; i < toniMovies.Count; i++)
            {
                if (toniMovies[i] != null)
                {
                    MovieTopStartObject.PauseMovie();
                    MovieBottomStartObject.PauseMovie();
                    MovieLeftStartObject.PauseMovie();
                    MovieRightStartObject.PauseMovie();
                    MovieCenterStartObject.PauseMovie();

                }
                else
                {
                    //Debug.Log("no movies");
                }
            }
        }

        // if the focused object changed, start detecting fresh gestures
        if (FocusedObject != oldFocusedObject)
        {
            //Debug.Log(FocusedObject);

            for (int i = 0; i < ToniDeskText.Length; i++)
            {
               // Debug.Log(FocusedObject);
               // Debug.Log("desk object names: " + toniDeskObjects[i]);

                if (FocusedObject == toniDeskObjects[i])
                {
                   // Debug.Log(FocusedObject);
                    ToniDeskText[i].enabled = true;
                    //toniBio.transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);

                    Debug.Log("found desk object");
                }
                else
                {
                    ToniDeskText[i].enabled = false;
                    //Debug.Log("can't find it");
                }
            }

            if (FocusedObject == movieTop)
            {

                MovieTopStartObject.PlayMovie();

            }
            else if (FocusedObject == movieBottom)
            {

                MovieBottomStartObject.PlayMovie();


            }
            else if (FocusedObject == movieLeft)
            {
                Debug.Log("movieLEft");
                MovieLeftStartObject.PlayMovie();

            }
            else if (FocusedObject == movieRight)
            {
                Debug.Log("movieRight");
                MovieRightStartObject.PlayMovie();

            }
            else if (FocusedObject == movieCenter)
            {

                MovieCenterStartObject.PlayMovie();

            }
            else { }


            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }

    }

}
