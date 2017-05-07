using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationZoneManagerToni : MonoBehaviour {
	public GameObject dressActivationZonePosition;       //Public variable to store a reference to the dress game object
	public Light dressActivationZoneLightObject;
	public GameObject deskActivationZonePosition;       //Public variable to store a reference to the desk game object
	public Light deskActivationZoneLightObject;
	private float dressActivationZoneOffset;         //Private variable to store the offset distance between the dress and camera
	private float deskActivationZoneOffset;         //Private variable to store the offset distance between the desk and camera
	private Vector3 viewerTransform;
    // public Text PositionCamera;

    private bool dressAudioTriggered = false;

   
    AudioSource dressAudio;

    // Use this for initialization
    void Start () {

		dressActivationZoneLightObject.enabled = false;
		deskActivationZoneLightObject.enabled = false;
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		viewerTransform = transform.localPosition;
		//Debug.Log("viewerPosition: " + viewerTransform);
        dressAudio = dressActivationZonePosition.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {

		//Dynamic evaluation of distance to dress activation zone
		//dressActivationZoneOffset = transform.position - dressActivationZonePosition.transform.position;
        dressActivationZoneOffset = Vector3.Distance(transform.position, dressActivationZonePosition.transform.position);

		if (dressActivationZoneOffset < 2.8f)
		{
			dressActivationZoneLightObject.enabled = true;
            if (!dressAudioTriggered)
            {
                playDressAudio();
                dressAudioTriggered = true;
            }

        } else
		{
			dressActivationZoneLightObject.enabled = false;
            dressAudio.Pause();
		}


		//Dynamic evaluation of distance to desk activation zone
		//deskActivationZoneOffset = transform.position - deskActivationZonePosition.transform.position;
        deskActivationZoneOffset = Vector3.Distance(transform.position, deskActivationZonePosition.transform.position);


        if (Mathf.Abs(deskActivationZoneOffset) < 2.5f)
		{
			deskActivationZoneLightObject.enabled = true;
		} else
		{
			deskActivationZoneLightObject.enabled = false;
		}
	}

    private void playDressAudio()
    {
        dressAudio.Stop();
    }
}
