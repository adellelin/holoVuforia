using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressThatEatsSouls : MonoBehaviour {

    //public GameObject BioText;
    public AudioSource DressInstruct;
    public Animation armMove;

    private bool isActive = false;
    // Use this for initialization
    void Start () {

        //  BioText.SetActive(false);
        //armMove = GetComponent<Animation>();
        //armMove.Stop();
        gameObject.GetComponent<AudioSource>().Pause();
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
            armMove.Play("RoboticDress");
        } else
        {
            //BioText.SetActive(false);
            gameObject.GetComponent<AudioSource>().Pause();
            armMove.Stop("RoboticDress");
        }
    }
}
