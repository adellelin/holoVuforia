using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistCalendar : MonoBehaviour {

    public GameObject CalendarText;
    private bool isActive = false;
    // Use this for initialization
    void Start () {
        CalendarText.SetActive(false);
    }


    private void Update()
    {
 
    }
    public void OnSelect()
    {

        //BioText.SetActive(true);
        isActive = !isActive;
        if (isActive)
        {
            CalendarText.SetActive(true);
        }
        else
        {
            CalendarText.SetActive(false);
        }
    }
}
