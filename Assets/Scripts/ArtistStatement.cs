﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistStatement : MonoBehaviour
{

    public GameObject StatementText;
    private bool isActive = false;
    // Use this for initialization
    void Start()
    {
        StatementText.SetActive(false);
    }

    private void Update()
    {
 
    }
    public void OnSelect()
    {
        Debug.Log("statement selected");
        //BioText.SetActive(true);
        isActive = !isActive;
        Debug.Log("is it active?" + isActive);
        if (isActive)
        {
            Debug.Log("is active");
            StatementText.SetActive(true);
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (!isActive)
        {
            StatementText.SetActive(false);
            gameObject.GetComponent<AudioSource>().Pause();
        }

    }


}
