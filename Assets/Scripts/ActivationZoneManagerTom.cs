using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationZoneManagerTom : MonoBehaviour
{
    public GameObject paintingActivationZonePosition;       //Public variable to store a reference to the painting game object
    public Light paintingActivationZoneLightObject;
    public GameObject sculptureActivationZonePosition;       //Public variable to store a reference to the sculpture game object
                                                             //public Light sculptureActivationZoneLightObject;
    public GameObject sculptureActivationZoneLightObject;
    public GameObject deskActivationZonePosition;       //Public variable to store a reference to the desk game object
    public Light deskActivationZoneLightObject;
    private float paintingActivationZoneOffset;         //Private variable to store the offset distance between the painting and camera
    private float sculptureActivationZoneOffset;         //Private variable to store the offset distance between the sculpture and camera
    private Vector3 deskActivationZoneOffset;         //Private variable to store the offset distance between the desk and camera
    private Vector3 viewerTransform;
    private bool paintingAudioTriggered = false;
    private bool sculptureAudioTriggered = false;   // set audio state
    public bool sculptureZoneActivated = false; // sets whether rotation on sculpture is allowed

    //AudioClip paintingAudio;
    AudioSource paintingAudio;
    public AudioSource sculptureAudio;
    public GameObject pendulum;

    // public Text PositionCamera;

    // Use this for initialization
    void Start()
    {

        paintingActivationZoneLightObject.enabled = false;
        sculptureActivationZonePosition.SetActive(false);
        sculptureActivationZoneLightObject.SetActive(false);
        deskActivationZoneLightObject.enabled = false;
        pendulum.SetActive(false);
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        viewerTransform = transform.position;
        Debug.Log("viewerPosition: " + viewerTransform);
        paintingAudio = paintingActivationZonePosition.GetComponent<AudioSource>();

        Debug.Log("paintingaudio length" + paintingAudio.clip.length);
    }

    // Update is called once per frame
    void Update()
    {

        //Dynamic evaluation of distance to painting activation zone
        //paintingActivationZoneOffset = transform.position - paintingActivationZonePosition.transform.position;
        //Debug.Log(paintingActivationZoneOffset);
        paintingActivationZoneOffset = Vector3.Distance(transform.position, paintingActivationZonePosition.transform.position);
        //Debug.Log(paintingActivationZoneOffset);
        if (paintingActivationZoneOffset < 2.8f )
        {
            paintingActivationZoneLightObject.enabled = true;
            pendulum.SetActive(true);
            pendulum.transform.Rotate(0, 0, 1f);

            if (!paintingAudioTriggered)
            {
                playPaintingAudio();
                paintingAudioTriggered = true;
            }
        }
        else
        {
            paintingActivationZoneLightObject.enabled = false;
            paintingAudio.Pause();
            pendulum.SetActive(false);
            paintingAudioTriggered = false;
        }

        //Dynamic evaluation of distance to sculpture activation zone
        sculptureActivationZoneOffset = Vector3.Distance(transform.position, sculptureActivationZonePosition.transform.position);
        
        //Debug.Log("sculptureoffset: "+sculptureActivationZoneOffset);
        if (sculptureActivationZoneOffset < 2.8f)
        {
            sculptureActivationZoneLightObject.SetActive(true);
            sculptureZoneActivated = true;
            if (!sculptureAudioTriggered)
            {
                sculptureAudio.Play();
                sculptureAudioTriggered = true;
            }
        }
        else
        {
            sculptureAudio.Pause();
            sculptureActivationZoneLightObject.SetActive(false);
            sculptureZoneActivated = true;
            sculptureAudioTriggered = false;

        }

        //Dynamic evaluation of distance to desk activation zone
        deskActivationZoneOffset = transform.position - deskActivationZonePosition.transform.position;

        if (Mathf.Abs(deskActivationZoneOffset.x) < 2f)
        {
            deskActivationZoneLightObject.enabled = true;
        }
        else
        {
            deskActivationZoneLightObject.enabled = false;
        }
    }

    private void playPaintingAudio()
    {

        paintingAudio.Play();
        //Invoke("SculptureAppear", paintingAudio.clip.length);
        Invoke("SculptureAppear", 10);
    }

    void SculptureAppear()
    {
        sculptureActivationZonePosition.SetActive(true);
        //paintingAudio.Stop();
    }

}
