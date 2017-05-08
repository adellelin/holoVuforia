using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitZoneManagerToni : MonoBehaviour
{

    public Text exitText;
    public GameObject MovieBottom;
    public GameObject ToniDoveStudio;
    public GameObject KeyScene;
    public GazeGestureManager keySceneGaze;
    


    void Start()
    {
        Debug.Log("Logging Collision script");
    }

    private void Update()
    {
    
    }
        
        
    void OnTriggerEnter(Collider CollisionCube)
    {
        exitToniScene();
    }
    public void OnSelect()
    {
        exitToniScene();
    }

    public void exitToniScene()
    {
        Debug.Log("Went through the exit");
        Renderer render = GetComponent<Renderer>();

        //render.material.color = Color.cyan;
        //SceneManager.LoadScene("VuforiaTest");
        //exitText.text = "exited";
        MovieBottom.SetActive(false);
        ToniDoveStudio.SetActive(false);
        KeyScene.SetActive(true);
        keySceneGaze.enabled = true;
    }
}
