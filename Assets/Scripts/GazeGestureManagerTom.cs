using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;
using UnityEngine.UI;

public class GazeGestureManagerTom : MonoBehaviour
{

    public static GazeGestureManagerTom instance { get; private set; }

    // hologram being gazed at
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    GameObject tomBio;
    GameObject tomContact;
    GameObject tomCalendar;
    GameObject tomStatement;
    //private GameObject[] toniDeskObject;
    List<GameObject> tomDeskObjects = new List<GameObject>();

    public Text[] TomDeskText;

    // Use this for initialization
    void Awake()
    {

        instance = this;


        tomBio = GameObject.Find("ToniBio");
        tomCalendar = GameObject.Find("ToniCalendar");
        tomStatement = GameObject.Find("ToniStatement");
        tomContact = GameObject.Find("ToniContact");
        tomDeskObjects.Add(tomBio);
        tomDeskObjects.Add(tomCalendar);
        tomDeskObjects.Add(tomContact);
        tomDeskObjects.Add(tomStatement);

    }

    void Start()
    {

        for (int i = 0; i < TomDeskText.Length; i++)
        {
            TomDeskText[i].enabled = false;
        }


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

        }

        // if the focused object changed, start detecting fresh gestures
        if (FocusedObject != oldFocusedObject)
        {
            //Debug.Log(FocusedObject);
            for (int i = 0; i < TomDeskText.Length; i++)
            {
                if (FocusedObject == tomDeskObjects[i])
                {

                    TomDeskText[i].enabled = true;
                    //toniBio.transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);

                    Debug.Log("found bio");
                }
                else
                {
                    TomDeskText[i].enabled = false;
                }
            }

            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }

    }

}
