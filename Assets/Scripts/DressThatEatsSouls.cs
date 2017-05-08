using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressThatEatsSouls : MonoBehaviour {

    //public GameObject BioText;
    public AudioSource DressInstruct;

    private bool isActive = false;
    // Use this for initialization
    void Start () {

      //  BioText.SetActive(false);
   
    }

    private void Update()
    {

    }
    public void OnSelect()
    {
        isActive = !isActive;
        if (isActive)
        {
            //BioText.SetActive(true);
            gameObject.GetComponent<AudioSource> ().Play ();
        } else
        {
            //BioText.SetActive(false);
            gameObject.GetComponent<AudioSource>().Pause();
        }
    }
}
