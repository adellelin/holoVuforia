using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistContact : MonoBehaviour {

    public GameObject ContactText;

    private bool isActive = false;
    // Use this for initialization
    void Start () {
        ContactText.SetActive(false);
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
            ContactText.SetActive(true);
        }
        else
        {
            ContactText.SetActive(false);
        }
    
}
}
