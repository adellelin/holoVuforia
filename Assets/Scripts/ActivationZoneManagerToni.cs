using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationZoneManagerToni : MonoBehaviour {
	public GameObject dressActivationZonePosition;       //Public variable to store a reference to the dress game object
	public GameObject dressActivationZoneLightObject;
	public GameObject deskActivationZonePosition;       //Public variable to store a reference to the desk game object
	public Light deskActivationZoneLightObject;
	private float dressActivationZoneOffset;         //Private variable to store the offset distance between the dress and camera
	private float deskActivationZoneOffset;         //Private variable to store the offset distance between the desk and camera
	private Vector3 viewerTransform;
    // public Text PositionCamera;

    private bool dressAudioTriggered = false;

   
    public AudioSource dressAudio;


    public GameObject exitZonePosition;
    private float exitZoneOffset;
    public ExitZoneManagerToni exitManagerToni;
    // Use this for initialization
    void Start () {

		dressActivationZoneLightObject.SetActive(false);
		deskActivationZoneLightObject.enabled = false;
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		viewerTransform = transform.position;
		//Debug.Log("viewerPosition: " + viewerTransform);
        //dressAudio = dressActivationZonePosition.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {

		//Dynamic evaluation of distance to dress activation zone
		//dressActivationZoneOffset = transform.position - dressActivationZonePosition.transform.position;
        dressActivationZoneOffset = Vector3.Distance(transform.position, dressActivationZonePosition.transform.position);
        //Debug.Log("viewerPosition: " + dressActivationZoneOffset);
        if (dressActivationZoneOffset < 4f)
		{
            dressActivationZoneLightObject.SetActive(true);
            if (!dressAudioTriggered)
            {
                dressAudio.Play();
                dressAudioTriggered = true;
            }

        } else
		{
            dressActivationZoneLightObject.SetActive(false);
            dressAudio.Pause();
            dressAudioTriggered = false;
		}


		//Dynamic evaluation of distance to desk activation zone
		//deskActivationZoneOffset = transform.position - deskActivationZonePosition.transform.position;
        deskActivationZoneOffset = Vector3.Distance(transform.position, deskActivationZonePosition.transform.position);
  

        if (deskActivationZoneOffset < 2.8f)
		{
			deskActivationZoneLightObject.enabled = true;
		} else
		{
			deskActivationZoneLightObject.enabled = false;
		}

        exitZoneOffset = Vector3.Distance(transform.position, exitZonePosition.transform.position);
        //Debug.Log(paintingActivationZoneOffset);
        if (exitZoneOffset < 2f)
        {

            //SceneManager.LoadScene("VuforiaTest");
            //exitText.text = "exited";
            Debug.Log("exitZoneOffset" + exitZoneOffset);
            exitManagerToni.exitToniScene();
        }
        else { }
    }

    private void playDressAudio()
    {
        dressAudio.Play();
    }
}
