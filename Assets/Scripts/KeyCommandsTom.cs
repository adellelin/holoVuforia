using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyCommandsTom : MonoBehaviour {

   
    public GameObject ToniDoveStudio;
    public GameObject TomsStudio;
    public GameObject KeyScene;
    public GazeGestureManagerTom gazeTom;
    public GazeGestureManager gazeKeyScene;
    public ActivationZoneManagerToni activationZoneToni;
    public ActivationZoneManagerTom activationZoneTom;

    // called by gazegesturemanager


    public void OnSelect()
    {
        
        if (TomsStudio.activeSelf == false)
        {
       
            ToniDoveStudio.SetActive(false);
			
            TomsStudio.SetActive(true);
			TomsStudio.GetComponent<AudioSource> ().Play ();
            activationZoneTom.enabled = true;
            activationZoneToni.enabled = false;
            //SceneManager.LoadScene("ToniDove");
            
            //gazeTom.enabled = true;
            KeyScene.SetActive(false);
            Debug.Log("tom's key selected");
            gazeKeyScene.enabled =false;

        }
       
    }
}
