using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistCalendar : MonoBehaviour {

    public GameObject CalendarText;
    public GameObject CalendarNewText;
    private bool isActive = false;
    // Use this for initialization
    void Start () {
        CalendarText.SetActive(false);
        CalendarNewText.SetActive(false);
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
            CalendarNewText.SetActive(true);
        }
        else
        {
            CalendarText.SetActive(false);
            CalendarNewText.SetActive(false);
        }
    }
}
