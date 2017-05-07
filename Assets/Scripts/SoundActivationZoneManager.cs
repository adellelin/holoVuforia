using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivationZoneManager : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<AudioSource>().mute = false;
    } 

    void OnTriggerEnter()
    {
        Debug.Log("Collision detected");
        //gameObject.GetComponent<AudioSource>().mute = true; // sound on attached object plays
        GameObject pictureObject = GameObject.Find("PictureLeft");
        pictureObject.GetComponent<AudioSource>().Play();
    }

}